using System;
using System.Collections.Generic;
using System.Windows.Forms;
using process_demonizator.UI;
using PD.UI.Shared;
using System.Threading.Tasks;
using PD.Api.Client;

namespace PD.CL.UI.UI {

    public partial class FrmMain : Form {

        private ClientApi _api;
        private Dictionary<int, string> _keys;

        public FrmMain() {
            InitializeComponent();
            Text = InfoHelper.NameVersion;
            _notifyIcon.Text = InfoHelper.NameVersion;
            dgvProcessList.AutoGenerateColumns = false;
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

        private void smenuAbout_Click( object sender, EventArgs e ) => new FrmAbout().ShowDialog();

        private async void smenuStartMonitorServer_Click( object sender, EventArgs e ) {
            var cf = new frmConnect();
            if ( cf.ShowDialog() == DialogResult.OK ) await Connect( cf.Server ).ConfigureAwait( true );
        }

        private async Task Connect( string server ) {
            _api = new ClientApi( server );
            _keys = new Dictionary<int, string>();
            await UpdateServers().ConfigureAwait( true );
        }

        private async Task UpdateServers() => dgvProcessList.DataSource = await _api.Process.List().ConfigureAwait( true );

    }

}