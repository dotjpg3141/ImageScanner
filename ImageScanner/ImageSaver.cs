using ImageScanner.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace ImageScanner
{
    public class ImageSaver
    {
        private const string DateTimeFormat = "yyyy-MM-dd-HH-mm-ss";
        private const string IdFormat = "0000";

        public Config Settings { get; set; }

        public void Save(List<Bitmap> images)
        {
            int id = 0;
            var imageInfos = images.ToDictionary(
                img => img,
                img => new ImageInfo()
                {
                    Created = DateTime.Now,
                    ID = ++id,
                    Format = Settings.GetImageFormat(),
                });

            RunOcr(imageInfos);
            Foreach(imageInfos.Values, RunTagging);
            Foreach(imageInfos.Values, RunResolvePath);
            Foreach(imageInfos, RunSaveImage);
            Foreach(imageInfos.Values, RunSaveText);
        }

        private void RunOcr(Dictionary<Bitmap, ImageInfo> imageInfos)
        {
            using (var ocr = new OCR(Settings.OcrDataFolder, Settings.OcrLanguage))
            {
                foreach (var kvp in imageInfos)
                {
                    var image = kvp.Key;
                    var info = kvp.Value;
                    info.Text = ocr.ExtractText(image);
                }
            }
        }

        private void RunTagging(ImageInfo imageInfo)
        {
            var matchedRule = Settings.Tagging.FirstOrDefault(rule => rule.Matches(imageInfo));
            imageInfo.Tag = matchedRule?.Tag ?? "default";
        }

        private void RunResolvePath(ImageInfo imageInfo)
        {
            string imageExtension = GetFileExtensionFromEncoder(imageInfo.Format);
            imageInfo.ImageFilePath = ResolvePath(imageInfo, imageExtension);
            imageInfo.TextFilePath = ResolvePath(imageInfo, "txt");
        }

        private string ResolvePath(ImageInfo imageInfo, string extension)
        {
            var path = new StringBuilder(Settings.OutputFormatName);
            path.Replace("%tag%", imageInfo.Tag);
            path.Replace("%datetime%", imageInfo.Created.ToString(DateTimeFormat));
            path.Replace("%id%", imageInfo.ID.ToString(IdFormat));
            path.Replace("%ext%", extension);
            return Path.Combine(Settings.OutputDirectory, path.ToString());
        }

        private void RunSaveImage(KeyValuePair<Bitmap, ImageInfo> kvp)
        {
            var image = kvp.Key;
            var imageInfo = kvp.Value;

            Directory.CreateDirectory(Directory.GetParent(imageInfo.ImageFilePath).FullName);
            image.Save(imageInfo.ImageFilePath, imageInfo.Format);
        }

        private void RunSaveText(ImageInfo imageInfo)
        {
            Directory.CreateDirectory(Directory.GetParent(imageInfo.TextFilePath).FullName);
            File.WriteAllText(imageInfo.TextFilePath, imageInfo.Text);
        }

        private static void Foreach<T>(IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }

        public static string GetFileExtensionFromEncoder(ImageFormat format)
        {
            // https://stackoverflow.com/a/17979245
            try
            {
                return ImageCodecInfo.GetImageEncoders()
                        .First(x => x.FormatID == format.Guid)
                        .FilenameExtension
                        .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .First()
                        .Trim('*', '.')
                        .ToLower();
            }
            catch (Exception)
            {
                return format.ToString().ToLower();
            }
        }
    }
}
