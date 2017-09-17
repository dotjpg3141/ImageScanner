using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace ImageScanner.TaggingSystem
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
