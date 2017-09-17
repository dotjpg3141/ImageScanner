using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwainDotNet;
using TwainDotNet.TwainNative;

namespace ImageScanner
{
    // see also https://github.com/tmyroadctfig/twaindotnet/blob/master/src/TestApp/MainForm.cs

    public class ImageScan
    {
        public static AreaSettings DefaultAreaSettings = new AreaSettings(Units.Centimeters, 0.1f, 5.7f, 0.1F + 2.6f, 5.7f + 2.6f);

        public Twain Twain { get; }

        public ImageScan(IWindowsMessageHook messageHook)
        {
            Twain = new Twain(messageHook);
        }

        public void SelectSource()
        {
            Twain.SelectSource();
        }

        public void ScanImages(ScanSettings settings, Action<List<Bitmap>> onCompleted, int? maxPages = null)
        {
            List<Bitmap> result = new List<Bitmap>();

            Twain.TransferImage += Twain_TransferImage;
            Twain.ScanningComplete += Twain_ScanningComplete;

            Twain.StartScanning(settings);

            void Twain_TransferImage(object sender, TransferImageEventArgs e)
            {
                if (e.Image != null)
                {
                    result.Add(e.Image);
                }

                if (maxPages.HasValue)
                {
                    maxPages = maxPages.Value - 1;
                    e.ContinueScanning = maxPages.Value > 0;
                }
            }

            void Twain_ScanningComplete(object sender, ScanningCompleteEventArgs e)
            {
                Twain.TransferImage -= Twain_TransferImage;
                Twain.ScanningComplete -= Twain_ScanningComplete;

                onCompleted(result);
            }
        }
    }
}
