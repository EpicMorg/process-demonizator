using System;
using System.Reflection;
using System.Windows.Forms;

namespace process_demonizator.UI
{
    public sealed partial class FrmStartHm : Form
    {
        public FrmStartHm()
        {
            {
                var progNameVer = AssemblyProduct + @" " + AssemblyVersion;
                InitializeComponent();
                Text = @"Start HiveMind Server :: " + progNameVer;
            }
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
        private void FrmStartHM_Load(object sender, EventArgs e)
        {

        }
    }
}
