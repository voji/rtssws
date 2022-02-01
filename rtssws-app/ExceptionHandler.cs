using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rtss_srv
{
    class ExceptionHandler
    {
        static readonly string exceptionFile = @"Exceptions.txt";
        public static void HandleException(string message, Exception ex)
        {
            using (StreamWriter writer = new StreamWriter(exceptionFile, true))
            {                                
                writer.WriteLine("<" + DateTime.Now.ToString()+"> " + message);
                writer.WriteLine();
                while (ex != null)
                {
                    writer.WriteLine(ex.GetType().FullName);
                    writer.WriteLine("Message : " + ex.Message);
                    writer.WriteLine("StackTrace : " + ex.StackTrace);

                    ex = ex.InnerException;
                }
                writer.WriteLine("-----------------------------------------------------------------------------");
            }
            MessageBox.Show(message + Environment.NewLine + "See " + exceptionFile + " file for details", "WebRTSS error");
        }
    }
}
