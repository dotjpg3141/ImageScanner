using ImageScanner.TaggingSystem;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ImageScanner.UI
{
    public partial class frmTaggingRuleEditor : Form
    {

        private TaggingRule _SelectedRule;
        public TaggingRule SelectedRule
        {
            get => _SelectedRule;
            set
            {
                _SelectedRule = value ?? new TaggingRule();

                txbRuleName.Text = SelectedRule.RuleName;
                cmbTagRuleName.Text = SelectedRule.Tag;

                ClearConditions();
                foreach (var condition in SelectedRule.Conditions)
                {
                    AddCondition(condition);
                }

                rdbAllConditions.Checked = SelectedRule.ConditionOperator == ConditionOperator.All;
                rdbAnyCondition.Checked = SelectedRule.ConditionOperator == ConditionOperator.Any;
                rdbNoCondition.Checked = SelectedRule.ConditionOperator == ConditionOperator.None;

                if (SelectedRule.Conditions.Count == 0)
                {
                    AddCondition();
                }

            }
        }

        public frmTaggingRuleEditor()
        {
            InitializeComponent();

            SelectedRule = null;

            pnlRules.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);

            RuleConditionControl_AddRuleClicked(this, new EventArgs());

            errorProvider.RequiresNonEmptyText(txbRuleName);
            errorProvider.RequiresNonEmptyText(cmbTagRuleName);

            this.AutoValidate = AutoValidate.Disable;
        }

        private void RuleConditionControl_AddRuleClicked(object sender, EventArgs e)
        {
            AddCondition();
        }

        void ClearConditions()
        {
            pnlRules.Controls.Clear();
        }

        void AddCondition(Condition condition = null)
        {
            var control = new RuleConditionControl()
            {
                Dock = DockStyle.Fill,
                ErrorProvider = errorProvider,
                SelectedCondition = condition,
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
            if (Validate() && ValidateChildren())
            {

                SelectedRule.Conditions = pnlRules.Controls.Cast<RuleConditionControl>().Select(c => c.SelectedCondition).ToList();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txbRuleName_TextChanged(object sender, EventArgs e)
        {
            SelectedRule.RuleName = txbRuleName.Text;
        }

        private void cmbTagRuleName_TextChanged(object sender, EventArgs e)
        {
            SelectedRule.Tag = cmbTagRuleName.Text;
        }

        private void rdbConditions_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                SelectedRule.ConditionOperator =
                    rdbAllConditions.Checked ? ConditionOperator.All :
                    rdbAnyCondition.Checked ? ConditionOperator.Any :
                    rdbNoCondition.Checked ? ConditionOperator.None :
                    throw new InvalidOperationException("unexpected radio button state");
            }

        }
    }
}
