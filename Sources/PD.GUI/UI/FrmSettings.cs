using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace process_demonizator.UI
{
    public sealed partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            var progNameVer = AssemblyProduct + @" " + AssemblyVersion;
            InitializeComponent();
            Text = @"Settings :: " + progNameVer;
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


        private void FrmSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
