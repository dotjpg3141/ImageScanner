namespace ImageScanner.UI
{
    partial class frmTaggingRuleEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbRuleName = new System.Windows.Forms.TextBox();
            this.cmbTagRuleName = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rdbAllConditions = new System.Windows.Forms.RadioButton();
            this.rdbAnyCondition = new System.Windows.Forms.RadioButton();
            this.rdbNoCondition = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlRules = new System.Windows.Forms.TableLayoutPanel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txbRuleName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbTagRuleName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.pnlRules, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(548, 398);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rule Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tagging Rule";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbRuleName
            // 
            this.txbRuleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbRuleName.Location = new System.Drawing.Point(80, 3);
            this.txbRuleName.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.txbRuleName.Name = "txbRuleName";
            this.txbRuleName.Size = new System.Drawing.Size(438, 20);
            this.txbRuleName.TabIndex = 2;
            // 
            // cmbTagRuleName
            // 
            this.cmbTagRuleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTagRuleName.FormattingEnabled = true;
            this.cmbTagRuleName.Location = new System.Drawing.Point(80, 29);
            this.cmbTagRuleName.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.cmbTagRuleName.Name = "cmbTagRuleName";
            this.cmbTagRuleName.Size = new System.Drawing.Size(438, 21);
            this.cmbTagRuleName.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.rdbAllConditions);
            this.flowLayoutPanel1.Controls.Add(this.rdbAnyCondition);
            this.flowLayoutPanel1.Controls.Add(this.rdbNoCondition);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 56);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(542, 23);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // rdbAllConditions
            // 
            this.rdbAllConditions.AutoSize = true;
            this.rdbAllConditions.Location = new System.Drawing.Point(3, 3);
            this.rdbAllConditions.Name = "rdbAllConditions";
            this.rdbAllConditions.Size = new System.Drawing.Size(140, 17);
            this.rdbAllConditions.TabIndex = 0;
            this.rdbAllConditions.Text = "All conditions must apply";
            this.rdbAllConditions.UseVisualStyleBackColor = true;
            // 
            // rdbAnyCondition
            // 
            this.rdbAnyCondition.AutoSize = true;
            this.rdbAnyCondition.Checked = true;
            this.rdbAnyCondition.Location = new System.Drawing.Point(149, 3);
            this.rdbAnyCondition.Name = "rdbAnyCondition";
            this.rdbAnyCondition.Size = new System.Drawing.Size(174, 17);
            this.rdbAnyCondition.TabIndex = 1;
            this.rdbAnyCondition.TabStop = true;
            this.rdbAnyCondition.Text = "At least on condition must apply";
            this.rdbAnyCondition.UseVisualStyleBackColor = true;
            // 
            // rdbNoCondition
            // 
            this.rdbNoCondition.AutoSize = true;
            this.rdbNoCondition.Location = new System.Drawing.Point(329, 3);
            this.rdbNoCondition.Name = "rdbNoCondition";
            this.rdbNoCondition.Size = new System.Drawing.Size(138, 17);
            this.rdbNoCondition.TabIndex = 2;
            this.rdbNoCondition.Text = "No condition must apply";
            this.rdbNoCondition.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel2, 2);
            this.flowLayoutPanel2.Controls.Add(this.btnCancel);
            this.flowLayoutPanel2.Controls.Add(this.btnOk);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 366);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(542, 29);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(464, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(383, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pnlRules
            // 
            this.pnlRules.AutoScroll = true;
            this.pnlRules.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlRules.ColumnCount = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.pnlRules, 2);
            this.pnlRules.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRules.Location = new System.Drawing.Point(3, 85);
            this.pnlRules.Name = "pnlRules";
            this.pnlRules.RowCount = 1;
            this.pnlRules.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlRules.Size = new System.Drawing.Size(542, 275);
            this.pnlRules.TabIndex = 7;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmTaggingRuleEditor
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(548, 398);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmTaggingRuleEditor";
            this.Text = "Tagging Rule";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbRuleName;
        private System.Windows.Forms.ComboBox cmbTagRuleName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rdbAllConditions;
        private System.Windows.Forms.RadioButton rdbAnyCondition;
        private System.Windows.Forms.RadioButton rdbNoCondition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TableLayoutPanel pnlRules;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}