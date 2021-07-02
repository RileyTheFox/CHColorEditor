using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MechanikaDesign.WinForms.UI.ColorPicker;

namespace CHColourEditor
{
    public partial class ColorEditor : Form
    {

        #region Update Functions

        private void UpdateAllColors(Color color)
        {
            // This function just updates everything color related on the window

            this.lockUpdates = true;
            colorRgb = color;
            UpdateRgbFields(color);
            this.lockUpdates = true;
            UpdateHslFields(HslColor.FromColor(color));
            this.lockUpdates = true;
            UpdateColorFields();
            this.lockUpdates = false;

            labelCurrentColor.BackColor = colorRgb;
            string colorString = ColorTranslator.ToHtml(colorRgb);
            textboxHexColor.Text = colorString.Substring(1, colorString.Length - 1);

            int index = tabControl1.SelectedIndex;
            string list = GetCurrentListKey();
            // TODO Figure out async stuff so that it doesn't lag out the program or have a bunch of shit queued lol.
            PreviewManager.UpdatePreview(index, list, colorRgb);
        }

        private void UpdateColorFields()
        {
            // Responsible for the RGB up and down number fields

            this.lockUpdates = true;
            this.numRed.Value = this.colorRgb.R;
            this.numGreen.Value = this.colorRgb.G;
            this.numBlue.Value = this.colorRgb.B;
            this.numHue.Value = (int)(((decimal)this.colorHsl.H) * 360M);
            this.numSaturation.Value = (int)(((decimal)this.colorHsl.S) * 100M);
            this.numLuminance.Value = (int)(((decimal)this.colorHsl.L) * 100M);
            this.lockUpdates = false;

            labelCurrentColor.BackColor = colorRgb;
            string colorString = ColorTranslator.ToHtml(colorRgb);
            textboxHexColor.Text = colorString.Substring(1, colorString.Length - 1);
        }

        private void UpdateRgbFields(Color newColor)
        {
            this.colorHsl = HslColor.FromColor(newColor);
            this.colorRgb = newColor;
            this.lockUpdates = true;
            this.numHue.Value = (int)(((decimal)this.colorHsl.H) * 360M);
            this.numSaturation.Value = (int)(((decimal)this.colorHsl.S) * 100M);
            this.numLuminance.Value = (int)(((decimal)this.colorHsl.L) * 100M);
            this.lockUpdates = false;
            this.colorSlider.ColorHSL = this.colorHsl;
            this.colorBox2D.ColorHSL = this.colorHsl;

            labelCurrentColor.BackColor = colorRgb;
            string colorString = ColorTranslator.ToHtml(colorRgb);
            textboxHexColor.Text = colorString.Substring(1, colorString.Length - 1);
        }

        private void UpdateHslFields(HslColor newColor)
        {
            this.colorHsl = newColor;
            this.colorRgb = newColor.RgbValue;
            this.lockUpdates = true;
            this.numRed.Value = this.colorRgb.R;
            this.numGreen.Value = this.colorRgb.G;
            this.numBlue.Value = this.colorRgb.B;
            this.lockUpdates = false;
            this.colorSlider.ColorHSL = this.colorHsl;
            this.colorBox2D.ColorHSL = this.colorHsl;

            labelCurrentColor.BackColor = colorRgb;
            string colorString = ColorTranslator.ToHtml(colorRgb);
            textboxHexColor.Text = colorString.Substring(1, colorString.Length - 1);
        }

        #endregion

        #region Event Handlers

        private void colorSlider_ColorChanged(object sender, ColorChangedEventArgs args)
        {
            if (!this.lockUpdates)
            {
                HslColor colorHSL = this.colorSlider.ColorHSL;
                this.colorHsl = colorHSL;
                this.colorRgb = this.colorHsl.RgbValue;
                this.lockUpdates = true;
                this.colorBox2D.ColorHSL = this.colorHsl;
                this.lockUpdates = false;
                labelCurrentColor.BackColor = this.colorRgb;
                textboxHexColor.Text = ColorTranslator.ToHtml(this.colorRgb);
                UpdateColorFields();
            }
        }

        private void colorBox2D_ColorChanged(object sender, ColorChangedEventArgs args)
        {
            if (!this.lockUpdates)
            {
                HslColor colorHSL = this.colorBox2D.ColorHSL;
                this.colorHsl = colorHSL;
                this.colorRgb = this.colorHsl.RgbValue;
                this.lockUpdates = true;
                this.colorSlider.ColorHSL = this.colorHsl;
                this.lockUpdates = false;
                labelCurrentColor.BackColor = this.colorRgb;
                textboxHexColor.Text = ColorTranslator.ToHtml(this.colorRgb);
                UpdateColorFields();
            }
        }

        private void ColorModeChangedHandler(object sender, EventArgs e)
        {
            if (sender == this.radioRed)
            {
                this.colorMode = ColorModes.Red;
            }
            else if (sender == this.radioGreen)
            {
                this.colorMode = ColorModes.Green;
            }
            else if (sender == this.radioBlue)
            {
                this.colorMode = ColorModes.Blue;
            }
            else if (sender == this.radioHue)
            {
                this.colorMode = ColorModes.Hue;
            }
            else if (sender == this.radioSaturation)
            {
                this.colorMode = ColorModes.Saturation;
            }
            else if (sender == this.radioLuminance)
            {
                this.colorMode = ColorModes.Luminance;
            }
            this.colorSlider.ColorMode = this.colorMode;
            this.colorBox2D.ColorMode = this.colorMode;
        }

        private void numRed_ValueChanged(object sender, EventArgs e)
        {
            if (!this.lockUpdates)
            {
                UpdateRgbFields(Color.FromArgb((int)this.numRed.Value, (int)this.numGreen.Value, (int)this.numBlue.Value));
            }
        }

        private void numGreen_ValueChanged(object sender, EventArgs e)
        {
            if (!this.lockUpdates)
            {
                UpdateRgbFields(Color.FromArgb((int)this.numRed.Value, (int)this.numGreen.Value, (int)this.numBlue.Value));
            }
        }

        private void numBlue_ValueChanged(object sender, EventArgs e)
        {
            if (!this.lockUpdates)
            {
                UpdateRgbFields(Color.FromArgb((int)this.numRed.Value, (int)this.numGreen.Value, (int)this.numBlue.Value));
            }
        }

        private void numHue_ValueChanged(object sender, EventArgs e)
        {
            if (!this.lockUpdates)
            {
                HslColor newColor = HslColor.FromAhsl((double)(((float)((int)this.numHue.Value)) / 360f), this.colorHsl.S, this.colorHsl.L);
                this.UpdateHslFields(newColor);
            }
        }

        private void numSaturation_ValueChanged(object sender, EventArgs e)
        {
            if (!this.lockUpdates)
            {
                HslColor newColor = HslColor.FromAhsl(this.colorHsl.A, this.colorHsl.H, (double)(((float)((int)this.numSaturation.Value)) / 100f), this.colorHsl.L);
                this.UpdateHslFields(newColor);
            }

        }

        private void numLuminance_ValueChanged(object sender, EventArgs e)
        {
            if (!this.lockUpdates)
            {
                HslColor newColor = HslColor.FromAhsl(this.colorHsl.A, this.colorHsl.H, this.colorHsl.S, (double)(((float)((int)this.numLuminance.Value)) / 100f));
                this.UpdateHslFields(newColor);
            }
        }

        #endregion

    }
}
