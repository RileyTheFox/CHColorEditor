using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace SideyUtils.Drawing
{
    public class Floatmap : IDisposable
    {
        private struct Vec4b
        {
            public byte Item1, Item2, Item3, Item4;

            public Vec4b(byte item1, byte item2, byte item3, byte item4)
            {
                Item1 = item1;
                Item2 = item2;
                Item3 = item3;
                Item4 = item4;
            }
        }

        private const float SCALE = 1.0f / 255.0f;
        private const float INV_SCALE = 255.0f;

        private Vector4[] _pixels;

        public Vector4[] Pixels => _pixels;

        public unsafe Vector4* StartPtr
        {
            get
            {
                fixed (Vector4* p = &_pixels[0])
                {
                    return p;
                };
            }
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Length => _pixels.Length;

        public Floatmap(int width, int height)
        {
            if (width < 1 || height < 1)
            {
                throw new ArgumentException("width or height must be 1 or more");
            }

            _pixels = new Vector4[width * height];

            Width = width;
            Height = height;
        }

        public static Floatmap FromBitmap(Bitmap bitmapIn)
        {
            var bitmapData = bitmapIn.LockBits
            (
                new Rectangle(0, 0, bitmapIn.Width, bitmapIn.Height), 
                System.Drawing.Imaging.ImageLockMode.ReadOnly, 
                System.Drawing.Imaging.PixelFormat.Format32bppArgb
            );

            Floatmap output = new Floatmap(bitmapData.Width, bitmapData.Height);

            unsafe
            {
                Vec4b* colorPtr = (Vec4b*)bitmapData.Scan0.ToPointer();

                for (int i = 0; i < bitmapData.Height; i++)
                {
                    int y = i * bitmapData.Width;

                    for (int j = 0; j < bitmapData.Width; j++)
                    {
                        output._pixels[j + y] = new Vector4((*colorPtr).Item1, (*colorPtr).Item2, (*colorPtr).Item3, (*colorPtr).Item4) * SCALE;

                        colorPtr++;
                    }
                }
            }

            bitmapIn.UnlockBits(bitmapData);

            return output;
        }

        /// <summary>
        /// Gets a pixel at the defined location.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Vector4 GetPixel(int x, int y)
        {
            return this._pixels[x + (y * Width)];
        }

        public void SetPixel(int x, int y, Vector4 value)
        {
            this._pixels[x + (y * Width)] = value;
        }

        public void Dispose()
        {
            _pixels = null;

            GC.SuppressFinalize(this);
        }

        public static unsafe explicit operator Bitmap(Floatmap fm)
        {
            Bitmap bmp = new Bitmap(fm.Width, fm.Height);

            var bitmapData = bmp.LockBits
            (
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb
            );

            Vec4b* colorPtr = (Vec4b*)bitmapData.Scan0.ToPointer();

            for (int y = 0; y < bitmapData.Height; y++)
            {
                for (int x = 0; x < bitmapData.Width; x++)
                {
                    var pixel = fm.GetPixel(x, y) * INV_SCALE;

                    *colorPtr = new Vec4b((byte)pixel.X, (byte)pixel.Y, (byte)pixel.Z, (byte)pixel.W);

                    colorPtr++;
                }
            }

            bmp.UnlockBits(bitmapData);

            return bmp;
        }
    }
}
