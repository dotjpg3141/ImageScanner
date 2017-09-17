using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageScanner.UI
{
    public partial class frmSettings : Form
    {
        public Settings Settings
        {
            get => (Settings)propertyGrid1.SelectedObject;
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
            Settings = new Settings();
        }
    }
}
