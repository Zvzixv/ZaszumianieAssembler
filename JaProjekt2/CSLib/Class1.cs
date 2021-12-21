using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


    namespace CSLib
    {
        public class Class1
        {/*
            Bitmap bitmapa;
            int stopien;
            int beginColumn;
            int endColumn;
            Random random;
            bool finish;
            BitmapData bitmapData;
            PararelBitmap pb;
            bool isAsm;

            public void ZaszumCSharp()
            {
                byte old1, old2, old3;
                byte wyn1, wyn2, wyn3;
                int randd;

                for (int y = 0; y < pb.Height; y++)
                {
                    int currentLine = y * (pb.Width * pb.BytesPerPixel);
                    for (int x = beginColumn; x < endColumn; x++)
                    {
                        int currentPixel = currentLine + (x * pb.BytesPerPixel);
                        old1 = pb.Pixels[currentPixel];
                        old2 = pb.Pixels[currentPixel + 1];
                        old3 = pb.Pixels[currentPixel + 2];

                        wyn1 = (byte)random.Next(256);
                        wyn2 = (byte)random.Next(256);
                        wyn3 = (byte)random.Next(256);

                        // calculate new pixel value
                        pb.Pixels[currentPixel] = (byte)old1;
                        pb.Pixels[currentPixel + 1] = (byte)old2;
                        pb.Pixels[currentPixel + 2] = (byte)old3;

                        wyn1 = (byte)(wyn1 ^ old1);
                        wyn2 = (byte)(wyn2 ^ old2);
                        wyn3 = (byte)(wyn3 ^ old3);
                        randd = ((wyn1 + wyn2) * wyn3) % 100;
                        if (randd < stopien)
                        {
                            pb.Pixels[currentPixel] = wyn1;
                            pb.Pixels[currentPixel + 1] = wyn2;
                            pb.Pixels[currentPixel + 2] = wyn3;
                        }
                    }
                }

                finish = true;

            }
        */
        }
    }

