using System;
using System.Drawing;
using Tesseract;

namespace ImageScanner
{
    public class OCR : IDisposable
    {
        public String TestDataFolder { get; }
        public String Language { get; }

        public TesseractEngine Engine { get; }

        public OCR(string testDataFolder, string language)
        {
            Engine = new TesseractEngine(testDataFolder, language);
        }

        public string ExtractText(Bitmap image)
        {
            using (var page = Engine.Process(image))
            {
                return page.GetText();
            }
        }

        public void Dispose()
        {
            Engine.Dispose();
        }
    }
}
