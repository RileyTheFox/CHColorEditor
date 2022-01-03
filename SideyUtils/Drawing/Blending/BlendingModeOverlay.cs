using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SideyUtils.Drawing.Blending
{
    /// <summary>
    /// Represents a overlay blend mode. The alpha of p1 will be carried over.
    /// </summary>
    public class BlendingModeOverlay : BlendingMode
    {
        public override Vector4 Blend(Vector4 p1, Vector4 p2)
        {
            p1.X = p1.X < 0.5 ? OverlayLessThan(p1.X, p2.X) : OverlayGreaterThan(p1.X, p2.X);
            p1.Y = p1.Y < 0.5 ? OverlayLessThan(p1.Y, p2.Y) : OverlayGreaterThan(p1.Y, p2.Y);
            p1.Z = p1.Z < 0.5 ? OverlayLessThan(p1.Z, p2.Z) : OverlayGreaterThan(p1.Z, p2.Z);

            return p1;
        }

        public override unsafe void Blend(Vector4* p1, Vector4* p2, Vector4* dst)
        {
            dst->X = p1->X < 0.5 ? OverlayLessThan(p1->X, p2->X) : OverlayGreaterThan(p1->X, p2->X);
            dst->Y = p1->Y < 0.5 ? OverlayLessThan(p1->Y, p2->Y) : OverlayGreaterThan(p1->Y, p2->Y);
            dst->Z = p1->Z < 0.5 ? OverlayLessThan(p1->Z, p2->Z) : OverlayGreaterThan(p1->Z, p2->Z);

            dst->W = p1->W;
        }

        private float OverlayLessThan(float v1, float v2)
        {
            return 2.0f * v1 * v2;
        }

        private float OverlayGreaterThan(float v1, float v2)
        {
            return 1.0f - 2.0f * (1.0f - v1) * (1.0f - v2);
        }
    }
}
