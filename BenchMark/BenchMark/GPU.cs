using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace BenchMark
{
    public partial class GPU : Form
    {
        public GPU()
        {
            InitializeComponent();

            string r = " ";

            r = GetComponent("Win32_DesktopMonitor", "Name");
            lblName.Text = r;

            r = GetComponent("Win32_VideoController", "VideoModeDescription");
            lblModeVideo.Text = r;

            r = GetComponent("Win32_DesktopMonitor", "Status");
            lblStatus.Text = r;

            r = GetComponent("Win32_VideoController", "VideoProcessor");
            lblVideoProcessor.Text = r;

        }
        private static string GetComponent(string hwclass, string syntax)
        {
            string res = "";

            //ativar a classe

            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            foreach (ManagementObject mj in mos.Get())
            {
                res = Convert.ToString(mj[syntax]);


            }
            return (res);
        }

    }
}