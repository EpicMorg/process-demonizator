using System.Windows.Forms;
using PD.UI.Shared;

namespace process_demonizator.UI {

    public sealed partial class FrmAdd : Form {

        public FrmAdd() {
            InitializeComponent();
            InitializeComponent();
            Text = @"Add new item :: " + InfoHelper.NameVersion;
        }
    }

}