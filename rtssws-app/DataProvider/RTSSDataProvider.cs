using RTSSSharedMemoryNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rtss_srv.DataProvider
{
    internal class RTSSDataProvider : DataProviderBase<int>
    {
        private static readonly string rtssDefaultPath = @"C:\Program Files (x86)\RivaTuner Statistics Server\RTSS.exe";        
        private static int fpsMin = int.MaxValue;
        private static bool processFound;
        private uint lastProcessedFps;
        public enum RtssState
        {
            RUNNING,
            RUNABLE,
            NOT_FOUND
        }


        public static bool IsProcessFound()
        {
            return processFound;
        }
        public static RTSSAppEntry[] GetProcessList()
        {
            List<RTSSAppEntry> result = new List<RTSSAppEntry>();
            try
            {
                AppEntry[] appEntries = OSD.GetAppEntries().Where(x => (x.Flags & AppFlags.MASK) != AppFlags.None).ToArray();
                foreach (var app in appEntries)
                {
                    RTSSAppEntry ae = new RTSSAppEntry
                    {
                        AppName = app.Name,
                        ProcessId = "" + app.ProcessId,
                        CurrentFps = "" + CalculateFps(app)
                    };
                    result.Add(ae);
                }
            }
            catch
            { }

            return result.OrderByDescending(o => o.CurrentFps).ToArray();
        }

        private static int CalculateFps(AppEntry appEntry)
        {
            uint fpsTime = appEntry.InstantaneousTimeEnd - appEntry.InstantaneousTimeStart;
            if (fpsTime == 0)
            {
                return 0;
            }
            uint fps = appEntry.InstantaneousFrames;
            return (int)(1000 * fps / fpsTime);
        }

        internal static void StartRtss()
        {
            try
            {
                Process.Start(rtssDefaultPath);
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException("Unable to run RTSS server. Please start it manualy", ex);
            }
        }

        public static RtssState GetRtssState()
        {
            if (Process.GetProcessesByName("RTSS").Length != 0)
            {
                return RtssState.RUNNING;
            }
            else if (File.Exists(rtssDefaultPath))
            {
                return RtssState.RUNABLE;
            }
            else
            {
                return RtssState.NOT_FOUND;
            }
        }

        protected override int GetDataImpl(int processId)
        {
            int result = fpsMin == int.MaxValue ? 0 : fpsMin;
            fpsMin = int.MaxValue;
            return result;

        }

        public override void Start()
        {
            processFound = false;
            fpsMin = int.MaxValue;
        }

        protected override void StopImpl()
        {
            processFound = false;
            fpsMin = int.MaxValue;
        }

        protected override bool UpdateDataImpl(int processId, int dataTypes)
        {
            if (processId <= 0)
            {
                processFound = false;
                return false;
            }
            try
            {
                AppEntry[] appEntries = OSD.GetAppEntries().Where(x => (x.ProcessId == processId)).ToArray();
                if (appEntries != null && appEntries.Length > 0)
                {
                    processFound = true;
                    AppEntry appEntry = appEntries[0];
                    uint fpsEndTime = (uint)appEntry.InstantaneousTimeEnd;
                    if (lastProcessedFps == fpsEndTime)
                    {
                        return false;
                    }
                    lastProcessedFps = fpsEndTime;
                    fpsMin = Math.Min(fpsMin, CalculateFps(appEntry));
                    return true;
                }
                else
                {
                    processFound = false;                    
                }
            }
            catch { }
            return false;
        }
    }
}
