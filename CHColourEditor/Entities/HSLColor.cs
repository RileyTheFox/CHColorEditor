﻿using System;
using System.Diagnostics.Contracts;
using System.Drawing;

namespace CHColourEditor
{
    public class HSLColor
    {
        // Private data members below are on scale 0-1
        // They are scaled for use externally based on scale
        private double hue = 1.0;
        private double saturation = 1.0;
        private double luminosity = 1.0;

        private const double scale = 240.0;

        public double Hue
        {
            get
            {
                return hue * scale;
            }
            set
            {
                // Loop around instead of clamping
                hue = (value % scale) / scale;
            }
        }

        public double Saturation
        {
            get
            {
                return saturation * scale;
            }
            set
            {
                saturation = CheckRange(value / scale);
            }
        }

        public double Luminosity
        {
            get
            {
                return luminosity * scale;
            }
            set
            {
                luminosity = CheckRange(value / scale);
            }
        }

        private static double CheckRange(double value)
        {
            if (value == Double.NaN)
            {
                value = 0;
            }

            return Math.Clamp(value, 0.0, 1.0);
        }

#pragma warning disable CA1305
        public override string ToString()
        {
            return string.Format("H: {0:#0.##} S: {1:#0.##} L: {2:#0.##}", Hue, Saturation, Luminosity);
        }

        public string ToRGBString()
        {
            Color color = this;
            return string.Format("R: {0:#0.##} G: {1:#0.##} B: {2:#0.##}", color.R, color.G, color.B);
        }
#pragma warning restore CA1305

        public static implicit operator Color(HSLColor hslColor)
        {
            Contract.Requires(hslColor != null);

            return hslColor.ToColor();
        }

        public Color ToColor()
        {
            Contract.Requires(this != null);

            double r = 0, g = 0, b = 0;
            if (luminosity != 0)
            {
                if (saturation == 0)
                    r = g = b = luminosity;
                else
                {
                    double temp2 = GetTemp2(this);
                    double temp1 = 2.0 * luminosity - temp2;

                    r = GetColorComponent(temp1, temp2, hue + 1.0 / 3.0);
                    g = GetColorComponent(temp1, temp2, hue);
                    b = GetColorComponent(temp1, temp2, hue - 1.0 / 3.0);
                }
            }
            return Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));
        }

        private static double GetColorComponent(double temp1, double temp2, double temp3)
        {
            temp3 = MoveIntoRange(temp3);
            if (temp3 < 1.0 / 6.0)
                return temp1 + (temp2 - temp1) * 6.0 * temp3;
            else if (temp3 < 0.5)
                return temp2;
            else if (temp3 < 2.0 / 3.0)
                return temp1 + ((temp2 - temp1) * ((2.0 / 3.0) - temp3) * 6.0);
            else
                return temp1;
        }

        private static double MoveIntoRange(double temp3)
        {
            if (temp3 < 0.0)
                temp3 += 1.0;
            else if (temp3 > 1.0)
                temp3 -= 1.0;
            return temp3;
        }

        private static double GetTemp2(HSLColor hslColor)
        {
            double temp2;
            if (hslColor.luminosity < 0.5)  //<=??
                temp2 = hslColor.luminosity * (1.0 + hslColor.saturation);
            else
                temp2 = hslColor.luminosity + hslColor.saturation - (hslColor.luminosity * hslColor.saturation);
            return temp2;
        }

        public static implicit operator HSLColor(Color color)
        {
            return ToHSLColor(color);
        }

        public static HSLColor ToHSLColor(Color color)
        {
            HSLColor hslColor = new HSLColor
            {
                hue = color.GetHue() / 360.0, // we store hue as 0-1 as opposed to 0-360 
                luminosity = color.GetBrightness(),
                saturation = color.GetSaturation()
            };

            return hslColor;
        }

        public void SetRGB(int red, int green, int blue)
        {
            HSLColor hslColor = Color.FromArgb(red, green, blue);
            this.hue = hslColor.hue;
            this.saturation = hslColor.saturation;
            this.luminosity = hslColor.luminosity;
        }

        public HSLColor()
        {
        }

        public HSLColor(Color color)
        {
            SetRGB(color.R, color.G, color.B);
        }

        public HSLColor(int red, int green, int blue)
        {
            SetRGB(red, green, blue);
        }

        public HSLColor(double hue, double saturation, double luminosity)
        {
            this.Hue = hue;
            this.Saturation = saturation;
            this.Luminosity = luminosity;
        }
    }
}