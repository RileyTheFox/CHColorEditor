using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SideyUtils.Drawing.Blending
{
    /// <summary>
    /// Represents an add blend mode. The alpha of p2 will be carried over.
    /// </summary>
    public class BlendingModeAdd : BlendingMode
    {
        public override Vector4 Blend(Vector4 p1, Vector4 p2)
        {
            Vector4 d = p1 + p2;
            d.W = p2.W;

            return Vector4.Clamp(d, Vector4.Zero, Vector4.One);
        }

        public override unsafe void Blend(Vector4* p1, Vector4* p2, Vector4* dst)
        {
            *dst = Vector4.Clamp(*p1 + *p2, Vector4.Zero, Vector4.One);

            dst->W = p2->W;
        }
    }
}
