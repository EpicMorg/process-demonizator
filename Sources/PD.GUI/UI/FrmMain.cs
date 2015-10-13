using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace process_demonizator.UI
{
    public sealed partial class FrmMain : Form
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
            if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized){
                _oldFormState = WindowState;
                WindowState = FormWindowState.Minimized;
            }else{
                Show();
                WindowState = _oldFormState;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
