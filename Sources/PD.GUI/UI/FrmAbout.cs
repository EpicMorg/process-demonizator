using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace process_demonizator.UI
{
    public sealed partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
            Text = @"About";
            txtProgName.Text = AssemblyProduct;
            txtVer.Text = AssemblyVersion;
            txtProgCopy.Text = @"Copyright " + (char)0169 + @" " + AssemblyCompany;
        }

        public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();


        public string AssemblyProduct
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        private void FrmAbout_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://epicm.org/");
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/EpicMorg/process-demonizator");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/m66n/ipaddresscontrollib");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
