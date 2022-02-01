using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace rtss_srv
{
    class NetworkHandler
    {

        private static ServiceHost host = null;

        public static string[] GetIPAddresses()
        {
            List<string> result = new List<string>
            {
                "localhost"
            };
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    result.Add(ip.ToString());
                }
            }
            return result.ToArray();
        }

        /**
         * Return preferred ip address
         */
        public static string GetAddress()
        {
            string[] ips = GetIPAddresses();            
            foreach (string ip in ips)
            {
                if (ip.StartsWith("192.168."))
                {
                    return ip;
                }
            }
            foreach (string ip in ips)
            {
                if (ip.StartsWith("192."))
                {
                    return ip;
                }
            }
            return ips[0];
        }

        public static bool StartService(uint port)
        {
            try
            {
                Uri serviceURL = new Uri("http://localhost:" + port);
                WebHttpBinding oBinding = new WebHttpBinding
                {
                    Name = "basicHttpBinding",
                    CloseTimeout = System.TimeSpan.Parse("00:10:00"),
                    OpenTimeout = System.TimeSpan.Parse("00:10:00"),
                    ReceiveTimeout = System.TimeSpan.Parse("00:10:00"),
                    SendTimeout = System.TimeSpan.Parse("00:10:00"),
                    HostNameComparisonMode = System.ServiceModel.HostNameComparisonMode.WeakWildcard,
                    MaxBufferPoolSize = 2147483647,
                    MaxReceivedMessageSize = 2147483647
                };
                oBinding.ReaderQuotas.MaxDepth = 32;
                oBinding.ReaderQuotas.MaxStringContentLength = 2147483647;
                oBinding.ReaderQuotas.MaxArrayLength = 16384;
                oBinding.ReaderQuotas.MaxBytesPerRead = 4096;
                oBinding.ReaderQuotas.MaxNameTableCharCount = 16384;
                oBinding.Security.Mode = WebHttpSecurityMode.None;
                host = new ServiceHost(typeof(Service), serviceURL);
                ServiceEndpoint serviceEndpoint = host.AddServiceEndpoint(typeof(IService), oBinding, "");
                serviceEndpoint.EndpointBehaviors.Add(new WebHttpBehavior());
                host.Open();
            } catch (Exception ex)
            {
                ExceptionHandler.HandleException("Unable to start server (maybe not run as admin, or port already used)", ex);
                return false;
            }
            return true;
        }

        public static bool StopService()
        {
            try
            {
                host.Close();
                host = null;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException("Unable to stop server", ex);
                return true;
            }
            return false;
        }
    }
}
