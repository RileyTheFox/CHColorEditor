using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MechanikaDesign.WinForms.UI.ColorPicker;

using IniParser.Model;
using IniParser.Parser;
using IniParser;

namespace CHColourEditor
{
    public partial class ColourEditor : Form
    {
        public IniData iniData;

        private string OldHexTextBoxText = "";

        private HslColor colorHsl = HslColor.FromAhsl(0xff);
        private ColorModes colorMode = ColorModes.Hue;
        private Color colorRgb = Color.Empty;
        private bool lockUpdates = false;

        public Dictionary<string, string> GuitarValues = new Dictionary<string, string>();
        public Dictionary<string, string> DrumsValues = new Dictionary<string, string>();
        public Dictionary<string, string> OtherValues = new Dictionary<string, string>();

        public ColourEditor()
        {
            InitializeComponent();

            // Setup the dialog titles and filters
            openFileDialog1 = new OpenFileDialog()
            {
                Filter = "Ini file|*.ini",
                Title = "Open an ini file"
            };

            saveFileDialog1 = new SaveFileDialog()
            {
                Filter = "Ini file|*.ini",
                Title = "Save Color Ini file"
            };
        }

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
            textboxHexColor.Text = colorString.Substring(1, colorString.Length-1);
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

        #region Event Handlers

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Technically not necessary as the filter prevents this but add it anyways
                    if(!openFileDialog1.FileName.EndsWith(".ini"))
                    {
                        MessageBox.Show("File opened must be an ini file.");
                        return;
                    }

                    // Read the file and parse it to an IniData object
                    var sr = new StreamReader(openFileDialog1.FileName);
                    string iniDataString = sr.ReadToEnd();
                    iniData = new IniDataParser().Parse(iniDataString);

                    // If it doesn't contain these sections it's not a valid CH color file.
                    if (!iniData.Sections.ContainsSection("other") || !iniData.Sections.ContainsSection("drums") || !iniData.Sections.ContainsSection("guitar"))
                    {
                        MessageBox.Show("File opened is not a valid Clone Hero color ini file.");
                        return;
                    }

                    // Show the file that has been opened
                    fileOpened.Text = "File Opened: " + openFileDialog1.FileName;

                    // When saving later, default the file name to be the one opened.
                    saveFileDialog1.FileName = openFileDialog1.FileName;

                    // Reveal the save button and the editor
                    saveBtn.Visible = true;
                    saveBtn.Enabled = true;
                    editorContainer.Visible = true;
                    editorContainer.Enabled = true;

                    // Reset the lists (clears them if a file was previously opened) and then adds the new contents to them
                    ResetLists();
                    SetupLists();

                    // Make it so the guitar tab is the default selection
                    tabControl1.SelectedIndex = 0;

                    // Make the selected item on each list the first one
                    drumsList.SelectedIndex = 0;
                    otherList.SelectedIndex = 0;
                    // Guitar is done last because it triggers the event handlers which will update the color in the color picker, and we want it to be the guitar one.
                    guitarList.SelectedIndex = 0;

                } catch(Exception ex)
                {
                    MessageBox.Show($"File could not be opened.\n\nError: {ex.Message}\n\nDetauls: {ex.StackTrace}");
                }
            }
        }

        private void ColourEditor_Load(object sender, EventArgs e)
        {
            // no smaller than design time size
            this.MinimumSize = new Size(this.Width, this.Height);

            // no larger than screen size
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            OldHexTextBoxText = "FFFFFF";
        }

        private void ResetLists()
        {
            GuitarValues.Clear();
            guitarList.Items.Clear();
            DrumsValues.Clear();
            drumsList.Items.Clear();
            OtherValues.Clear();
            otherList.Items.Clear();
            UpdateAllColors(Color.White);
        }

        private void SetupLists()
        {
            // Guitar List
            for (int i = 0; i < iniData.Sections["guitar"].Count; i++)
            {
                KeyData key = iniData.Sections["guitar"].ElementAt(i);
                StringBuilder keyName = new StringBuilder();
                // The names in the ini files are all lowercase with _ in between each word which isn't very pretty looking so we change this.
                // Changes all underscores to spaces.
                string keyNameSpaces = key.KeyName.Replace('_', ' ');
                foreach (string word in keyNameSpaces.Split(' '))
                {
                    // Changes the first letter of now each word to uppercase.
                    keyName.Append(word[0].ToString().ToUpper());
                    keyName.Append(word.Substring(1, word.Length - 1));
                    keyName.Append(" ");
                }
                // Adds the key to the forms list and the internal dictionary for storing the key and its value
                guitarList.Items.Add(keyName.ToString());
                GuitarValues.Add(key.KeyName, key.Value);
            }
            // Drums List
            for (int i = 0; i < iniData.Sections["drums"].Count; i++)
            {
                KeyData key = iniData.Sections["drums"].ElementAt(i);
                StringBuilder keyName = new StringBuilder();
                string keyNameSpaces = key.KeyName.Replace('_', ' ');
                foreach (string word in keyNameSpaces.Split(' '))
                {
                    keyName.Append(word[0].ToString().ToUpper());
                    keyName.Append(word.Substring(1, word.Length - 1));
                    keyName.Append(" ");
                }
                drumsList.Items.Add(keyName.ToString());
                DrumsValues.Add(key.KeyName, key.Value);
            }
            // Other List
            for (int i = 0; i < iniData.Sections["other"].Count; i++)
            {
                KeyData key = iniData.Sections["other"].ElementAt(i);
                StringBuilder keyName = new StringBuilder();
                string keyNameSpaces = key.KeyName.Replace('_', ' ');
                foreach (string word in keyNameSpaces.Split(' '))
                {
                    keyName.Append(word[0].ToString().ToUpper());
                    keyName.Append(word.Substring(1, word.Length - 1));
                    keyName.Append(" ");
                }
                otherList.Items.Add(keyName.ToString());
                OtherValues.Add(key.KeyName, key.Value);
            }
        }

        #endregion

        #region Color Event Handlers

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

        #region Tab Control and List Handlers

        // These update the visual color corresponding to the list index that is selected
        private void guitarList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = guitarList.SelectedItem.ToString().Trim();
            item = item.ToLower().Replace(' ', '_');

            UpdateAllColors(ColorTranslator.FromHtml(GuitarValues[item]));
        }

        private void drumsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = drumsList.SelectedItem.ToString().Trim();
            item = item.ToLower().Replace(' ', '_');

            UpdateAllColors(ColorTranslator.FromHtml(DrumsValues[item]));
        }

        private void otherList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = otherList.SelectedItem.ToString().Trim();
            item = item.ToLower().Replace(' ', '_');

            UpdateAllColors(ColorTranslator.FromHtml(OtherValues[item]));
        }

        // If the tab is changed, we want the color to be updated to the index selected in the new tab
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = "";

            switch(tabControl1.SelectedIndex)
            {
                case 0:
                    // When added to the forms list, Windows adds a space to the end of the string which won't match the dictionary key so we have to trim it
                    item = guitarList.SelectedItem.ToString().Trim();
                    item = item.ToLower().Replace(' ', '_');

                    UpdateAllColors(ColorTranslator.FromHtml(GuitarValues[item]));
                    break;
                case 1:
                    item = drumsList.SelectedItem.ToString().Trim();
                    item = item.ToLower().Replace(' ', '_');

                    UpdateAllColors(ColorTranslator.FromHtml(DrumsValues[item]));
                    break;
                case 2:
                    item = otherList.SelectedItem.ToString().Trim();
                    item = item.ToLower().Replace(' ', '_');

                    UpdateAllColors(ColorTranslator.FromHtml(OtherValues[item]));
                    break;
            }
        }

        #endregion

        // This is text validation for the Hex text box
        private void textboxHexColor_TextChanged(object sender, EventArgs e)
        {
            // If the text starts with a #, we remove it (so if they paste in a hex code such as #FFFFFF it will become FFFFFF)
            if(textboxHexColor.Text.StartsWith("#"))
            {
                textboxHexColor.Text = textboxHexColor.Text.Substring(1, textboxHexColor.TextLength - 1);
            }
            // If it's any bigger than 6 we undo the change
            if(textboxHexColor.TextLength > 6)
            {
                textboxHexColor.Text = OldHexTextBoxText;
                textboxHexColor.SelectionStart = textboxHexColor.TextLength;
                textboxHexColor.SelectionLength = 0;
            }

            // If all the conditions match then we attempt to update the current color to the one in the hex text box
            try
            {
                if(textboxHexColor.TextLength == 6)
                {
                    Color newColor = ColorTranslator.FromHtml("#" + textboxHexColor.Text);
                    UpdateAllColors(newColor);
                }
            } catch(Exception)
            {
            }

            OldHexTextBoxText = textboxHexColor.Text;
        }

        // Updates the color value of the selected item to the one in the color picker
        private void updateColorBtn_Click(object sender, EventArgs e)
        {
            string item = "";

            switch(tabControl1.SelectedIndex)
            {
                // Guitar
                case 0:
                    item = guitarList.SelectedItem.ToString().Trim();
                    item = item.ToLower().Replace(' ', '_');
                    GuitarValues[item] = ColorTranslator.ToHtml(colorRgb);
                    break;
                // Drums
                case 1:
                    item = drumsList.SelectedItem.ToString().Trim();
                    item = item.ToLower().Replace(' ', '_');
                    DrumsValues[item] = ColorTranslator.ToHtml(colorRgb);
                    break;
                // Other
                case 2:
                    item = otherList.SelectedItem.ToString().Trim();
                    item = item.ToLower().Replace(' ', '_');
                    OtherValues[item] = ColorTranslator.ToHtml(colorRgb);
                    break;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // File name cannot be empty
                if(saveFileDialog1.FileName != "")
                {
                    // Set the values stored in the Dictionaries to the IniData for saving

                    // Guitar Values
                    foreach(KeyValuePair<string, string> pair in GuitarValues)
                    {
                        iniData.Sections["guitar"][pair.Key] = pair.Value;
                    }
                    // Drum Values
                    foreach (KeyValuePair<string, string> pair in DrumsValues)
                    {
                        iniData.Sections["drums"][pair.Key] = pair.Value;
                    }
                    // Other Values
                    foreach (KeyValuePair<string, string> pair in OtherValues)
                    {
                        iniData.Sections["other"][pair.Key] = pair.Value;
                    }

                    var parser = new FileIniDataParser();
                    parser.WriteFile(saveFileDialog1.FileName, iniData, Encoding.UTF8);
                }
            }
        }
    }
}
