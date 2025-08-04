using MindCleaner.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KeyAuth.api;

namespace MindCleaner
{
    internal class browserclear
    {
        public static void CleanerRruns()
        {
            ClearBraveHistory();
            ClearChromeHistory();
            ClearEdgeHistory();
            ClearOperaHistory();
            Thread.Sleep(3000);
            MessageBox.Show("Successfully cleart Browser History");
        }
        static void ClearOperaHistory()
        {
            // Replace with the correct path to the Opera executable
            string operaPath = @"C:\Program Files\Opera\launcher.exe";

            // Open Opera settings page to clear browsing data
            Process.Start(operaPath, "--settings-frame=clearBrowserData");
        }
        static void ClearEdgeHistory()
        {
            // Replace with the correct path to the Edge executable
            string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";

            // Open Edge settings page to clear browsing data
            Process.Start(edgePath, "shell:SettingsPrivacy");
        }
        static void ClearBraveHistory()
        {
            // Replace with the correct path to the Brave executable
            string bravePath = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe";

            // Open Brave settings page to clear browsing data
            Process.Start(bravePath, "--settings/clearBrowserData");
        }
        static void ClearChromeHistory()
        {
            // Replace with the correct path to the Chrome executable
            string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

            // Open Chrome settings page to clear browsing data
            Process.Start(chromePath, "--settings/clearBrowserData");
        }

    }
}
