using System;
using System.Windows.Forms;
using PD.UI.Shared;

namespace process_demonizator.UI {

    public sealed partial class FrmMain : Form {

        public FrmMain() {
            InitializeComponent();
            Text = InfoHelper.NameVersion;
            _notifyIcon.Text = InfoHelper.NameVersion;
        }

        private FormWindowState _oldFormState;

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

        private void smenuSettions_Click( object sender, EventArgs e ) => new FrmSettings().ShowDialog();

        private void smenuExit_Click( object sender, EventArgs e ) => Application.Exit();

        private void smenuStartMonitorServer_Click( object sender, EventArgs e ) => new FrmStartHm().ShowDialog();

        private void smenuAddNewItem_Click( object sender, EventArgs e ) => new FrmAdd().ShowDialog();

        private void smenuAbout_Click( object sender, EventArgs e ) => new FrmAbout().ShowDialog();

        private void smenuLicense_Click( object sender, EventArgs e ) => InfoHelper.ShowLicense();

        private void FrmMain_Resize( object sender, EventArgs e ) {
            if ( FormWindowState.Minimized == WindowState )
                Hide();
        }

    }

}