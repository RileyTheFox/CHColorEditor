using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SideyUtils.Drawing.Blending
{
    /// <summary>
    /// Represents a normal blending mode with alpha compositing.
    /// </summary>
    public class BlendingModeNormal : BlendingMode
    {
        public override Vector4 Blend(Vector4 p1, Vector4 p2)
        {
            float ac = p2.W * (1.0f - p1.W);

            return (((p1 * M1110) + M0001) * p1.W) + (((p2 * M1110) + M0001) * ac);
        }

        public override unsafe void Blend(Vector4* p1, Vector4* p2, Vector4* dst)
        {
            float ac = p2->W * (1.0f - p1->W);

            *dst = (((*p1 * M1110) + M0001) * p1->W) + ((((*p2) * M1110) + M0001) * ac);
        }
    }
}
