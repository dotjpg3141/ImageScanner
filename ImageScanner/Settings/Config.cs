using ImageScanner.TaggingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TwainDotNet;

namespace ImageScanner.Settings
{
    public class Config : ICloneable
    {
        [Category("Scan")] public bool UseDocumentFeeder { get; set; }
        [Category("Scan")] public bool ShowTwainUI { get; set; }
        [Category("Scan")] public bool ShowProgressIndicatorUI { get; set; }
        [Category("Scan")] public bool UseDuplex { get; set; }
        [Category("Scan")] public Resolution Resolution { get; set; }
        [Category("Scan")] public bool AutomaticRotate { get; set; }
        [Category("Scan")] public bool AutomaticBorderDetection { get; set; }

        [Editor(typeof(FolderNameEditor2), typeof(System.Drawing.Design.UITypeEditor))]
        [Category("Output")]
        public string OutputDirectory { get; set; }
        [Category("Output")] public string OutputFormatName { get; set; }
        [Category("Output")] public ImageOutputFormat ImageOutputFormat { get; set; }
        [Category("Output")] public TaggingRule[] Tagging { get; set; }

        [Editor(typeof(FolderNameEditor2), typeof(System.Drawing.Design.UITypeEditor))]
        [Category("OCR")]
        public string OcrDataFolder { get; set; }
        [Category("OCR")] public string OcrLanguage { get; set; }

        public Config()
        {
            this.UseDocumentFeeder = false;
            this.ShowTwainUI = false;
            this.ShowProgressIndicatorUI = false;
            this.UseDuplex = false;
            this.Resolution = Resolution.ColourPhotocopier;
            this.AutomaticRotate = true;
            this.AutomaticBorderDetection = true;

            this.OutputDirectory = @".\Scans";
            this.OutputFormatName = @"%tag%\%datetime%_%tag%_%id%.%ext%";
            this.Tagging = new TaggingRule[0];
            this.ImageOutputFormat = ImageOutputFormat.Jpeg;

            this.OcrDataFolder = @".\tessdata";
            this.OcrLanguage = "eng";
        }

        public ScanSettings GenerateScanSettings()
        {
            return new ScanSettings()
            {
                UseDocumentFeeder = this.UseDocumentFeeder,
                ShowTwainUI = this.ShowTwainUI,
                ShowProgressIndicatorUI = this.ShowProgressIndicatorUI,
                UseDuplex = this.UseDuplex,
                Resolution = this.Resolution == Resolution.ColourPhotocopier ? ResolutionSettings.ColourPhotocopier :
                             this.Resolution == Resolution.Photocopier ? ResolutionSettings.Photocopier :
                             this.Resolution == Resolution.Fax ? ResolutionSettings.Fax :
                             throw new InvalidOperationException("unexpected Resolution enum value"),
                Rotation = new RotationSettings()
                {
                    AutomaticBorderDetection = this.AutomaticBorderDetection,
                    AutomaticRotate = this.AutomaticRotate,
                },
            };
        }

        public ImageFormat GetImageFormat()
        {
            switch (ImageOutputFormat)
            {
                case ImageOutputFormat.Bmp: return ImageFormat.Bmp;
                case ImageOutputFormat.Png: return ImageFormat.Png;
                case ImageOutputFormat.Jpeg: return ImageFormat.Jpeg;
                case ImageOutputFormat.Tiff: return ImageFormat.Tiff;
                default: throw new InvalidOperationException("invalid enum ImageOutputFormat");
            }
        }

        public static Config LoadFromFile(string file)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));
            using (var reader = new FileStream(file, FileMode.Open))
            {
                return (Config)xmlSerializer.Deserialize(reader);
            }
        }

        public void SaveToFile(string file)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));
            using (var writer = new FileStream(file, FileMode.Create))
            {
                xmlSerializer.Serialize(writer, this);
            }
        }

        public Config Clone()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));
            using (var memory = new MemoryStream())
            {
                xmlSerializer.Serialize(memory, this);
                memory.Position = 0;
                return (Config)xmlSerializer.Deserialize(memory);
            }
        }

        object ICloneable.Clone() => this.Clone();
    }

    public enum Resolution
    {
        Fax,
        Photocopier,
        ColourPhotocopier,
    }

    public enum ImageOutputFormat
    {
        Bmp, Png, Jpeg, Tiff
    }

}
