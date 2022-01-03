using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SideyUtils.Drawing.Blending
{
    /// <summary>
    /// Represents a multiply blend mode. The alpha of p1 will be carried over.
    /// </summary>
    public class BlendingModeMultiply : BlendingMode
    {
        public override Vector4 Blend(Vector4 p1, Vector4 p2)
        {
            Vector4 d = p1 * p2;
            d.W = p1.W;

            return d;
        }

        public override unsafe void Blend(Vector4* p1, Vector4* p2, Vector4* d)
        {
            *d = *p1 * *p2;

            d->W = p1->W;
        }
    }
}
