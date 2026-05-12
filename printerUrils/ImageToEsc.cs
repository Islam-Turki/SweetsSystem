using sweetSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sweetSystem
{
    public static class EscPosImage
    {
        public static byte[] ToRaster(byte[] imageBytes)
        {
            using (var ms = new MemoryStream(imageBytes))
            using (var bmp = new Bitmap(ms))
            using (var msOut = new MemoryStream())
            {
                int width = bmp.Width;
                int height = bmp.Height;

                byte[] init = new byte[] { 0x1B, 0x40 }; // ESC @

                msOut.Write(init, 0, init.Length);

                // Print image command (GS v 0)
                msOut.Write(new byte[]
                {
                0x1D, 0x76, 0x30, 0x00,
                (byte)(width / 8), 0x00,
                (byte)(height % 256), (byte)(height / 256)
                }, 0, 8);

                // Bitmap data (simple 1-bit conversion)
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x += 8)
                    {
                        byte slice = 0;

                        for (int b = 0; b < 8; b++)
                        {
                            if (x + b < width)
                            {
                                Color c = bmp.GetPixel(x + b, y);
                                if (c.R < 128) // black pixel
                                    slice |= (byte)(1 << (7 - b));
                            }
                        }

                        msOut.WriteByte(slice);
                    }
                }

                return msOut.ToArray();
            }
        }
    }
}
