﻿using ImageScanner.TaggingSystem;
using System;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ImageScanner.UI
{
    public partial class RuleConditionControl : UserControl
    {

        public event EventHandler AddRuleClicked;
        public event EventHandler RemoveRuleClicked;

        private ErrorProvider _ErrorProvider;

        public ErrorProvider ErrorProvider
        {
            get { return _ErrorProvider; }
            set
            {
                if (_ErrorProvider != value)
                {
                    _ErrorProvider = value;
                    RefreshErrorConditions();
                }
            }
        }

        private Condition Condition;
        public Condition SelectedCondition
        {
            get => Condition;
            set
            {
                Condition = value ?? ((RuleConditionItem)cmbRuleType.Items[0]).Instantiate();

                cmbRuleType.SelectedItem = cmbRuleType.Items.Cast<RuleConditionItem>()
                    .FirstOrDefault(item => item.Type == Condition.GetType());

                txbRuleInput.Text = Condition.GetAsString();
            }
        }

        public RuleConditionControl()
        {
            InitializeComponent();

            var ruleItems = from type in TaggingRule.AvailableConditions
                            let descr = type.GetCustomAttribute<RuleConditionAttribute>().Description
                            select new RuleConditionItem()
                            {
                                Description = descr,
                                Type = type,
                            };

            cmbRuleType.Items.Clear();
            cmbRuleType.Items.AddRange(ruleItems.ToArray());

            SelectedCondition = null;
        }

        private void txbRuleInput_TextChanged(object sender, EventArgs e)
        {
            Condition.ApplyFromString(txbRuleInput.Text);
            RefreshErrorConditions();
        }

        private void RefreshErrorConditions()
        {
            if (ErrorProvider != null)
            {
                ErrorProvider.SetError(txbRuleInput, !Condition.IsValid(), "Invalid Condition");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) => AddRuleClicked?.Invoke(this, e);
        private void btnRemove_Click(object sender, EventArgs e) => RemoveRuleClicked?.Invoke(this, e);

        private class RuleConditionItem
        {
            public string Description { get; set; }
            public Type Type { get; set; }

            public override string ToString()
            {
                return Description;
            }

            public Condition Instantiate()
            {
                return (Condition)Activator.CreateInstance(Type);
            }
        }
    }
}
