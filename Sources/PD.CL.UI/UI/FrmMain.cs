using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using process_demonizator.UI;
using PD.UI.Shared;
using System.Threading.Tasks;
using PD.Api.Client;
using PD.Api.DataTypes;

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
            using ( var cf = new frmConnect() ) if ( cf.ShowDialog() == DialogResult.OK ) await Connect( cf.Server ).ConfigureAwait( true );
        }

        private async Task Connect( string server ) {
            _api = new ClientApi( server );
            _keys = new Dictionary<int, string>();
            await UpdateServers().ConfigureAwait( true );
        }

        private async Task UpdateServers() => dgvProcessList.DataSource = await _api.Process.List().ConfigureAwait( true );

        private void dgvProcessList_DataSourceChanged_1( object sender, EventArgs e ) {
            foreach ( DataGridViewRow row in dgvProcessList.Rows )
                UpdateRowMenu( row );
        }

        private void UpdateRowMenu( DataGridViewRow row ) { row.ContextMenuStrip = _keys.ContainsKey( ( (DemonizedProcessBase) row.DataBoundItem ).Id ) ? cmProcess : cmUnlock; }

        private async void unlockToolStripMenuItem_Click( object sender, EventArgs e ) {
            var o = sender;
            var row = GetMenuRow( o );
            var source = row?.DataBoundItem as DemonizedProcessBase;

            if ( source == null ) return;
            using ( var form = new frmUnlock() ) {
                form.Process = source;
                if ( form.ShowDialog() != DialogResult.OK )
                    return;
                if ( await _api.Process.CheckPassword( source.Id, form.Password ).ConfigureAwait( true ) ) {
                    _keys.Add( source.Id, form.Password );
                    UpdateRowMenu( row );
                }
            }
        }

        private static DataGridViewRow GetMenuRow( object o )
            => ( ( ( o as ToolStripItem )?.Owner as ContextMenuStrip )?.SourceControl as DataGridView )?.SelectedRows?.OfType<DataGridViewRow>()?.FirstOrDefault();

        private async void FrmMain_Load( object sender, EventArgs e ) {
//#if DEBUG
//            await Connect( "http://localhost:31337" ).ConfigureAwait( true );
//#endif
        }

        private async void startToolStripMenuItem_Click( object sender, EventArgs e ) {
            var row = GetMenuRow( sender );
            var source = row?.DataBoundItem as DemonizedProcessBase;
            if ( source == null ) return;
            await _api.Process.Start( source.Id, _keys[ source.Id ] ).ConfigureAwait( true );
        }

        private async void restartToolStripMenuItem_Click( object sender, EventArgs e ) {
            var row = GetMenuRow( sender );
            var source = row?.DataBoundItem as DemonizedProcessBase;
            if ( source == null ) return;
            await _api.Process.Restart( source.Id, _keys[ source.Id ] ).ConfigureAwait( true );
        }

        private async void stopToolStripMenuItem_Click( object sender, EventArgs e ) {
            var row = GetMenuRow( sender );
            var source = row?.DataBoundItem as DemonizedProcessBase;
            if ( source == null ) return;
            await _api.Process.Stop( source.Id, _keys[ source.Id ] ).ConfigureAwait( true );
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show(
                @"Fuck you 
Fuck the plane you flew in on 
Fuck them shoes 
Fuck them socks with the belt on it 
Fuck your gay ass fairy faggot accent 
Fuck them cheap ass cigars 
Fuck your yuck mouth teeth 
Fuck your hair piece 
Fuck your chocolate 
Fuck Guy Ritchie 
Fuck Prince William
Fuck the Queen 
This is America 
My President is black and my lambo is blue nigga
Now get the fuck outta my hotel room 
And if I see you in the street 
I'm slapping the shit out of you",
                "Not implemented",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly,
                false );
        }
    }

}