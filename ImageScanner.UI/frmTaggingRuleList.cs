using ImageScanner.TaggingSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ImageScanner.UI
{
    public partial class frmTaggingRuleList : Form
    {

        public List<TaggingRule> SelectedRuleList
        {
            get => lstRules.Items.Cast<TaggingRule>().ToList();
            set
            {
                lstRules.Items.Clear();
                lstRules.Items.AddRange(value.ToArray());
            }
        }

        public frmTaggingRuleList()
        {
            InitializeComponent();
            UpdateUI();
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

        void UpdateUI()
        {
            btnEdit.Enabled = lstRules.SelectedIndex >= 0;
            btnMoveDown.Enabled = lstRules.SelectedIndex >= 0 && lstRules.SelectedIndex != lstRules.Items.Count - 1;
            btnMoveUp.Enabled = lstRules.SelectedIndex >= 1;
            btnDelete.Enabled = lstRules.SelectedIndex >= 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (EditItem() is TaggingRule rule)
            {
                int index = lstRules.SelectedIndex < 0 ? lstRules.Items.Count : lstRules.SelectedIndex + 1;
                lstRules.Items.Insert(index, rule);
                lstRules.SelectedIndex = index;
                UpdateUI();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (EditItem((TaggingRule)lstRules.SelectedItem) is TaggingRule rule)
            {
                lstRules.Items[lstRules.SelectedIndex] = rule;
                UpdateUI();
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            SwapItems(lstRules.SelectedIndex, lstRules.SelectedIndex - 1);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            SwapItems(lstRules.SelectedIndex, lstRules.SelectedIndex + 1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lstRules.Items.RemoveAt(lstRules.SelectedIndex);
        }

        void SwapItems(int index1, int index2)
        {
            var item = lstRules.Items[index1];
            lstRules.Items[index1] = lstRules.Items[index2];
            lstRules.Items[index2] = item;
            lstRules.SelectedIndex = index2;
        }

        TaggingRule EditItem(TaggingRule rule = null)
        {
            var frm = new frmTaggingRuleEditor()
            {
                SelectedRule = rule,
            };

            return frm.ShowDialog() == DialogResult.OK ? frm.SelectedRule : null;
        }

        private void lstRules_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None && lstRules.Items.Count >= 2 && lstRules.SelectedItem != null)
            {
                this.lstRules.DoDragDrop(this.lstRules.SelectedItem, DragDropEffects.Move);
            }
        }

        private void lstRules_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lstRules_DragDrop(object sender, DragEventArgs e)
        {
            Point point = lstRules.PointToClient(new Point(e.X, e.Y));
            int index = this.lstRules.IndexFromPoint(point);
            if (index < 0)
            {
                index = this.lstRules.Items.Count - 1;
            }
            object data = lstRules.SelectedItem;
            this.lstRules.Items.Remove(data);
            this.lstRules.Items.Insert(index, data);
        }

        private void lstRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void lstRules_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
