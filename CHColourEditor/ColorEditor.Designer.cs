
namespace CHColourEditor
{
    sealed partial class ColorEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorEditor));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.guitarList = new System.Windows.Forms.ListBox();
            this.editorContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox_ItemList = new System.Windows.Forms.GroupBox();
            this.tabControl_Sections = new System.Windows.Forms.TabControl();
            this.guitarPage = new System.Windows.Forms.TabPage();
            this.drumsPage = new System.Windows.Forms.TabPage();
            this.drumsList = new System.Windows.Forms.ListBox();
            this.otherPage = new System.Windows.Forms.TabPage();
            this.otherList = new System.Windows.Forms.ListBox();
            this.colorPickerContainer = new System.Windows.Forms.GroupBox();
            this.updateColorBtn = new System.Windows.Forms.Button();
            this.colorBox2D = new MechanikaDesign.WinForms.UI.ColorPicker.ColorBox2D();
            this.textboxHexColor = new System.Windows.Forms.TextBox();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.numLuminance = new System.Windows.Forms.NumericUpDown();
            this.textboxCurrentColor = new System.Windows.Forms.Label();
            this.radioLuminance = new System.Windows.Forms.RadioButton();
            this.labelHex = new System.Windows.Forms.Label();
            this.numSaturation = new System.Windows.Forms.NumericUpDown();
            this.colorSlider = new MechanikaDesign.WinForms.UI.ColorPicker.ColorSliderVertical();
            this.radioSaturation = new System.Windows.Forms.RadioButton();
            this.radioRed = new System.Windows.Forms.RadioButton();
            this.numHue = new System.Windows.Forms.NumericUpDown();
            this.numRed = new System.Windows.Forms.NumericUpDown();
            this.radioHue = new System.Windows.Forms.RadioButton();
            this.radioGreen = new System.Windows.Forms.RadioButton();
            this.numBlue = new System.Windows.Forms.NumericUpDown();
            this.numGreen = new System.Windows.Forms.NumericUpDown();
            this.radioBlue = new System.Windows.Forms.RadioButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.texturePreviewContainer = new System.Windows.Forms.GroupBox();
            this.texturePreviewImg = new System.Windows.Forms.PictureBox();
            this.toolStripMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenu_FileTab = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_New = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_New_DefaultProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_New_BlankProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_HelpTab = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_Changelog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_CheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenu_About = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.editorContainer)).BeginInit();
            this.editorContainer.Panel1.SuspendLayout();
            this.editorContainer.Panel2.SuspendLayout();
            this.editorContainer.SuspendLayout();
            this.groupBox_ItemList.SuspendLayout();
            this.tabControl_Sections.SuspendLayout();
            this.guitarPage.SuspendLayout();
            this.drumsPage.SuspendLayout();
            this.otherPage.SuspendLayout();
            this.colorPickerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLuminance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreen)).BeginInit();
            this.texturePreviewContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.texturePreviewImg)).BeginInit();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "\"Clone Hero .ini file|*.ini|GameColors .cfg file|*.cfg\"";
            this.openFileDialog.Title = "Open a Clone Hero .ini file or GameColors .cfg file";
            // 
            // guitarList
            // 
            this.guitarList.FormattingEnabled = true;
            this.guitarList.ItemHeight = 15;
            this.guitarList.Location = new System.Drawing.Point(5, 5);
            this.guitarList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guitarList.Name = "guitarList";
            this.guitarList.Size = new System.Drawing.Size(294, 334);
            this.guitarList.TabIndex = 0;
            this.guitarList.SelectedIndexChanged += new System.EventHandler(this.guitarList_SelectedIndexChanged);
            // 
            // editorContainer
            // 
            this.editorContainer.Enabled = false;
            this.editorContainer.Location = new System.Drawing.Point(14, 31);
            this.editorContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.editorContainer.Name = "editorContainer";
            // 
            // editorContainer.Panel1
            // 
            this.editorContainer.Panel1.Controls.Add(this.groupBox_ItemList);
            this.editorContainer.Panel1MinSize = 277;
            // 
            // editorContainer.Panel2
            // 
            this.editorContainer.Panel2.Controls.Add(this.colorPickerContainer);
            this.editorContainer.Size = new System.Drawing.Size(841, 408);
            this.editorContainer.SplitterDistance = 331;
            this.editorContainer.SplitterWidth = 5;
            this.editorContainer.TabIndex = 8;
            this.editorContainer.Visible = false;
            // 
            // groupBox_ItemList
            // 
            this.groupBox_ItemList.Controls.Add(this.tabControl_Sections);
            this.groupBox_ItemList.Location = new System.Drawing.Point(4, 3);
            this.groupBox_ItemList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_ItemList.Name = "groupBox_ItemList";
            this.groupBox_ItemList.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_ItemList.Size = new System.Drawing.Size(323, 400);
            this.groupBox_ItemList.TabIndex = 12;
            this.groupBox_ItemList.TabStop = false;
            this.groupBox_ItemList.Text = "Item List";
            // 
            // tabControl_Sections
            // 
            this.tabControl_Sections.Controls.Add(this.guitarPage);
            this.tabControl_Sections.Controls.Add(this.drumsPage);
            this.tabControl_Sections.Controls.Add(this.otherPage);
            this.tabControl_Sections.Location = new System.Drawing.Point(7, 22);
            this.tabControl_Sections.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl_Sections.Name = "tabControl_Sections";
            this.tabControl_Sections.SelectedIndex = 0;
            this.tabControl_Sections.Size = new System.Drawing.Size(312, 372);
            this.tabControl_Sections.TabIndex = 7;
            this.tabControl_Sections.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // guitarPage
            // 
            this.guitarPage.Controls.Add(this.guitarList);
            this.guitarPage.Location = new System.Drawing.Point(4, 24);
            this.guitarPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guitarPage.Name = "guitarPage";
            this.guitarPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.guitarPage.Size = new System.Drawing.Size(304, 344);
            this.guitarPage.TabIndex = 0;
            this.guitarPage.Text = "Guitar";
            this.guitarPage.UseVisualStyleBackColor = true;
            // 
            // drumsPage
            // 
            this.drumsPage.Controls.Add(this.drumsList);
            this.drumsPage.Location = new System.Drawing.Point(4, 24);
            this.drumsPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.drumsPage.Name = "drumsPage";
            this.drumsPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.drumsPage.Size = new System.Drawing.Size(304, 344);
            this.drumsPage.TabIndex = 1;
            this.drumsPage.Text = "Drums";
            this.drumsPage.UseVisualStyleBackColor = true;
            // 
            // drumsList
            // 
            this.drumsList.FormattingEnabled = true;
            this.drumsList.ItemHeight = 15;
            this.drumsList.Location = new System.Drawing.Point(5, 5);
            this.drumsList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.drumsList.Name = "drumsList";
            this.drumsList.Size = new System.Drawing.Size(294, 334);
            this.drumsList.TabIndex = 1;
            this.drumsList.SelectedIndexChanged += new System.EventHandler(this.drumsList_SelectedIndexChanged);
            // 
            // otherPage
            // 
            this.otherPage.Controls.Add(this.otherList);
            this.otherPage.Location = new System.Drawing.Point(4, 24);
            this.otherPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.otherPage.Name = "otherPage";
            this.otherPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.otherPage.Size = new System.Drawing.Size(304, 344);
            this.otherPage.TabIndex = 2;
            this.otherPage.Text = "Other";
            this.otherPage.UseVisualStyleBackColor = true;
            // 
            // otherList
            // 
            this.otherList.FormattingEnabled = true;
            this.otherList.ItemHeight = 15;
            this.otherList.Location = new System.Drawing.Point(5, 5);
            this.otherList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.otherList.Name = "otherList";
            this.otherList.Size = new System.Drawing.Size(294, 334);
            this.otherList.TabIndex = 1;
            this.otherList.SelectedIndexChanged += new System.EventHandler(this.otherList_SelectedIndexChanged);
            // 
            // colorPickerContainer
            // 
            this.colorPickerContainer.Controls.Add(this.updateColorBtn);
            this.colorPickerContainer.Controls.Add(this.colorBox2D);
            this.colorPickerContainer.Controls.Add(this.textboxHexColor);
            this.colorPickerContainer.Controls.Add(this.labelCurrent);
            this.colorPickerContainer.Controls.Add(this.numLuminance);
            this.colorPickerContainer.Controls.Add(this.textboxCurrentColor);
            this.colorPickerContainer.Controls.Add(this.radioLuminance);
            this.colorPickerContainer.Controls.Add(this.labelHex);
            this.colorPickerContainer.Controls.Add(this.numSaturation);
            this.colorPickerContainer.Controls.Add(this.colorSlider);
            this.colorPickerContainer.Controls.Add(this.radioSaturation);
            this.colorPickerContainer.Controls.Add(this.radioRed);
            this.colorPickerContainer.Controls.Add(this.numHue);
            this.colorPickerContainer.Controls.Add(this.numRed);
            this.colorPickerContainer.Controls.Add(this.radioHue);
            this.colorPickerContainer.Controls.Add(this.radioGreen);
            this.colorPickerContainer.Controls.Add(this.numBlue);
            this.colorPickerContainer.Controls.Add(this.numGreen);
            this.colorPickerContainer.Controls.Add(this.radioBlue);
            this.colorPickerContainer.Location = new System.Drawing.Point(4, 3);
            this.colorPickerContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.colorPickerContainer.Name = "colorPickerContainer";
            this.colorPickerContainer.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.colorPickerContainer.Size = new System.Drawing.Size(497, 400);
            this.colorPickerContainer.TabIndex = 13;
            this.colorPickerContainer.TabStop = false;
            this.colorPickerContainer.Text = "Color Picker";
            // 
            // updateColorBtn
            // 
            this.updateColorBtn.Location = new System.Drawing.Point(187, 332);
            this.updateColorBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.updateColorBtn.Name = "updateColorBtn";
            this.updateColorBtn.Size = new System.Drawing.Size(110, 27);
            this.updateColorBtn.TabIndex = 32;
            this.updateColorBtn.Text = "Update Color";
            this.updateColorBtn.UseVisualStyleBackColor = true;
            this.updateColorBtn.Click += new System.EventHandler(this.updateColorBtn_Click);
            // 
            // colorBox2D
            // 
            this.colorBox2D.ColorMode = MechanikaDesign.WinForms.UI.ColorPicker.ColorModes.Hue;
            this.colorBox2D.ColorRGB = System.Drawing.Color.Red;
            this.colorBox2D.Location = new System.Drawing.Point(7, 22);
            this.colorBox2D.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.colorBox2D.Name = "colorBox2D";
            this.colorBox2D.Size = new System.Drawing.Size(286, 291);
            this.colorBox2D.TabIndex = 0;
            this.colorBox2D.ColorChanged += new MechanikaDesign.WinForms.UI.ColorPicker.ColorBox2D.ColorChangedEventHandler(this.colorBox2D_ColorChanged);
            // 
            // textboxHexColor
            // 
            this.textboxHexColor.Location = new System.Drawing.Point(100, 335);
            this.textboxHexColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textboxHexColor.Name = "textboxHexColor";
            this.textboxHexColor.Size = new System.Drawing.Size(79, 23);
            this.textboxHexColor.TabIndex = 31;
            this.textboxHexColor.Text = "FFFFFF";
            this.textboxHexColor.TextChanged += new System.EventHandler(this.textboxHexColor_TextChanged);
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Location = new System.Drawing.Point(7, 316);
            this.labelCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(47, 15);
            this.labelCurrent.TabIndex = 28;
            this.labelCurrent.Text = "Current";
            // 
            // numLuminance
            // 
            this.numLuminance.Location = new System.Drawing.Point(407, 193);
            this.numLuminance.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numLuminance.Name = "numLuminance";
            this.numLuminance.Size = new System.Drawing.Size(63, 23);
            this.numLuminance.TabIndex = 13;
            this.numLuminance.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numLuminance.ValueChanged += new System.EventHandler(this.numLuminance_ValueChanged);
            // 
            // textboxCurrentColor
            // 
            this.textboxCurrentColor.BackColor = System.Drawing.Color.White;
            this.textboxCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxCurrentColor.Location = new System.Drawing.Point(7, 335);
            this.textboxCurrentColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textboxCurrentColor.Name = "textboxCurrentColor";
            this.textboxCurrentColor.Size = new System.Drawing.Size(79, 23);
            this.textboxCurrentColor.TabIndex = 29;
            // 
            // radioLuminance
            // 
            this.radioLuminance.AutoSize = true;
            this.radioLuminance.Location = new System.Drawing.Point(357, 193);
            this.radioLuminance.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioLuminance.Name = "radioLuminance";
            this.radioLuminance.Size = new System.Drawing.Size(34, 19);
            this.radioLuminance.TabIndex = 12;
            this.radioLuminance.Text = "L:";
            this.radioLuminance.UseVisualStyleBackColor = true;
            this.radioLuminance.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // labelHex
            // 
            this.labelHex.AutoSize = true;
            this.labelHex.Location = new System.Drawing.Point(97, 316);
            this.labelHex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHex.Name = "labelHex";
            this.labelHex.Size = new System.Drawing.Size(28, 15);
            this.labelHex.TabIndex = 30;
            this.labelHex.Text = "Hex";
            // 
            // numSaturation
            // 
            this.numSaturation.Location = new System.Drawing.Point(407, 163);
            this.numSaturation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numSaturation.Name = "numSaturation";
            this.numSaturation.Size = new System.Drawing.Size(63, 23);
            this.numSaturation.TabIndex = 11;
            this.numSaturation.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numSaturation.ValueChanged += new System.EventHandler(this.numSaturation_ValueChanged);
            // 
            // colorSlider
            // 
            this.colorSlider.ColorMode = MechanikaDesign.WinForms.UI.ColorPicker.ColorModes.Hue;
            this.colorSlider.ColorRGB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(205)))), ((int)(((byte)(0)))));
            this.colorSlider.Location = new System.Drawing.Point(300, 20);
            this.colorSlider.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.colorSlider.Name = "colorSlider";
            this.colorSlider.NubColor = System.Drawing.Color.White;
            this.colorSlider.Position = 143;
            this.colorSlider.Size = new System.Drawing.Size(47, 295);
            this.colorSlider.TabIndex = 1;
            this.colorSlider.ColorChanged += new MechanikaDesign.WinForms.UI.ColorPicker.ColorSliderVertical.ColorChangedEventHandler(this.colorSlider_ColorChanged);
            // 
            // radioSaturation
            // 
            this.radioSaturation.AutoSize = true;
            this.radioSaturation.Location = new System.Drawing.Point(357, 163);
            this.radioSaturation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioSaturation.Name = "radioSaturation";
            this.radioSaturation.Size = new System.Drawing.Size(34, 19);
            this.radioSaturation.TabIndex = 10;
            this.radioSaturation.Text = "S:";
            this.radioSaturation.UseVisualStyleBackColor = true;
            this.radioSaturation.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // radioRed
            // 
            this.radioRed.AutoSize = true;
            this.radioRed.Location = new System.Drawing.Point(357, 22);
            this.radioRed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioRed.Name = "radioRed";
            this.radioRed.Size = new System.Drawing.Size(35, 19);
            this.radioRed.TabIndex = 2;
            this.radioRed.Text = "R:";
            this.radioRed.UseVisualStyleBackColor = true;
            this.radioRed.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // numHue
            // 
            this.numHue.Location = new System.Drawing.Point(407, 133);
            this.numHue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numHue.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numHue.Name = "numHue";
            this.numHue.Size = new System.Drawing.Size(63, 23);
            this.numHue.TabIndex = 9;
            this.numHue.ValueChanged += new System.EventHandler(this.numHue_ValueChanged);
            // 
            // numRed
            // 
            this.numRed.Location = new System.Drawing.Point(407, 22);
            this.numRed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numRed.Name = "numRed";
            this.numRed.Size = new System.Drawing.Size(63, 23);
            this.numRed.TabIndex = 3;
            this.numRed.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numRed.ValueChanged += new System.EventHandler(this.numRed_ValueChanged);
            // 
            // radioHue
            // 
            this.radioHue.AutoSize = true;
            this.radioHue.Checked = true;
            this.radioHue.Location = new System.Drawing.Point(357, 133);
            this.radioHue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioHue.Name = "radioHue";
            this.radioHue.Size = new System.Drawing.Size(37, 19);
            this.radioHue.TabIndex = 8;
            this.radioHue.TabStop = true;
            this.radioHue.Text = "H:";
            this.radioHue.UseVisualStyleBackColor = true;
            this.radioHue.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // radioGreen
            // 
            this.radioGreen.AutoSize = true;
            this.radioGreen.Location = new System.Drawing.Point(357, 52);
            this.radioGreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioGreen.Name = "radioGreen";
            this.radioGreen.Size = new System.Drawing.Size(36, 19);
            this.radioGreen.TabIndex = 4;
            this.radioGreen.Text = "G:";
            this.radioGreen.UseVisualStyleBackColor = true;
            this.radioGreen.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // numBlue
            // 
            this.numBlue.Location = new System.Drawing.Point(407, 82);
            this.numBlue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBlue.Name = "numBlue";
            this.numBlue.Size = new System.Drawing.Size(63, 23);
            this.numBlue.TabIndex = 7;
            this.numBlue.ValueChanged += new System.EventHandler(this.numBlue_ValueChanged);
            // 
            // numGreen
            // 
            this.numGreen.Location = new System.Drawing.Point(407, 52);
            this.numGreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numGreen.Name = "numGreen";
            this.numGreen.Size = new System.Drawing.Size(63, 23);
            this.numGreen.TabIndex = 5;
            this.numGreen.ValueChanged += new System.EventHandler(this.numGreen_ValueChanged);
            // 
            // radioBlue
            // 
            this.radioBlue.AutoSize = true;
            this.radioBlue.Location = new System.Drawing.Point(357, 82);
            this.radioBlue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioBlue.Name = "radioBlue";
            this.radioBlue.Size = new System.Drawing.Size(35, 19);
            this.radioBlue.TabIndex = 6;
            this.radioBlue.Text = "B:";
            this.radioBlue.UseVisualStyleBackColor = true;
            this.radioBlue.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "ini";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // texturePreviewContainer
            // 
            this.texturePreviewContainer.Controls.Add(this.texturePreviewImg);
            this.texturePreviewContainer.Enabled = false;
            this.texturePreviewContainer.Location = new System.Drawing.Point(862, 35);
            this.texturePreviewContainer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.texturePreviewContainer.Name = "texturePreviewContainer";
            this.texturePreviewContainer.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.texturePreviewContainer.Size = new System.Drawing.Size(490, 400);
            this.texturePreviewContainer.TabIndex = 9;
            this.texturePreviewContainer.TabStop = false;
            this.texturePreviewContainer.Text = "Texture Preview";
            this.texturePreviewContainer.Visible = false;
            // 
            // texturePreviewImg
            // 
            this.texturePreviewImg.Location = new System.Drawing.Point(7, 22);
            this.texturePreviewImg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.texturePreviewImg.Name = "texturePreviewImg";
            this.texturePreviewImg.Size = new System.Drawing.Size(476, 370);
            this.texturePreviewImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.texturePreviewImg.TabIndex = 0;
            this.texturePreviewImg.TabStop = false;
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenu_FileTab,
            this.toolStripMenu_HelpTab});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.toolStripMenu.Size = new System.Drawing.Size(1366, 24);
            this.toolStripMenu.TabIndex = 11;
            this.toolStripMenu.Text = "menuStrip1";
            // 
            // toolStripMenu_FileTab
            // 
            this.toolStripMenu_FileTab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenu_New,
            this.toolStripMenu_Open,
            this.toolStripMenu_Save,
            this.toolStripMenu_SaveAs});
            this.toolStripMenu_FileTab.Name = "toolStripMenu_FileTab";
            this.toolStripMenu_FileTab.Size = new System.Drawing.Size(37, 22);
            this.toolStripMenu_FileTab.Text = "File";
            // 
            // toolStripMenu_New
            // 
            this.toolStripMenu_New.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenu_New_DefaultProfile,
            this.toolStripMenu_New_BlankProfile});
            this.toolStripMenu_New.Name = "toolStripMenu_New";
            this.toolStripMenu_New.Size = new System.Drawing.Size(114, 22);
            this.toolStripMenu_New.Text = "New";
            // 
            // toolStripMenu_New_DefaultProfile
            // 
            this.toolStripMenu_New_DefaultProfile.Name = "toolStripMenu_New_DefaultProfile";
            this.toolStripMenu_New_DefaultProfile.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenu_New_DefaultProfile.Text = "Default Profile";
            this.toolStripMenu_New_DefaultProfile.Click += new System.EventHandler(this.toolStripNewDefaultProfileButton_Click);
            // 
            // toolStripMenu_New_BlankProfile
            // 
            this.toolStripMenu_New_BlankProfile.Name = "toolStripMenu_New_BlankProfile";
            this.toolStripMenu_New_BlankProfile.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenu_New_BlankProfile.Text = "Blank Profile";
            this.toolStripMenu_New_BlankProfile.Click += new System.EventHandler(this.toolStripNewBlankProfileButton_Click);
            // 
            // toolStripMenu_Open
            // 
            this.toolStripMenu_Open.Name = "toolStripMenu_Open";
            this.toolStripMenu_Open.Size = new System.Drawing.Size(114, 22);
            this.toolStripMenu_Open.Text = "Open";
            this.toolStripMenu_Open.Click += new System.EventHandler(this.toolStripOpenButton_Click);
            // 
            // toolStripMenu_Save
            // 
            this.toolStripMenu_Save.Name = "toolStripMenu_Save";
            this.toolStripMenu_Save.Size = new System.Drawing.Size(114, 22);
            this.toolStripMenu_Save.Text = "Save";
            this.toolStripMenu_Save.Click += new System.EventHandler(this.toolStripSaveButton_Click);
            // 
            // toolStripMenu_SaveAs
            // 
            this.toolStripMenu_SaveAs.Name = "toolStripMenu_SaveAs";
            this.toolStripMenu_SaveAs.Size = new System.Drawing.Size(114, 22);
            this.toolStripMenu_SaveAs.Text = "Save As";
            this.toolStripMenu_SaveAs.Click += new System.EventHandler(this.toolStripSaveAsButton_Click);
            // 
            // toolStripMenu_HelpTab
            // 
            this.toolStripMenu_HelpTab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenu_Changelog,
            this.toolStripMenu_CheckForUpdates,
            this.toolStripMenu_About});
            this.toolStripMenu_HelpTab.Name = "toolStripMenu_HelpTab";
            this.toolStripMenu_HelpTab.Size = new System.Drawing.Size(44, 22);
            this.toolStripMenu_HelpTab.Text = "Help";
            // 
            // toolStripMenu_Changelog
            // 
            this.toolStripMenu_Changelog.Name = "toolStripMenu_Changelog";
            this.toolStripMenu_Changelog.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenu_Changelog.Text = "Changelog";
            // 
            // toolStripMenu_CheckForUpdates
            // 
            this.toolStripMenu_CheckForUpdates.Name = "toolStripMenu_CheckForUpdates";
            this.toolStripMenu_CheckForUpdates.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenu_CheckForUpdates.Text = "Check for Updates";
            this.toolStripMenu_CheckForUpdates.Click += new System.EventHandler(this.toolStripCheckForUpdates_Click);
            // 
            // toolStripMenu_About
            // 
            this.toolStripMenu_About.Name = "toolStripMenu_About";
            this.toolStripMenu_About.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenu_About.Text = "About";
            // 
            // ColorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1366, 449);
            this.Controls.Add(this.texturePreviewContainer);
            this.Controls.Add(this.editorContainer);
            this.Controls.Add(this.toolStripMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.toolStripMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "ColorEditor";
            this.Text = "Clone Hero Color Editor";
            this.Load += new System.EventHandler(this.ColorEditor_Load);
            this.editorContainer.Panel1.ResumeLayout(false);
            this.editorContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editorContainer)).EndInit();
            this.editorContainer.ResumeLayout(false);
            this.groupBox_ItemList.ResumeLayout(false);
            this.tabControl_Sections.ResumeLayout(false);
            this.guitarPage.ResumeLayout(false);
            this.drumsPage.ResumeLayout(false);
            this.otherPage.ResumeLayout(false);
            this.colorPickerContainer.ResumeLayout(false);
            this.colorPickerContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLuminance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreen)).EndInit();
            this.texturePreviewContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.texturePreviewImg)).EndInit();
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox guitarList;
        private System.Windows.Forms.SplitContainer editorContainer;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label labelHex;
        private System.Windows.Forms.Label textboxCurrentColor;
        private System.Windows.Forms.Label labelCurrent;
        private System.Windows.Forms.NumericUpDown numLuminance;
        private System.Windows.Forms.RadioButton radioLuminance;
        private System.Windows.Forms.NumericUpDown numSaturation;
        private System.Windows.Forms.RadioButton radioSaturation;
        private System.Windows.Forms.NumericUpDown numHue;
        private System.Windows.Forms.RadioButton radioHue;
        private System.Windows.Forms.NumericUpDown numBlue;
        private System.Windows.Forms.RadioButton radioBlue;
        private System.Windows.Forms.NumericUpDown numGreen;
        private System.Windows.Forms.RadioButton radioGreen;
        private System.Windows.Forms.NumericUpDown numRed;
        private System.Windows.Forms.RadioButton radioRed;
        private MechanikaDesign.WinForms.UI.ColorPicker.ColorSliderVertical colorSlider;
        private MechanikaDesign.WinForms.UI.ColorPicker.ColorBox2D colorBox2D;
        private System.Windows.Forms.TabControl tabControl_Sections;
        private System.Windows.Forms.TabPage guitarPage;
        private System.Windows.Forms.TabPage drumsPage;
        private System.Windows.Forms.TabPage otherPage;
        private System.Windows.Forms.ListBox drumsList;
        private System.Windows.Forms.ListBox otherList;
        private System.Windows.Forms.TextBox textboxHexColor;
        private System.Windows.Forms.Button updateColorBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox texturePreviewContainer;
        private System.Windows.Forms.PictureBox texturePreviewImg;
        private System.Windows.Forms.MenuStrip toolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_FileTab;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_New;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_Open;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_Save;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_SaveAs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_HelpTab;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_Changelog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_CheckForUpdates;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_About;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_New_DefaultProfile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenu_New_BlankProfile;
        private System.Windows.Forms.GroupBox groupBox_ItemList;
        private System.Windows.Forms.GroupBox colorPickerContainer;
    }
}

