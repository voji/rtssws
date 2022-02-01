using rtss_srv.DataProvider;
using System;
using System.Collections.Generic;

namespace rtss_srv
{
    class PerfDataCache
    {
        private static readonly PerfDataCache _instance = new PerfDataCache();
        private readonly LibreHWMDataProvider libreHWMDataProvider = new LibreHWMDataProvider();
        private readonly RTSSDataProvider rtssDataProvider = new RTSSDataProvider();

        private readonly Object pfcLock = new Object();
        private readonly Queue<PerfData> perfDataCache = new Queue<PerfData>();        
        private int processId = 0;
        private int dataTypes;        
        private long lastSaveTick = -1;
        private long lastQueryTick = -1;

        public enum TickResult
        {
            RUN_W_RTSS,
            RUN_WO_RTSS,
            IDLE,
        }

        public static PerfDataCache Get()
        {
            return _instance;
        }

        public void Stop()
        {            
            lock (pfcLock)
            {
                perfDataCache.Clear();
            }
            libreHWMDataProvider.Stop();
            rtssDataProvider.Stop();
        }

        public TickResult Tick(int interval)
        {            
            if (lastQueryTick > 0)
            {
                int currentTime = Environment.TickCount;
                if (currentTime - lastQueryTick > 10000) //10 second without any query
                {
                    lastQueryTick = -1;
                    this.Stop();
                    return TickResult.IDLE;
                }
                lock (pfcLock)
                {
                    UpdateData(interval);
                }
                return rtssDataProvider.HasData() ? TickResult.RUN_W_RTSS : TickResult.RUN_WO_RTSS;                                
            }
            return TickResult.IDLE;
        }

        private void UpdateData(int interval)
        {
            long currentTick = Environment.TickCount;
            lock (pfcLock)
            {                 
                libreHWMDataProvider.Tick(interval, processId, dataTypes);
                rtssDataProvider.Tick(interval, processId, dataTypes);
                    
                if (currentTick - lastSaveTick > 1000)
                {
                    PerfData perfData = libreHWMDataProvider.GetData(processId, dataTypes);
                    perfData.Data[7] = rtssDataProvider.GetData(processId, dataTypes);
                    lastSaveTick = currentTick;
                    perfDataCache.Enqueue(perfData);
                }
            }
            
        }

        public PerfData[] GetPerfDatas(int pidstr, int dt) {
            processId = pidstr;
            dataTypes = dt;
            lastQueryTick = Environment.TickCount;
            lock (pfcLock)
            {
                if (perfDataCache.Count == 0)
                {
                    lastSaveTick = 0;
                    UpdateData(int.MaxValue);             
                }
                PerfData[] result = perfDataCache.ToArray();                
                perfDataCache.Clear();
                return result;
            }
        }
    }
}
