using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageScanner
{
    public class ImageInfo
    {
        public int ID { get; set; }
        public DateTime Created { get; set; }
        public string Tag { get; set; }
        public ImageFormat Format { get; set; }

        public string ImageFilePath { get; set; }
        public string TextFilePath { get; set; }

        public Bitmap Image { get; set; }
        public string Text { get; set; }

    }
}
