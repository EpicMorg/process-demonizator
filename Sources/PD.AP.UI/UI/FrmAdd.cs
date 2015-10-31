using System;
using System.Diagnostics;
using System.Windows.Forms;
using PD.Api.DataTypes;
using PD.UI.Shared;

namespace process_demonizator.UI {
    public sealed partial class FrmAdd : Form {

        private readonly EventHandler _cmPriorityOnSelectedValueChanged;
        private PasswordedDemonizedProcess _model;

        public PasswordedDemonizedProcess Model
        {
            get { return _model; }
            set
            {
                _model = value;
                if ( value != null ) UpdateBindings();
            }
        }

        public FrmAdd() {
            //InitializeComponent();
            InitializeComponent();
            Text = @"Add new item :: " + InfoHelper.NameVersion;
            _cmPriorityOnSelectedValueChanged = ( sender, value ) => {
                if ( Model != null )
                    Model.Priority = (ProcessPriorityClass) cmPriority.SelectedItem;
            };
            Model = new PasswordedDemonizedProcess();
        }

        private void ClearBindings() {
            var controls = new Control[] { txtItemName, txtPassword, txtArgs, txtPathToExe, chckHideOnStart, chckReanimateProcess };
            foreach ( var control in controls )
                control.DataBindings.Clear();
            cmPriority.SelectedValueChanged -= _cmPriorityOnSelectedValueChanged;
        }

        private void UpdateBindings() {
            ClearBindings();
            if ( _model == null ) return;
            Action<Control, string> bind = ( control, property ) => control.DataBindings.Add( new Binding( nameof( control.Text ), _model, property ) );
            //txtItemName.DataBindings.Add( new Binding( nameof( txtItemName.Text ), _model, nameof(_model.Name ) ));
            bind( txtItemName, nameof( _model.Name ) );
            bind(txtPassword, nameof(_model.Key));
            bind(txtArgs, nameof(_model.Arguments));
            bind(txtPathToExe, nameof(_model.Path));
            
            chckHideOnStart.DataBindings.Add( nameof( chckHideOnStart.Checked ), _model, nameof(_model.HideOnStart ) );
            chckReanimateProcess.DataBindings.Add( nameof( chckReanimateProcess.Checked ), _model, nameof(_model.Autorestart ) );
            cmPriority.Items.Clear();
            var items = (ProcessPriorityClass[]) Enum.GetValues( typeof( ProcessPriorityClass ) );
            //cmPriority.Items.AddRange( items );
            foreach ( var item in items ) cmPriority.Items.Add( item );
            cmPriority.SelectedValueChanged += _cmPriorityOnSelectedValueChanged;
        }

        private void btnBrowse_Click( object sender, EventArgs e ) {
            if ( ofdPath.ShowDialog() != DialogResult.OK ) return;
            txtPathToExe.Text = ofdPath.FileName;
        }

        private void btnOK_Click( object sender, EventArgs e ) { }

    }

}