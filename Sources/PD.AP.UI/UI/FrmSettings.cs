using System.Windows.Forms;
using PD.UI.Shared;

namespace process_demonizator.UI {

    public sealed partial class FrmSettings : Form {

        public FrmSettings() {
            InitializeComponent();
            Text = $@"Settings :: {InfoHelper.NameVersion}";
        }

    }

}