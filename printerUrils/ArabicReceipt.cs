using sweetSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Drawing.Text;

namespace sweetSystem
{


    public static class ArabicImagePrinter
    {
        public static byte[] CreateImageBytes(string text)
        {
            int width = 576; 

            Bitmap bmp = new Bitmap(width, 500);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            Font font = new Font("Arial", 18);
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Far // RIGHT for Arabic
            };

            g.DrawString(text, font, Brushes.Black, new RectangleF(0, 0, width, 500), format);

            g.Dispose();

            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

    }
}
