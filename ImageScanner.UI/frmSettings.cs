using ImageScanner.Settings;
using System;
using System.Windows.Forms;

namespace ImageScanner.UI
{
    public partial class frmSettings : Form
    {
        public Config Settings
        {
            get => (Config)propertyGrid1.SelectedObject;
            set => propertyGrid1.SelectedObject = value;
        }

        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnRestoreDefaultSettings_Click(object sender, EventArgs e)
        {
            Settings = new Config();
        }
    }
}
