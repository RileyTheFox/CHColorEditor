using SideyUtils.Drawing.Blending;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace SideyUtils.Drawing
{
    /// <summary>
    /// Represents a way to draw on the specified image.
    /// </summary>
    public class SideyGraphics
    {
        private Floatmap _dst;

        private SideyGraphics(Floatmap dstImage)
        {
            _dst = dstImage;
        }

        /// <summary>
        /// Creates a SideyGraphics object with the destination floatmap image.
        /// </summary>
        /// <param name="floatmap"></param>
        /// <returns></returns>
        public static SideyGraphics FromFloatmap(Floatmap floatmap)
        {
            return new SideyGraphics(floatmap);
        }

        /// <summary>
        /// Creates a SideyGraphics object with the destination bitmap image.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static SideyGraphics FromBitmap(Bitmap bitmap)
        {
            return FromFloatmap(Floatmap.FromBitmap(bitmap));
        }

        /// <summary>
        /// Draws the given src image.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="region"></param>
        /// <param name="drawOptions"></param>
        public void Draw(Floatmap src, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
        {
            SideyBlender.Blend(src, new BlendRegion(_dst, new Region(0, 0, src.Width, src.Height)), order, blendMode);
        }

        /// <summary>
        /// Draws the given src image at the specified region position.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="region"></param>
        /// <param name="drawOptions"></param>
        public void Draw(Floatmap src, Region region, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
        {
            SideyBlender.Blend(src, _dst, region, order, blendMode);
        }

        /// <summary>
        /// Draws the given src image at the specified Region Position.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="pos"></param>
        /// <param name="drawOptions"></param>
        public void Draw(Floatmap src, RegionPosition pos, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => Draw(src, new Region(pos.X, pos.Y, src.Width, src.Height), order, blendMode);

        /// <summary>
        /// Draws the given src image at the specified point.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="pos"></param>
        /// <param name="drawOptions"></param>
        public void Draw(Floatmap src, Point pos, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => Draw(src, new Region(pos.X, pos.Y, src.Width, src.Height), order, blendMode);

        /// <summary>
        /// Draws the given src image at the specified x and y position.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="drawOptions"></param>
        public void Draw(Floatmap src, int x, int y, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => Draw(src, new Region(x, y, src.Width, src.Height), order, blendMode);

        /// <summary>
        /// Draws the given src image at the specified x and y position and width and height.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="drawOptions"></param>
        public void Draw(Floatmap src, int x, int y, int width, int height, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => Draw(src, new Region(x, y, width, height), order, blendMode);

        /// <summary>
        /// Draws the given src image at the specified rectangle.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="rectangle"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public void Draw(Floatmap src, Rectangle rectangle, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => Draw(src, new Region(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height), order, blendMode);

        /// <summary>
        /// Draws the given src bitmap image at the specified Region Position. Not recommended. I advise you to use Floatmap instead, as it doesn't require converting first.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="pos"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public void Draw(Bitmap src, RegionPosition pos, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => Draw(Floatmap.FromBitmap(src), new Region(pos.X, pos.Y, src.Width, src.Height), order, blendMode);

        /// <summary>
        /// Draws the given src bitmap image at the specified point. Not recommended. I advise you to use Floatmap instead, as it doesn't require converting first.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="pos"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public void Draw(Bitmap src, Point pos, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => Draw(Floatmap.FromBitmap(src), new Region(pos.X, pos.Y, src.Width, src.Height), order, blendMode);

        /// <summary>
        /// Draws the given src bitmap image at the specified region position. Not recommended. I advise you to use Floatmap instead, as it doesn't require converting first.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="region"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public void Draw(Bitmap src, Region region, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => Draw(Floatmap.FromBitmap(src), region, order, blendMode);

        /// <summary>
        /// Draws the given src bitmap image at the specified rectangle. Not recommended. I advise you to use Floatmap instead, as it doesn't require converting first.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="rectangle"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public void Draw(Bitmap src, Rectangle rectangle, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => Draw(Floatmap.FromBitmap(src), new Region(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height), order, blendMode);

        /// <summary>
        /// Draws the specified color onto the specified region.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="region"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public void DrawColor(Vector4 color, Region region, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
        {
            SideyBlender.BlendColor(color, _dst, region, order, blendMode);
        }

        /// <summary>
        /// Draws the specified color onto the specified rectangle region.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="rectangle"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public void DrawColor(Vector4 color, Rectangle rectangle, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => DrawColor(color, new Region(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height), order, blendMode);

        /// <summary>
        /// Draws the specified color on the entire graphics image.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public void DrawColor(Vector4 color, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
        {
            SideyBlender.BlendColor(color, _dst, order, blendMode);
        }

        /// <summary>
        /// Draws the specified color onto the specified region.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="region"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public void DrawColor(Color color, Region region, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
        {
            SideyBlender.BlendColor(color, _dst, region, order, blendMode);
        }

        /// <summary>
        /// Draws the specified color onto the specified rectangle region.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="rectangle"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public void DrawColor(Color color, Rectangle rectangle, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
            => DrawColor(color, new Region(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height), order, blendMode);

        /// <summary>
        /// Draws the specified color on the entire graphics image.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="order"></param>
        /// <param name="blendMode"></param>
        public void DrawColor(Color color, CompositingOrder order = CompositingOrder.Above, BlendMode blendMode = BlendMode.Normal)
        {
            SideyBlender.BlendColor(color, _dst, order, blendMode);
        }
    }
}