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
    public partial class Entrada : Form
    {
        public Entrada()
        {
            InitializeComponent();

            string r = " ";

            r = GetComponent("Win32_Keyboard", "Name");
            lblNomeTeclado.Text = r;

            r = GetComponent("Win32_SoundDevice", "Name");
            lblSaidaSom.Text = r;

            r = GetComponent("Win32_PointingDevice", "Name");
            lblNomeMouse.Text = r;

            r = GetComponent("Win32_SoundDevice", "Status");
            lblStatus.Text = r;
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
