using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using PD.Api;
using PD.Api.Client.Admin;
using PD.UI.Shared;

namespace process_demonizator.UI {

    public sealed partial class FrmMain : Form {

        private FormWindowState _oldFormState;
        private IAdminApi _api;
        public string ApiKey { get; set; }

        public FrmMain() {
            InitializeComponent();
            Text = InfoHelper.NameVersion;
            _notifyIcon.Text = InfoHelper.NameVersion;
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

        private void smenuExit_Click( object sender, EventArgs e ) => Application.Exit();

        private void smenuSettions_Click( object sender, EventArgs e ) { new FrmSettings().ShowDialog(); }

        private void smenuAbout_Click( object sender, EventArgs e ) => new FrmAbout().ShowDialog();

        private void smenuLicense_Click( object sender, EventArgs e ) => InfoHelper.ShowLicense();

        private void FrmMain_Resize( object sender, EventArgs e ) {
            if ( FormWindowState.Minimized == WindowState )
                Hide();
        }

        private async void smenuStartMonitorServer_Click( object sender, EventArgs e ) {
            using ( var frmStartHm = new FrmStartHm() ) {
                if ( frmStartHm.ShowDialog() != DialogResult.OK ) return;

                bool checkResult;
                var key = frmStartHm.Key;

                var api = new AdminApi(frmStartHm.Server);
                try {
                    checkResult = await api.Settings.CheckKey( key ).ConfigureAwait( true );
                }
                catch ( Exception ) {
                    MessageBox.Show( "Failed to get response from server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                }

                if ( checkResult ) {
                    await ApplyApi( api, key ).ConfigureAwait( true );
                }
                else {
                    MessageBox.Show( "Wrong pass", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }

        private async Task ApplyApi( IAdminApi api, string key ) {
            ApiKey = key;
            _api = api;
            SetControls(true);
            await UpdateProcesses().ConfigureAwait( true );
        }

        private void SetControls( bool enabled ) {
            tabControl.Enabled = enabled;
            smenuSettions.Enabled = enabled;
            smenuAddNewItem.Enabled = enabled;
        }

        private async Task UpdateProcesses() { dgvProcessList.DataSource = await _api.Process.ListFull().ConfigureAwait( true ); }

        private void smenuAddNewItem_Click( object sender, EventArgs e ) => new FrmAdd().ShowDialog();

    }

}