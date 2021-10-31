using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SideyUtils.Drawing.Blending
{
    /// <summary>
    /// Represents a region to blend the image onto.
    /// </summary>
    public class BlendRegion
    {
        /// <summary>
        /// The destination image
        /// </summary>
        public Floatmap DstImage { get; }

        /// <summary>
        /// The Region.
        /// </summary>
        public Region Region { get; }

        public int X => Region.X;
        public int Y => Region.Y;
        public int Width => Region.Width;
        public int Height => Region.Height;

        public int ImgWidth => DstImage.Width;
        public int ImgHeight => DstImage.Height;

        /// <summary>
        /// Creates a BlendRegion with the specified destination image and region.
        /// </summary>
        /// <param name="dstImage"></param>
        /// <param name="region"></param>
        public BlendRegion(Floatmap dstImage, Region region)
        {
            DstImage = dstImage;
            Region = region;
        }

        /// <summary>
        /// Creates a BlendRegion with the specified destination image and region set to the size of the image.
        /// </summary>
        /// <param name="dstImage"></param>
        public BlendRegion(Floatmap dstImage) : this(dstImage, new Region(0, 0, dstImage.Width, dstImage.Height))
        {
        }
    }

    /// <summary>
    /// Enum for Blending Modes
    /// </summary>
    public enum BlendMode
    {
        Normal,
        Overlay,
        Multiply,
        Add,
        Subtract,
    }

    /// <summary>
    /// Enum for the CompositingOrder
    /// </summary>
    public enum CompositingOrder
    {
        Above,
        Below,
    }

    /// <summary>
    /// Static resource to blend Floatmap objects together
    /// </summary>
    public static class SideyBlender
    {
        private const float SCALE = 1.0f / 255.0f;

        private static Dictionary<BlendMode, BlendingMode> _blendingModes = new Dictionary<BlendMode, BlendingMode>()
        {
            { BlendMode.Normal, new BlendingModeNormal() },
            { BlendMode.Overlay, new BlendingModeOverlay() },
            { BlendMode.Multiply, new BlendingModeMultiply() },
            { BlendMode.Add, new BlendingModeAdd() },
            { BlendMode.Subtract, new BlendingModeSubtract() },
        };

        /// <summary>
        /// Blend the src Floatmap onto the given dst Region with the given CompositingOrder and BlendMode.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public static unsafe void Blend(Floatmap src, BlendRegion dst, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
        {
            if (src.Width < dst.Width || src.Height < dst.Height)
            {
                throw new ArgumentOutOfRangeException("src");
            }

            Vector4* sStartPtr = src.StartPtr;
            Vector4* dStartPtr = dst.DstImage.StartPtr;

            var blendingMode = _blendingModes[blendMode];

            for (int y = 0; y < src.Height; y++)
            {
                int ySrc = y * src.Width;
                int yDst = (y + dst.Y) * dst.ImgWidth;

                for (int x = 0; x < src.Width; x++)
                {
                    int srcPos = x + ySrc;
                    int dstPos = x + dst.X + yDst;

                    Vector4* srcPtr = sStartPtr + srcPos;
                    Vector4* dstPtr = dStartPtr + dstPos;

                    if (order == CompositingOrder.Above)
                    {
                        blendingMode.Blend(srcPtr, dstPtr, dstPtr);
                    }
                    else
                    {
                        blendingMode.Blend(dstPtr, srcPtr, dstPtr);
                    }
                }
            }
        }

        /// <summary>
        /// Blend the src Floatmap onto the given dst Floatmap in the given Region with the given CompositingOrder and BlendMode.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public static void Blend(Floatmap src, Floatmap dst, Region region, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => Blend(src, new BlendRegion(dst, region), order, blendMode);

        /// <summary>
        /// Blends the specified (Vector4) color onto the dst region.
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="color"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public static unsafe void BlendColor(Vector4 color, BlendRegion dst, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
        {
            Vector4* dStartPtr = dst.DstImage.StartPtr;

            var blendingMode = _blendingModes[blendMode];

            for (int y = dst.Y; y < dst.Height; y++)
            {
                int yPos = y * dst.Width;

                for (int x = dst.X; x < dst.Width; x++)
                {
                    int pos = x + yPos;

                    if (pos < 0 || pos >= dst.DstImage.Length)
                    {
                        continue;
                    }

                    Vector4* dstPtr = dStartPtr + pos;

                    if (order == CompositingOrder.Above)
                    {
                        *dstPtr = blendingMode.Blend(color, *dstPtr);
                    }
                    else
                    {
                        *dstPtr = blendingMode.Blend(*dstPtr, color);
                    }
                }
            }
        }

        /// <summary>
        /// Blend the specified Color onto the given dst Floatmap in the given Region with the given CompositingOrder and BlendMode.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public static void BlendColor(Vector4 color, Floatmap dst, Region region, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => BlendColor(color, new BlendRegion(dst, region), order, blendMode);

        /// <summary>
        /// Blends the specified (System.Drawing.Color) color onto the dst region.
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="color"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public static unsafe void BlendColor(System.Drawing.Color color, BlendRegion dst, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => BlendColor(new Vector4(color.B, color.G, color.R, color.A) * SCALE, dst, order, blendMode);


        /// <summary>
        /// Blend the specified Color onto the given dst Floatmap in the given Region with the given CompositingOrder and BlendMode.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public static void BlendColor(System.Drawing.Color color, Floatmap dst, Region region, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => BlendColor(new Vector4(color.B, color.G, color.R, color.A) * SCALE, new BlendRegion(dst, region), order, blendMode);

        /// <summary>
        /// Blend the specified Color onto the entire given dst Floatmap with the given CompositingOrder and BlendMode.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public static void BlendColor(System.Drawing.Color color, Floatmap dst, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => BlendColor(color, new BlendRegion(dst), order, blendMode);

        /// <summary>
        /// Blend the specified color (Vector4) onto the entire given dst Floatmap with the given CompositingOrder and BlendMode.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public static void BlendColor(Vector4 color, Floatmap dst, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => BlendColor(color, new BlendRegion(dst), order, blendMode);
    }
}
