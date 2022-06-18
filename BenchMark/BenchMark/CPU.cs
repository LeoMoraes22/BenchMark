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
    public partial class CPU : Form
    {
        public CPU()
        {
            InitializeComponent();

            string r = " ";

            r = GetComponent("Win32_Processor", "Name");
            lblNome.Text = r;

            r = GetComponent("Win32_Processor", "SystemName");
            lblSistema.Text = r;

            r = GetComponent("Win32_Processor", "ProcessorID");
            lblIDProcessador.Text = r;

            r = GetComponent("Win32_Processor", "Status");
            lblStatus.Text = r;

            r = GetComponent("Win32_Processor", "Description");
            lblDescription.Text = r;

            r = GetComponent("Win32_Processor", "L2CacheSize");
            lblL2.Text = r ;

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

        private void btnCPU_Click_1(object sender, EventArgs e)
        {
            CPU newCPU = new CPU();
            newCPU.Show();
        }

        private void btnGPU_Click_1(object sender, EventArgs e)
        {
            GPU newGPU = new GPU();
            newGPU.Show();
        }

        private void btnMemoria_Click(object sender, EventArgs e)
        {
            Memoria newMemoria = new Memoria();
            newMemoria.Show();
        }

        private void btnCooler_Click(object sender, EventArgs e)
        {
            Cooler newCooler = new Cooler();
            newCooler.Show();
        }

        private void btnUSB_Click(object sender, EventArgs e)
        {
            Entrada newEntrada = new Entrada();
            newEntrada.Show();
        }
    }
}