using rtss_srv.DataProvider;
using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace rtss_srv
{
    public class Service : IService
    { 
        private Stream GetSteramFromString(string input, string contentType)
        {
            OutgoingWebResponseContext response = WebOperationContext.Current.OutgoingResponse;
            response.ContentType = contentType;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(input);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /**
         * provide static content for browser (scripts, css)
         */
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "static/{*content}")]
        public Stream StaticContent(string content)
        {
            switch (content)
            {
                case "chart.min.js":
                    return GetSteramFromString(rtss_srv.Properties.Resources.chart_min, "application/javascript");                
                case "style.css":
                    return GetSteramFromString(rtss_srv.Properties.Resources.style, "text/css");                    
                default:
                    WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
                    return null;
            }                        
        }

        /**
         * provide the index.html
         */
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/start")]
        public Stream Start()
        {
            return GetSteramFromString(rtss_srv.Properties.Resources.index, "text/html");
        }
        
        [WebInvoke(Method = "GET",
   ResponseFormat = WebMessageFormat.Json,
   BodyStyle = WebMessageBodyStyle.Wrapped,
   UriTemplate = "pList")]
        public RTSSAppEntry[] GetProcessList()
        {
            return RTSSDataProvider.GetProcessList();
        }


        [WebInvoke(Method = "GET",
   ResponseFormat = WebMessageFormat.Json,
   BodyStyle = WebMessageBodyStyle.Wrapped,
   UriTemplate = "pData?pid={processId}&d={dataType}")]
        public PerfData[] GetProcessData(int processId, int dataType)
        {            
            return PerfDataCache.Get().GetPerfDatas(processId, dataType);
        }
    }
}
