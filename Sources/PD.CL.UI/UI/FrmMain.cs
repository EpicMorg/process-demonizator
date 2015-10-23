using System;
using System.Windows.Forms;
using PD.UI.Shared;

namespace PD.CL.UI.UI {

    public partial class FrmMain : Form {

        public FrmMain() {
            InitializeComponent();
            Text = InfoHelper.NameVersion;
            _notifyIcon.Text = InfoHelper.NameVersion;
        }

        private FormWindowState _oldFormState;

        private void FormForTray_Resize( object sender, EventArgs e ) {
            if ( FormWindowState.Minimized == WindowState )
                Hide();
        }
        private void _notifyIcon_MouseClick( object sender, MouseEventArgs e ) {
            if ( e.Button != MouseButtons.Left ) return;
            if ( WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized ) {
                _oldFormState = WindowState;
                WindowState = FormWindowState.Minimized;
            }
            else {
                Show();
                WindowState = _oldFormState;
            }
        }
        private void smenuLicense_Click( object sender, EventArgs e ) => InfoHelper.ShowLicense();
    }

}