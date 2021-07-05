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
using System.Net;
using System.Runtime.InteropServices;
using System.Reflection;

namespace CHColourEditor
{
    public partial class ColorEditor : Form
    {
#if DEBUG
        private const string CURRENT_VERSION_STRING = "1.2 DEV BUILD";
#else
        private const string CURRENT_VERSION_STRING = "1.2";
#endif

        public IniData iniData;
        private TexturePreviewManager PreviewManager;

        #region Variables
        public bool unsavedChanges = false;

        private string OldHexTextBoxText = "";

        private HslColor colorHsl = HslColor.FromAhsl(0xff);
        private ColorModes colorMode = ColorModes.Hue;
        private Color colorRgb;
        private bool lockUpdates = false;

        public Dictionary<string, string> GuitarColors = new Dictionary<string, string>();
        public Dictionary<string, string> DrumsColors = new Dictionary<string, string>();
        public Dictionary<string, string> OtherColors = new Dictionary<string, string>();

        #endregion

        public ColorEditor()
        {
            InitializeComponent();

            // Setup the dialog titles and filters
            openFileDialog1 = new OpenFileDialog()
            {
                Filter = "CH Colors Ini File|*.ini|GameColors Config File|*.cfg",
                Title = "Open a CH Color Ini File or GameColors Config File"
            };
            saveFileDialog1 = new SaveFileDialog()
            {
                Filter = "CH Colors Ini File|*.ini",
                Title = "Save CH Colors Ini File"
            };

            colorRgb = Color.Empty;
            PreviewManager = new TexturePreviewManager(texturePreviewImg);

            this.Text = "CH Color Editor v" + CURRENT_VERSION_STRING;

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ColorEditor_OnFormClosing);

#if !DEBUG
            // Automatically check for updates
            Task.Run(() =>
            {
                string newVersionText = IsOutOfDate().Result;

                // If it's empty then there is no update available
                if(newVersionText != string.Empty)
                {
                    if (MessageBox.Show($"CH Color Editor is out of date!\nCurrent version: {CURRENT_VERSION_STRING}. Latest version: {newVersionText}\nWould you like to open the update page?", "CH Color Editor Update Checker", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://github.com/rileythefox/chcoloreditor");
                    }
                }
            });
#endif
        }

        #region Event Handlers

        #region File Management

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = null;
                string iniDataString = "";

                try
                {
                    // Technically not necessary as the filter prevents this but add it anyways
                    if(!openFileDialog1.FileName.EndsWith(".ini") && !openFileDialog1.FileName.EndsWith(".cfg"))
                    {
                        MessageBox.Show("File opened must be a CH Color Ini File or GameColors Config file.");
                        return;
                    }

                    // Open stream of file
                    streamReader = new StreamReader(openFileDialog1.FileName);

                    if (openFileDialog1.FileName.EndsWith(".cfg"))
                    {
                        // lol @ having to type resources twice because I put it in a folder to organise
                        iniDataString = Resources.Resources.DefaultColors;
                        iniData = new IniDataParser().Parse(iniDataString);

                        if(!GameColors.ConvertGameColors(ref iniData, streamReader.ReadToEnd()))
                        {
                            MessageBox.Show("File opened is not a valid GameColors Config file.");
                            return;
                        }
                    } else
                    {
                        // Read the file and parse it to an IniData object
                        iniDataString = streamReader.ReadToEnd();
                        streamReader.Close();

                        iniData = new IniDataParser().Parse(iniDataString);
                    }

                    // If it doesn't contain these sections it's not a valid CH color file.
                    if (!iniData.Sections.ContainsSection("other") || !iniData.Sections.ContainsSection("drums") || !iniData.Sections.ContainsSection("guitar"))
                    {
                        MessageBox.Show("File opened is not a valid Clone Hero color ini file.");
                        return;
                    }

                    //lockUpdates = true;
                    SetupEditor();
                    lockUpdates = false;

                    // Show the file that has been opened
                    fileOpened.Text = "File Opened: " + openFileDialog1.FileName;

                    // When saving later, default the file name to be the one opened.
                    saveFileDialog1.FileName = openFileDialog1.FileName;
                    streamReader.Close();
                } catch(Exception ex)
                {
                    MessageBox.Show($"File could not be opened.\n\nError: {ex.Message}\n\nDetauls: {ex.StackTrace}");
                    HideEditor();
                    if(streamReader != null)
                    {
                        streamReader.Close();
                    }
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // File name cannot be empty
                if (saveFileDialog1.FileName != "")
                {
                    // Set the values stored in the Dictionaries to the IniData for saving

                    // Guitar Values
                    foreach (KeyValuePair<string, string> pair in GuitarColors)
                    {
                        iniData.Sections["guitar"][pair.Key] = pair.Value;
                    }
                    // Drum Values
                    foreach (KeyValuePair<string, string> pair in DrumsColors)
                    {
                        iniData.Sections["drums"][pair.Key] = pair.Value;
                    }
                    // Other Values
                    foreach (KeyValuePair<string, string> pair in OtherColors)
                    {
                        iniData.Sections["other"][pair.Key] = pair.Value;
                    }

                    var parser = new FileIniDataParser();
                    parser.WriteFile(saveFileDialog1.FileName, iniData, Encoding.UTF8);
                    unsavedChanges = false;
                    this.Text = "CH Color Editor v" + CURRENT_VERSION_STRING;
                }
            }
        }

        #endregion

        private void ColorEditor_Load(object sender, EventArgs e)
        {
            // no smaller than design time size
            this.MinimumSize = new Size(this.Width, this.Height);

            // no larger than screen size
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            OldHexTextBoxText = "FFFFFF";

            guitarList.SelectionMode = SelectionMode.MultiExtended;
            drumsList.SelectionMode = SelectionMode.MultiExtended;
            otherList.SelectionMode = SelectionMode.MultiExtended;
        }

        private void ColorEditor_OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if(unsavedChanges)
            {
                switch(MessageBox.Show("You have unsaved changes! Would you like to save them?", "CH Color Editor", MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Yes:
                        DialogResult result = OpenSaveDialog();
                        if (result == DialogResult.Cancel)
                            e.Cancel = true;
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        // This is text validation for the Hex text box
        private void textboxHexColor_TextChanged(object sender, EventArgs e)
        {
            // If the text starts with a #, we remove it (so if they paste in a hex code such as #FFFFFF it will become FFFFFF)
            if (textboxHexColor.Text.StartsWith("#"))
            {
                textboxHexColor.Text = textboxHexColor.Text.Substring(1, textboxHexColor.TextLength - 1);
            }
            // If it's any bigger than 6 we undo the change
            if (textboxHexColor.TextLength > 6)
            {
                textboxHexColor.Text = OldHexTextBoxText;
                textboxHexColor.SelectionStart = textboxHexColor.TextLength;
                textboxHexColor.SelectionLength = 0;
            }

            // If all the conditions match then we attempt to update the current color to the one in the hex text box
            try
            {
                if (textboxHexColor.TextLength == 6)
                {
                    Color newColor = ColorTranslator.FromHtml("#" + textboxHexColor.Text);
                    UpdateAllColors(newColor);
                }
            }
            catch (Exception)
            {
            }

            OldHexTextBoxText = textboxHexColor.Text;
        }

        // Updates the color value of the selected item to the one in the color picker
        private void updateColorBtn_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                // Guitar
                case 0:
                    foreach(object selectedItem in guitarList.SelectedItems)
                    {
                        string item = selectedItem.ToString().Trim();
                        item = item.ToLower().Replace(' ', '_');
                        GuitarColors[item] = ColorTranslator.ToHtml(colorRgb);
                    }
                    this.Text = "*CH Color Editor v" + CURRENT_VERSION_STRING;
                    unsavedChanges = true;
                    break;
                // Drums
                case 1:
                    foreach (object selectedItem in drumsList.SelectedItems)
                    {
                        string item = selectedItem.ToString().Trim();
                        item = item.ToLower().Replace(' ', '_');
                        DrumsColors[item] = ColorTranslator.ToHtml(colorRgb);
                    }
                    this.Text = "*CH Color Editor v" + CURRENT_VERSION_STRING;
                    unsavedChanges = true;
                    break;
                // Other
                case 2:
                    foreach (object selectedItem in otherList.SelectedItems)
                    {
                        string item = selectedItem.ToString().Trim();
                        item = item.ToLower().Replace(' ', '_');
                        OtherColors[item] = ColorTranslator.ToHtml(colorRgb);
                    }
                    this.Text = "*CH Color Editor v" + CURRENT_VERSION_STRING;
                    unsavedChanges = true;
                    break;
            }
        }

        private async void checkForUpdatesBtn_Click(object sender, EventArgs e)
        {
#if DEBUG
            MessageBox.Show("Cannot check for updates on dev builds.", "CH Color Editor Update Checker");
            return;
#else
            string newVersionText = await IsOutOfDate(true);

            if(newVersionText != string.Empty)
            {
                MessageBox.Show("Cannot check for updates on dev builds.", "CH Color Editor Update Checker");
                if (MessageBox.Show($"CH Color Editor is out of date!\nCurrent version: {CURRENT_VERSION_STRING}. Latest version: {newVersionText}\nWould you like to open the update page?", "CH Color Editor Update Checker", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("https://github.com/rileythefox/chcoloreditor");
                }
            } else
            {
                MessageBox.Show("The program is up to date!", "CH Color Editor Update Checker");
            }
#endif
        }

        #endregion

        #region Editor Functions

        private void SetupEditor()
        {
            // Reset the lists (clears them if a file was previously opened) and then adds the new contents to them
            ResetLists();
            AddToLists();

            // Make it so the guitar tab is the default selection
            tabControl1.SelectedIndex = 0;

            // Make the selected item on each list the first one
            guitarList.SelectedIndex = 0; // We have to do guitar twice to initialise it or else it will crash because of the event handlers.
            drumsList.SelectedIndex = 0;
            otherList.SelectedIndex = 0;
            // Guitar is done last because it triggers the event handlers which will update the color in the color picker, and we want it to be the guitar one.
            guitarList.SelectedIndex = 0;

            // Reveal the save button and the editor
            saveBtn.Visible = true;
            saveBtn.Enabled = true;
            editorContainer.Visible = true;
            editorContainer.Enabled = true;

            // Reveal texture preview
            texturePreviewContainer.Visible = true;
            texturePreviewContainer.Enabled = true;
        }
        private void HideEditor()
        {
            saveBtn.Visible = false;
            saveBtn.Enabled = false;
            editorContainer.Visible = false;
            editorContainer.Enabled = false;

            texturePreviewContainer.Visible = false;
            texturePreviewContainer.Enabled = false;

            ResetLists();
        }
        private void AddToLists()
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
                GuitarColors.Add(key.KeyName, key.Value);
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
                DrumsColors.Add(key.KeyName, key.Value);
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
                OtherColors.Add(key.KeyName, key.Value);
            }
        }
        private void ResetLists()
        {
            GuitarColors.Clear();
            guitarList.Items.Clear();
            DrumsColors.Clear();
            drumsList.Items.Clear();
            OtherColors.Clear();
            otherList.Items.Clear();
        }

        #endregion

        #region Tab Control and List Functions

        // These update the visual color corresponding to the list index that is selected
        private void guitarList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = guitarList.SelectedItem.ToString().Trim();
            item = item.ToLower().Replace(' ', '_');

            if(!lockUpdates)
                UpdateAllColors(ColorTranslator.FromHtml(GuitarColors[item]));
        }

        private void drumsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = drumsList.SelectedItem.ToString().Trim();
            item = item.ToLower().Replace(' ', '_');

            if(!lockUpdates)
                UpdateAllColors(ColorTranslator.FromHtml(DrumsColors[item]));
        }

        private void otherList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = otherList.SelectedItem.ToString().Trim();
            item = item.ToLower().Replace(' ', '_');

            if(!lockUpdates)
                UpdateAllColors(ColorTranslator.FromHtml(OtherColors[item]));
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

                    UpdateAllColors(ColorTranslator.FromHtml(GuitarColors[item]));
                    break;
                case 1:
                    item = drumsList.SelectedItem.ToString().Trim();
                    item = item.ToLower().Replace(' ', '_');

                    UpdateAllColors(ColorTranslator.FromHtml(DrumsColors[item]));
                    break;
                case 2:
                    item = otherList.SelectedItem.ToString().Trim();
                    item = item.ToLower().Replace(' ', '_');

                    UpdateAllColors(ColorTranslator.FromHtml(OtherColors[item]));
                    break;
            }
        }

        #endregion

        private List<string> GetCurrentlySelectedKeys()
        {
            List<string> list = new List<string>();

            switch (tabControl1.SelectedIndex)
            {
                // Guitar
                case 0:
                    foreach (object obj in guitarList.SelectedItems)
                    {
                        list.Add(obj.ToString().Trim().ToLower().Replace(' ', '_'));
                    }
                    break;
                // Drums
                case 1:
                    foreach (object obj in drumsList.SelectedItems)
                    {
                        list.Add(obj.ToString().Trim().ToLower().Replace(' ', '_'));
                    }
                    break;
                // Other
                case 2:
                    foreach (object obj in otherList.SelectedItems)
                    {
                        list.Add(obj.ToString().Trim().ToLower().Replace(' ', '_'));
                    }
                    break;
            }
            return list;
        }

        private async Task<string> IsOutOfDate(bool button = false)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://rileythefox.co.uk/versions/coloreditor.txt");
            try
            {
                HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader stream = new StreamReader(response.GetResponseStream());
                    string newVersionText = await stream.ReadToEndAsync();
                    stream.Close();

                    if (newVersionText != CURRENT_VERSION_STRING)
                        return newVersionText;
                }
            }
            catch (WebException)
            {
                if (button)
                    MessageBox.Show("Error checking for updates!\nYou can check manually at https://github.com/rileythefox/chcoloreditor", "CH Color Editor Update Checker");
            }
            return string.Empty;
        }

        private DialogResult OpenSaveDialog()
        {
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                // File name cannot be empty
                if (saveFileDialog1.FileName != "")
                {
                    // Set the values stored in the Dictionaries to the IniData for saving

                    // Guitar Values
                    foreach (KeyValuePair<string, string> pair in GuitarColors)
                    {
                        iniData.Sections["guitar"][pair.Key] = pair.Value;
                    }
                    // Drum Values
                    foreach (KeyValuePair<string, string> pair in DrumsColors)
                    {
                        iniData.Sections["drums"][pair.Key] = pair.Value;
                    }
                    // Other Values
                    foreach (KeyValuePair<string, string> pair in OtherColors)
                    {
                        iniData.Sections["other"][pair.Key] = pair.Value;
                    }

                    var parser = new FileIniDataParser();
                    parser.WriteFile(saveFileDialog1.FileName, iniData, Encoding.UTF8);
                    unsavedChanges = false;
                    this.Text = "CH Color Editor v" + CURRENT_VERSION_STRING;
                }
            }
            return result;
        }
    }
}
