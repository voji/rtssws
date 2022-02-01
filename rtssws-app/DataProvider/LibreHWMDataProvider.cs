using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtss_srv.DataProvider
{
    internal class LibreHWMDataProvider : DataProviderBase<PerfData>
    {
        private Computer computer;
        float maxCpuUsage = 0;
        float maxGpuUsage = 0;
        float maxSysMem = 0;        
        float maxGpuMem = 0;
        float maxGpuMemUsed = 0;
        float maxCpuTemp = 0;
        float maxGpuTemp = 0;
        float maxDisk = 0;        


        public override void Start()
        {
            ClearValues();
            computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
                IsStorageEnabled = true,
                IsMotherboardEnabled = false,
                IsControllerEnabled = false,
                IsNetworkEnabled = false
            };
            computer.Open();
            foreach (IHardware hardware in computer.Hardware)
            {
                foreach (ISensor sensor in hardware.Sensors)
                {
                    sensor.ValuesTimeWindow = TimeSpan.Zero;
                }
            }
        }

        protected override void StopImpl()
        {            
            computer.Close();
            computer = null;            
        }

        protected void ClearValues()
        {
            maxCpuUsage = 0;
            maxGpuUsage = 0;
            maxSysMem = 0;            
            maxGpuMem = 0;
            maxGpuMemUsed = 0;
            maxCpuTemp = 0;
            maxGpuTemp = 0;
            maxDisk = 0;
        }


        protected override bool UpdateDataImpl(int processId, int dataTypes)
        {
            if (computer != null)
            {
                foreach (IHardware hardware in computer.Hardware)
                {
                    switch (hardware.HardwareType)
                    {
                        case HardwareType.Cpu:
                            if ((dataTypes & ((int)PerfDataType.CPUUSE)) != 0 || (dataTypes & ((int)PerfDataType.CPUTEMP)) != 0)
                            {
                                hardware.Update();
                                foreach (ISensor sensor in hardware.Sensors)
                                {
                                    if (sensor.SensorType == SensorType.Load && sensor.Name.Equals("CPU Total"))
                                    {
                                        maxCpuUsage = Math.Max(maxCpuUsage, (float)sensor.Value);
                                    } else if (sensor.SensorType == SensorType.Temperature && sensor.Name.Equals("Core Max"))
                                    {
                                        maxCpuTemp = Math.Max(maxCpuTemp, (float)sensor.Value);
                                    }
                                }
                            }
                            break;
                        case HardwareType.GpuAmd:
                        case HardwareType.GpuNvidia:
                            if ((dataTypes & ((int)PerfDataType.GPUUSE)) != 0  || (dataTypes & ((int)PerfDataType.GPUMEM)) != 0 || (dataTypes & ((int)PerfDataType.GPUTEMP)) != 0)
                            {
                                hardware.Update();
                                foreach (ISensor sensor in hardware.Sensors)
                                {
                                    if (sensor.SensorType == SensorType.Load && !sensor.Name.Equals("GPU Core"))
                                    {
                                        maxGpuUsage = Math.Max(maxGpuUsage, (float)sensor.Value);
                                    }
                                    else if (sensor.SensorType == SensorType.Temperature && sensor.Name.Equals("GPU Core"))
                                    {
                                        maxGpuTemp = Math.Max(maxGpuTemp, (float)sensor.Value);
                                    } else if (sensor.SensorType == SensorType.SmallData && sensor.Name.Equals("GPU Memory Total")) 
                                    { 
                                        maxGpuMem = Math.Max(maxGpuMem, (float)sensor.Value);
                                    } else if (sensor.SensorType == SensorType.SmallData && sensor.Name.Equals("GPU Memory Used"))
                                    {
                                        maxGpuMemUsed = Math.Max(maxGpuMemUsed, (float)sensor.Value);
                                    }
                            }
                            }
                            break;
                        case HardwareType.Memory:
                            if ((dataTypes & ((int)PerfDataType.SYSMEM)) != 0)
                            {
                                hardware.Update();
                                foreach (ISensor sensor in hardware.Sensors)
                                {
                                    if (sensor.SensorType == SensorType.Load && sensor.Name.Equals("Memory"))
                                    {
                                        maxSysMem = Math.Max(maxSysMem, (float)sensor.Value);
                                    }                                    
                                }
                            }
                            break;
                        case HardwareType.Storage:
                            if ((dataTypes & ((int)PerfDataType.DISK)) != 0)
                            {
                                hardware.Update();
                                foreach (ISensor sensor in hardware.Sensors)
                                {
                                    if (sensor.SensorType == SensorType.Load && sensor.Name.Equals("Total Activity"))
                                    {
                                        maxDisk = Math.Max(maxDisk, (float)sensor.Value);
                                    }                                    
                                }
                            }
                                                        
                            break;
                    }
                }
                return true;
            }
            return false;
        }

        protected override PerfData GetDataImpl(int processId)
        {
            if (computer == null)
            {
                this.Start();
            }

            PerfData result = new PerfData()
            {
                Data = new int[] { 
                    (int)Math.Round(this.maxCpuUsage),
                    (int)Math.Round(this.maxGpuUsage),
                    (int)Math.Round(this.maxSysMem),
                    (int)Math.Round(this.maxGpuMem > 0 ? ((float)this.maxGpuMemUsed / this.maxGpuMem) * 100 : 0),
                    (int)Math.Round(maxCpuTemp),
                    (int)Math.Round(maxGpuTemp),
                    (int)Math.Round(maxDisk), 
                    0 //fps not measured here
                }
            };
            ClearValues();
            return result;
        }        
    }
}
