using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SideyUtils.Drawing.Blending
{
    /// <summary>
    /// Represents a blending mode operation on Vector4 pixels
    /// </summary>
    public abstract class BlendingMode
    {
        protected static Vector4 M0000 = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
        protected static Vector4 M0001 = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
        protected static Vector4 M0010 = new Vector4(0.0f, 0.0f, 1.0f, 0.0f);
        protected static Vector4 M0011 = new Vector4(0.0f, 0.0f, 1.0f, 1.0f);
        protected static Vector4 M0100 = new Vector4(0.0f, 1.0f, 0.0f, 0.0f);
        protected static Vector4 M0101 = new Vector4(0.0f, 1.0f, 0.0f, 1.0f);
        protected static Vector4 M0110 = new Vector4(0.0f, 1.0f, 1.0f, 0.0f);
        protected static Vector4 M0111 = new Vector4(0.0f, 1.0f, 1.0f, 1.0f);
        protected static Vector4 M1000 = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
        protected static Vector4 M1001 = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
        protected static Vector4 M1010 = new Vector4(1.0f, 0.0f, 1.0f, 0.0f);
        protected static Vector4 M1011 = new Vector4(1.0f, 0.0f, 1.0f, 1.0f);
        protected static Vector4 M1100 = new Vector4(1.0f, 1.0f, 0.0f, 0.0f);
        protected static Vector4 M1101 = new Vector4(1.0f, 1.0f, 0.0f, 1.0f);
        protected static Vector4 M1110 = new Vector4(1.0f, 1.0f, 1.0f, 0.0f);
        protected static Vector4 M1111 = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);

        /// <summary>
        /// Blends the specified pixels together. Will blend p1 onto p2.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public abstract Vector4 Blend(Vector4 p1, Vector4 p2);

        /// <summary>
        /// Blends the specified pixels together. Will blend p1 onto p2 into dst.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public abstract unsafe void Blend(Vector4* p1, Vector4* p2, Vector4* dst);
    }
}
