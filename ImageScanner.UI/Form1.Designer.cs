namespace ImageScanner.UI
{
    partial class frmMain
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
            this.btnScanImage = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlScannedImages = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOpenOutputFolder = new System.Windows.Forms.Button();
            this.btnTaggingRules = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnScanImage
            // 
            this.btnScanImage.Location = new System.Drawing.Point(11, 5);
            this.btnScanImage.Name = "btnScanImage";
            this.btnScanImage.Size = new System.Drawing.Size(86, 23);
            this.btnScanImage.TabIndex = 0;
            this.btnScanImage.Text = "Scan Image";
            this.btnScanImage.UseVisualStyleBackColor = true;
            this.btnScanImage.Click += new System.EventHandler(this.btnScanImage_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(287, 5);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(86, 23);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pnlScannedImages
            // 
            this.pnlScannedImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlScannedImages.AutoScroll = true;
            this.pnlScannedImages.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlScannedImages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlScannedImages.Location = new System.Drawing.Point(12, 32);
            this.pnlScannedImages.Name = "pnlScannedImages";
            this.pnlScannedImages.Size = new System.Drawing.Size(760, 517);
            this.pnlScannedImages.TabIndex = 3;
            this.pnlScannedImages.Resize += new System.EventHandler(this.pnlScannedImages_Resize);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnScanImage);
            this.flowLayoutPanel1.Controls.Add(this.btnOpenOutputFolder);
            this.flowLayoutPanel1.Controls.Add(this.btnTaggingRules);
            this.flowLayoutPanel1.Controls.Add(this.btnSettings);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(784, 31);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnOpenOutputFolder
            // 
            this.btnOpenOutputFolder.Location = new System.Drawing.Point(103, 5);
            this.btnOpenOutputFolder.Name = "btnOpenOutputFolder";
            this.btnOpenOutputFolder.Size = new System.Drawing.Size(86, 23);
            this.btnOpenOutputFolder.TabIndex = 3;
            this.btnOpenOutputFolder.Text = "Output Folder";
            this.btnOpenOutputFolder.UseVisualStyleBackColor = true;
            // 
            // btnTaggingRules
            // 
            this.btnTaggingRules.Location = new System.Drawing.Point(195, 5);
            this.btnTaggingRules.Name = "btnTaggingRules";
            this.btnTaggingRules.Size = new System.Drawing.Size(86, 23);
            this.btnTaggingRules.TabIndex = 4;
            this.btnTaggingRules.Text = "Tagging Rules";
            this.btnTaggingRules.UseVisualStyleBackColor = true;
            this.btnTaggingRules.Click += new System.EventHandler(this.btnTaggingRules_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlScannedImages);
            this.Name = "frmMain";
            this.Text = "Image Scanner";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScanImage;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.FlowLayoutPanel pnlScannedImages;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnOpenOutputFolder;
        private System.Windows.Forms.Button btnTaggingRules;
    }
}

