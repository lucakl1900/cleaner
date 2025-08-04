using KeyAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MindCleaner
{
    public partial class Login : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int left,
        int top,
        int right,
        int bottom,
        int width,
        int height
     );
        private static api keyAuthApp = new api(

       name: "Cleaner",
       ownerid: "0GpVPDYRBo",
       secret: "70b1a5a096799e79326a39838e18b7558ba529d89e6a6ed9ea3a44411172e3d4",
       version: "1.0"
       );
        public static api KeyAuthApp { get => keyAuthApp; set => keyAuthApp = value; }
        public class Credentials 
        {
            public string Key { get; set; }
        }

       
        

        public Login()
        {
            KeyAuthApp.init();
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
        }

        private void Login_Load(object sender, EventArgs e)
        {
        
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            KeyAuthApp.license(guna2TextBox3.Text);
            if (KeyAuthApp.response.success)
            {
                Main main = new Main();
                main.Show();
                this.Hide();
           }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
