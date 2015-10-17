using System;
using System.Reflection;
using System.Windows.Forms;

namespace PD.CL.UI.UI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            var progNameVer = AssemblyProduct + @" " + AssemblyVersion;
            InitializeComponent();
            Text = progNameVer;
            _notifyIcon.Text = progNameVer;
            Resize += (FormForTray_Resize);
            _notifyIcon.MouseClick += (_notifyIcon_MouseClick);
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

        private FormWindowState _oldFormState;
        void FormForTray_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                Hide();
            }
        }

        void _notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
            {
                _oldFormState = WindowState;
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                Show();
                WindowState = _oldFormState;
            }
        }

        private void smenuLicense_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"The MIT License (MIT)" + Environment.NewLine + Environment.NewLine + @"Copyright " + (char)0169 + @" " + DateTime.Now.Year + @" " + AssemblyCompany
          + Environment.NewLine
          + Environment.NewLine + @"Permission is hereby granted, free of charge, to any person obtaining a copy"
          + Environment.NewLine + @"of this software and associated documentation files(the ''Software''), to deal"
          + Environment.NewLine + @"in the Software without restriction, including without limitation the rights"
          + Environment.NewLine + @"to use, copy, modify, merge, publish, distribute, sublicense, and / or sell"
          + Environment.NewLine + @"copies of the Software, and to permit persons to whom the Software is"
          + Environment.NewLine + @"furnished to do so, subject to the following conditions: "
          + Environment.NewLine
          + Environment.NewLine + @"The above copyright notice and this permission notice shall be included in all"
          + Environment.NewLine + @"copies or substantial portions of the Software."
          + Environment.NewLine
          + Environment.NewLine + @"THE SOFTWARE IS PROVIDED ''AS IS'', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR"
          + Environment.NewLine + @"IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,"
          + Environment.NewLine + @"FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE"
          + Environment.NewLine + @"AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER"
          + Environment.NewLine + @"LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,"
          + Environment.NewLine + @"OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE"
          + Environment.NewLine + @"SOFTWARE.", @"LICENSE", MessageBoxButtons.OK, MessageBoxIcon.Information
          );
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
