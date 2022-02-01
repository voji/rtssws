using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rtss_srv
{
    static class Program
    {
        static readonly string[] dependencies = new string[] { "RTSSSharedMemoryNET.dll", "LibreHardwareMonitorLib.dll", "HidSharp.dll", "rtssws.exe.config" };
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar;
            foreach (string dependency in dependencies)
            {
                if (!File.Exists(path + dependency))
                {
                    MessageBox.Show("The following file could not be found: " + dependency +
                      "\nPlease extract all files from the archive.", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (MainForm form = new MainForm())
            {
                form.FormClosed += delegate
                {
                    Application.Exit();
                };
                Application.Run(form);
            }            
        }
    }
}
