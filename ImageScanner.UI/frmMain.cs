using ImageScanner.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwainDotNet;
using TwainDotNet.WinFroms;

namespace ImageScanner.UI
{
    public partial class frmMain : Form
    {
        private static readonly string SettingsFile = "settings.xml";

        private ImageScan scanner;
        private Config settings;

        public frmMain()
        {
            InitializeComponent();

            scanner = new ImageScan(new WinFormsWindowMessageHook(this));

            LoadSettings();

        }

        private void btnScanImage_Click(object sender, EventArgs e)
        {
            ScanImages();
        }

        private void ScanImages()
        {
            pnlScannedImages.Controls.Clear();

            this.Enabled = false;
            try
            {
                scanner.ScanImages(settings.GenerateScanSettings(), onCompleted: (images) =>
                {
                    SaveImages(images);
                    DisplayImages(images);
                    this.Enabled = true;
                });

            }
            catch (Exception ex)
            {
                LogError("Error while scanning", ex);
                this.Enabled = true;
            }
        }

        private void SaveImages(List<Bitmap> images)
        {
            try
            {
                var imageSaver = new ImageSaver() { Settings = settings };
                imageSaver.Save(images);
            }
            catch (IOException ex)
            {
                LogError("Error while saving the images", ex);
            }
            catch (Exception ex)
            {
                LogError(exception: ex);
            }
        }

        private void DisplayImages(List<Bitmap> images)
        {
            foreach (var image in images)
            {
                pnlScannedImages.Controls.Add(new PictureBox()
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = Padding.Empty,
                });
            }

            UpdateImageListChildSize();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var frmSettings = new frmSettings();
            frmSettings.Settings = settings.Clone();
            if (frmSettings.ShowDialog() == DialogResult.OK)
            {
                settings = frmSettings.Settings;

                SaveSettings();

            }
        }

        private void btnTaggingRules_Click(object sender, EventArgs e)
        {
            var frmTaggingRules = new frmTaggingRuleEditor();
            if (frmTaggingRules.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private static void LogError(string message = null, Exception exception = null)
        {

            message = message ?? "Unexpected Exception";
            var exMsg = exception?.ToString() ?? "";
            string outputMessage = $"ERROR: {message} {exMsg}";

            Console.WriteLine(outputMessage);
            MessageBox.Show(outputMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void pnlScannedImages_Resize(object sender, EventArgs e)
        {
            UpdateImageListChildSize();
        }

        void UpdateImageListChildSize()
        {
            // FIXME: make proper list view
            foreach (PictureBox pbx in pnlScannedImages.Controls)
            {
                var ascpetRatio = (float)pbx.Image.Width / pbx.Image.Height;
                pbx.Width = pnlScannedImages.ClientSize.Width;
                pbx.Height = (int)(pbx.Width / ascpetRatio);
            }
            pnlScannedImages.Refresh();
        }

        private void LoadSettings()
        {
            try
            {
                settings = Config.LoadFromFile(SettingsFile);
            }
            catch (Exception ex)
            {
                LogError("Cannot read settings", ex);
                settings = new Config();

            }
        }

        private void SaveSettings()
        {
            try
            {
                settings.SaveToFile(SettingsFile);
            }
            catch (Exception ex)
            {
                LogError("Cannot save settings", ex);
            }
        }
    }
}
