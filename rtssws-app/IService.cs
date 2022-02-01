using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace rtss_srv
{
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        RTSSAppEntry[] GetProcessList();


        [OperationContract] 
        PerfData[] GetProcessData(int processId, int dataType);

        [OperationContract]        
        Stream Start();
        
        [OperationContract]
        Stream StaticContent(string content);
    }  
}

[Flags]
public enum PerfDataType
{
    None = 0,
    CPUUSE = 1,
    GPUUSE = 2,
    SYSMEM = 4,
    GPUMEM = 8,
    CPUTEMP = 16,
    GPUTEMP = 32,
    DISK = 64,
    FPS = 128,
}
public class RTSSAppEntry
    {
        public string ProcessId { get; set; }
        public string AppName { get; set; }
        public string CurrentFps{ get; set; }        
    }


public class PerfData
{
    public int[] Data { get; set; }        
}

