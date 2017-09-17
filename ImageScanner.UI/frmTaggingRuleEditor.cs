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
    public partial class frmTaggingRuleEditor : Form
    {
        public frmTaggingRuleEditor()
        {
            InitializeComponent();

            pnlRules.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);

            RuleConditionControl_AddRuleClicked(this, new EventArgs());

            errorProvider.RequiresNonEmptyText(txbRuleName);
            errorProvider.RequiresNonEmptyText(cmbTagRuleName);
        }

        private void RuleConditionControl_AddRuleClicked(object sender, EventArgs e)
        {
            var control = new RuleConditionControl()
            {
                Dock = DockStyle.Fill,
                ErrorProvider = errorProvider,
            };
            control.AddRuleClicked += RuleConditionControl_AddRuleClicked;
            control.RemoveRuleClicked += RuleConditionControl_RemoveRuleClicked;
            pnlRules.Controls.Add(control);
        }

        private void RuleConditionControl_RemoveRuleClicked(object sender, EventArgs e)
        {
            if (pnlRules.Controls.Count > 1)
            {
                var control = (Control)sender;
                pnlRules.Controls.Remove(control);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
