using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtss_srv.DataProvider
{
    internal abstract class DataProviderBase<T>
    {    
        private readonly Object updateLock = new Object();
        int lastUpdate = 0;
        protected bool hasData;
        public abstract void Start();

        public void Stop()
        {
            StopImpl();
            hasData = false;
        }

        protected abstract void StopImpl();

        public void Tick(int interval, int processId, int dataTypes)
        {
            int currentTick = Environment.TickCount;
            if (!hasData || currentTick - lastUpdate > interval)
            {
                lock (updateLock) { 
                    hasData = UpdateDataImpl(processId, dataTypes);
                    if (hasData)
                    {
                        lastUpdate = currentTick;
                    }
                }
            }
        }

        protected abstract bool UpdateDataImpl(int processId, int dataTypes);
        

        public T GetData(int value, int dataTypes)
        {
            lock (updateLock)
            {
                if (!hasData)
                {
                    UpdateDataImpl(value, dataTypes);
                }
            }
            T result = GetDataImpl(value);
            hasData = false;
            return result;
        }

        
        protected abstract T GetDataImpl(int value);

        public bool HasData()
        {
            return hasData;
        }

    }
}
