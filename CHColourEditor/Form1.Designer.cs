
namespace CHColourEditor
{
    partial class ColourEditor
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
            this.openFileBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileOpened = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.guitarList = new System.Windows.Forms.ListBox();
            this.editorContainer = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.guitarPage = new System.Windows.Forms.TabPage();
            this.drumsPage = new System.Windows.Forms.TabPage();
            this.drumsList = new System.Windows.Forms.ListBox();
            this.otherPage = new System.Windows.Forms.TabPage();
            this.otherList = new System.Windows.Forms.ListBox();
            this.updateColorBtn = new System.Windows.Forms.Button();
            this.textboxHexColor = new System.Windows.Forms.TextBox();
            this.numLuminance = new System.Windows.Forms.NumericUpDown();
            this.radioLuminance = new System.Windows.Forms.RadioButton();
            this.numSaturation = new System.Windows.Forms.NumericUpDown();
            this.radioSaturation = new System.Windows.Forms.RadioButton();
            this.numHue = new System.Windows.Forms.NumericUpDown();
            this.radioHue = new System.Windows.Forms.RadioButton();
            this.numBlue = new System.Windows.Forms.NumericUpDown();
            this.radioBlue = new System.Windows.Forms.RadioButton();
            this.numGreen = new System.Windows.Forms.NumericUpDown();
            this.radioGreen = new System.Windows.Forms.RadioButton();
            this.numRed = new System.Windows.Forms.NumericUpDown();
            this.radioRed = new System.Windows.Forms.RadioButton();
            this.colorSlider = new MechanikaDesign.WinForms.UI.ColorPicker.ColorSliderVertical();
            this.colorBox2D = new MechanikaDesign.WinForms.UI.ColorPicker.ColorBox2D();
            this.labelHex = new System.Windows.Forms.Label();
            this.labelCurrentColor = new System.Windows.Forms.Label();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.editorContainer)).BeginInit();
            this.editorContainer.Panel1.SuspendLayout();
            this.editorContainer.Panel2.SuspendLayout();
            this.editorContainer.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.guitarPage.SuspendLayout();
            this.drumsPage.SuspendLayout();
            this.otherPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLuminance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRed)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileBtn
            // 
            this.openFileBtn.Location = new System.Drawing.Point(15, 12);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(75, 23);
            this.openFileBtn.TabIndex = 0;
            this.openFileBtn.Text = "Open File";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileOpened
            // 
            this.fileOpened.AutoSize = true;
            this.fileOpened.Location = new System.Drawing.Point(96, 17);
            this.fileOpened.Name = "fileOpened";
            this.fileOpened.Size = new System.Drawing.Size(96, 13);
            this.fileOpened.TabIndex = 1;
            this.fileOpened.Text = "File Opened: None";
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Location = new System.Drawing.Point(637, 409);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save File";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Visible = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // guitarList
            // 
            this.guitarList.FormattingEnabled = true;
            this.guitarList.Location = new System.Drawing.Point(3, 3);
            this.guitarList.Name = "guitarList";
            this.guitarList.Size = new System.Drawing.Size(253, 316);
            this.guitarList.TabIndex = 0;
            this.guitarList.SelectedIndexChanged += new System.EventHandler(this.guitarList_SelectedIndexChanged);
            // 
            // editorContainer
            // 
            this.editorContainer.Enabled = false;
            this.editorContainer.Location = new System.Drawing.Point(12, 41);
            this.editorContainer.Name = "editorContainer";
            // 
            // editorContainer.Panel1
            // 
            this.editorContainer.Panel1.Controls.Add(this.tabControl1);
            // 
            // editorContainer.Panel2
            // 
            this.editorContainer.Panel2.Controls.Add(this.updateColorBtn);
            this.editorContainer.Panel2.Controls.Add(this.textboxHexColor);
            this.editorContainer.Panel2.Controls.Add(this.numLuminance);
            this.editorContainer.Panel2.Controls.Add(this.radioLuminance);
            this.editorContainer.Panel2.Controls.Add(this.numSaturation);
            this.editorContainer.Panel2.Controls.Add(this.radioSaturation);
            this.editorContainer.Panel2.Controls.Add(this.numHue);
            this.editorContainer.Panel2.Controls.Add(this.radioHue);
            this.editorContainer.Panel2.Controls.Add(this.numBlue);
            this.editorContainer.Panel2.Controls.Add(this.radioBlue);
            this.editorContainer.Panel2.Controls.Add(this.numGreen);
            this.editorContainer.Panel2.Controls.Add(this.radioGreen);
            this.editorContainer.Panel2.Controls.Add(this.numRed);
            this.editorContainer.Panel2.Controls.Add(this.radioRed);
            this.editorContainer.Panel2.Controls.Add(this.colorSlider);
            this.editorContainer.Panel2.Controls.Add(this.colorBox2D);
            this.editorContainer.Panel2.Controls.Add(this.labelHex);
            this.editorContainer.Panel2.Controls.Add(this.labelCurrentColor);
            this.editorContainer.Panel2.Controls.Add(this.labelCurrent);
            this.editorContainer.Size = new System.Drawing.Size(701, 362);
            this.editorContainer.SplitterDistance = 274;
            this.editorContainer.TabIndex = 8;
            this.editorContainer.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.guitarPage);
            this.tabControl1.Controls.Add(this.drumsPage);
            this.tabControl1.Controls.Add(this.otherPage);
            this.tabControl1.Location = new System.Drawing.Point(3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(267, 348);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // guitarPage
            // 
            this.guitarPage.Controls.Add(this.guitarList);
            this.guitarPage.Location = new System.Drawing.Point(4, 22);
            this.guitarPage.Name = "guitarPage";
            this.guitarPage.Padding = new System.Windows.Forms.Padding(3);
            this.guitarPage.Size = new System.Drawing.Size(259, 322);
            this.guitarPage.TabIndex = 0;
            this.guitarPage.Text = "Guitar";
            this.guitarPage.UseVisualStyleBackColor = true;
            // 
            // drumsPage
            // 
            this.drumsPage.Controls.Add(this.drumsList);
            this.drumsPage.Location = new System.Drawing.Point(4, 22);
            this.drumsPage.Name = "drumsPage";
            this.drumsPage.Padding = new System.Windows.Forms.Padding(3);
            this.drumsPage.Size = new System.Drawing.Size(259, 322);
            this.drumsPage.TabIndex = 1;
            this.drumsPage.Text = "Drums";
            this.drumsPage.UseVisualStyleBackColor = true;
            // 
            // drumsList
            // 
            this.drumsList.FormattingEnabled = true;
            this.drumsList.Location = new System.Drawing.Point(3, 3);
            this.drumsList.Name = "drumsList";
            this.drumsList.Size = new System.Drawing.Size(253, 316);
            this.drumsList.TabIndex = 1;
            this.drumsList.SelectedIndexChanged += new System.EventHandler(this.drumsList_SelectedIndexChanged);
            // 
            // otherPage
            // 
            this.otherPage.Controls.Add(this.otherList);
            this.otherPage.Location = new System.Drawing.Point(4, 22);
            this.otherPage.Name = "otherPage";
            this.otherPage.Padding = new System.Windows.Forms.Padding(3);
            this.otherPage.Size = new System.Drawing.Size(259, 322);
            this.otherPage.TabIndex = 2;
            this.otherPage.Text = "Other";
            this.otherPage.UseVisualStyleBackColor = true;
            // 
            // otherList
            // 
            this.otherList.FormattingEnabled = true;
            this.otherList.Location = new System.Drawing.Point(3, 3);
            this.otherList.Name = "otherList";
            this.otherList.Size = new System.Drawing.Size(253, 316);
            this.otherList.TabIndex = 1;
            this.otherList.SelectedIndexChanged += new System.EventHandler(this.otherList_SelectedIndexChanged);
            // 
            // updateColorBtn
            // 
            this.updateColorBtn.Location = new System.Drawing.Point(157, 303);
            this.updateColorBtn.Name = "updateColorBtn";
            this.updateColorBtn.Size = new System.Drawing.Size(94, 23);
            this.updateColorBtn.TabIndex = 32;
            this.updateColorBtn.Text = "Update Color";
            this.updateColorBtn.UseVisualStyleBackColor = true;
            this.updateColorBtn.Click += new System.EventHandler(this.updateColorBtn_Click);
            // 
            // textboxHexColor
            // 
            this.textboxHexColor.Location = new System.Drawing.Point(83, 305);
            this.textboxHexColor.Name = "textboxHexColor";
            this.textboxHexColor.Size = new System.Drawing.Size(68, 20);
            this.textboxHexColor.TabIndex = 31;
            this.textboxHexColor.Text = "FFFFFF";
            this.textboxHexColor.TextChanged += new System.EventHandler(this.textboxHexColor_TextChanged);
            // 
            // numLuminance
            // 
            this.numLuminance.Location = new System.Drawing.Point(347, 191);
            this.numLuminance.Name = "numLuminance";
            this.numLuminance.Size = new System.Drawing.Size(54, 20);
            this.numLuminance.TabIndex = 13;
            this.numLuminance.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numLuminance.ValueChanged += new System.EventHandler(this.numLuminance_ValueChanged);
            // 
            // radioLuminance
            // 
            this.radioLuminance.AutoSize = true;
            this.radioLuminance.Location = new System.Drawing.Point(304, 191);
            this.radioLuminance.Name = "radioLuminance";
            this.radioLuminance.Size = new System.Drawing.Size(34, 17);
            this.radioLuminance.TabIndex = 12;
            this.radioLuminance.Text = "L:";
            this.radioLuminance.UseVisualStyleBackColor = true;
            this.radioLuminance.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // numSaturation
            // 
            this.numSaturation.Location = new System.Drawing.Point(347, 165);
            this.numSaturation.Name = "numSaturation";
            this.numSaturation.Size = new System.Drawing.Size(54, 20);
            this.numSaturation.TabIndex = 11;
            this.numSaturation.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numSaturation.ValueChanged += new System.EventHandler(this.numSaturation_ValueChanged);
            // 
            // radioSaturation
            // 
            this.radioSaturation.AutoSize = true;
            this.radioSaturation.Location = new System.Drawing.Point(304, 165);
            this.radioSaturation.Name = "radioSaturation";
            this.radioSaturation.Size = new System.Drawing.Size(35, 17);
            this.radioSaturation.TabIndex = 10;
            this.radioSaturation.Text = "S:";
            this.radioSaturation.UseVisualStyleBackColor = true;
            this.radioSaturation.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // numHue
            // 
            this.numHue.Location = new System.Drawing.Point(347, 139);
            this.numHue.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numHue.Name = "numHue";
            this.numHue.Size = new System.Drawing.Size(54, 20);
            this.numHue.TabIndex = 9;
            this.numHue.ValueChanged += new System.EventHandler(this.numHue_ValueChanged);
            // 
            // radioHue
            // 
            this.radioHue.AutoSize = true;
            this.radioHue.Checked = true;
            this.radioHue.Location = new System.Drawing.Point(304, 139);
            this.radioHue.Name = "radioHue";
            this.radioHue.Size = new System.Drawing.Size(36, 17);
            this.radioHue.TabIndex = 8;
            this.radioHue.TabStop = true;
            this.radioHue.Text = "H:";
            this.radioHue.UseVisualStyleBackColor = true;
            this.radioHue.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // numBlue
            // 
            this.numBlue.Location = new System.Drawing.Point(347, 95);
            this.numBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numBlue.Name = "numBlue";
            this.numBlue.Size = new System.Drawing.Size(54, 20);
            this.numBlue.TabIndex = 7;
            this.numBlue.ValueChanged += new System.EventHandler(this.numBlue_ValueChanged);
            // 
            // radioBlue
            // 
            this.radioBlue.AutoSize = true;
            this.radioBlue.Location = new System.Drawing.Point(304, 95);
            this.radioBlue.Name = "radioBlue";
            this.radioBlue.Size = new System.Drawing.Size(35, 17);
            this.radioBlue.TabIndex = 6;
            this.radioBlue.Text = "B:";
            this.radioBlue.UseVisualStyleBackColor = true;
            this.radioBlue.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // numGreen
            // 
            this.numGreen.Location = new System.Drawing.Point(347, 69);
            this.numGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numGreen.Name = "numGreen";
            this.numGreen.Size = new System.Drawing.Size(54, 20);
            this.numGreen.TabIndex = 5;
            this.numGreen.ValueChanged += new System.EventHandler(this.numGreen_ValueChanged);
            // 
            // radioGreen
            // 
            this.radioGreen.AutoSize = true;
            this.radioGreen.Location = new System.Drawing.Point(304, 69);
            this.radioGreen.Name = "radioGreen";
            this.radioGreen.Size = new System.Drawing.Size(36, 17);
            this.radioGreen.TabIndex = 4;
            this.radioGreen.Text = "G:";
            this.radioGreen.UseVisualStyleBackColor = true;
            this.radioGreen.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // numRed
            // 
            this.numRed.Location = new System.Drawing.Point(347, 43);
            this.numRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numRed.Name = "numRed";
            this.numRed.Size = new System.Drawing.Size(54, 20);
            this.numRed.TabIndex = 3;
            this.numRed.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numRed.ValueChanged += new System.EventHandler(this.numRed_ValueChanged);
            // 
            // radioRed
            // 
            this.radioRed.AutoSize = true;
            this.radioRed.Location = new System.Drawing.Point(304, 43);
            this.radioRed.Name = "radioRed";
            this.radioRed.Size = new System.Drawing.Size(36, 17);
            this.radioRed.TabIndex = 2;
            this.radioRed.Text = "R:";
            this.radioRed.UseVisualStyleBackColor = true;
            this.radioRed.CheckedChanged += new System.EventHandler(this.ColorModeChangedHandler);
            // 
            // colorSlider
            // 
            this.colorSlider.ColorMode = MechanikaDesign.WinForms.UI.ColorPicker.ColorModes.Hue;
            this.colorSlider.ColorRGB = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorSlider.Location = new System.Drawing.Point(257, 34);
            this.colorSlider.Name = "colorSlider";
            this.colorSlider.NubColor = System.Drawing.Color.White;
            this.colorSlider.Position = 142;
            this.colorSlider.Size = new System.Drawing.Size(40, 252);
            this.colorSlider.TabIndex = 1;
            this.colorSlider.ColorChanged += new MechanikaDesign.WinForms.UI.ColorPicker.ColorSliderVertical.ColorChangedEventHandler(this.colorSlider_ColorChanged);
            // 
            // colorBox2D
            // 
            this.colorBox2D.ColorMode = MechanikaDesign.WinForms.UI.ColorPicker.ColorModes.Hue;
            this.colorBox2D.ColorRGB = System.Drawing.Color.Red;
            this.colorBox2D.Location = new System.Drawing.Point(6, 34);
            this.colorBox2D.Name = "colorBox2D";
            this.colorBox2D.Size = new System.Drawing.Size(245, 252);
            this.colorBox2D.TabIndex = 0;
            this.colorBox2D.ColorChanged += new MechanikaDesign.WinForms.UI.ColorPicker.ColorBox2D.ColorChangedEventHandler(this.colorBox2D_ColorChanged);
            // 
            // labelHex
            // 
            this.labelHex.AutoSize = true;
            this.labelHex.Location = new System.Drawing.Point(80, 289);
            this.labelHex.Name = "labelHex";
            this.labelHex.Size = new System.Drawing.Size(26, 13);
            this.labelHex.TabIndex = 30;
            this.labelHex.Text = "Hex";
            // 
            // labelCurrentColor
            // 
            this.labelCurrentColor.BackColor = System.Drawing.Color.White;
            this.labelCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelCurrentColor.Location = new System.Drawing.Point(3, 305);
            this.labelCurrentColor.Name = "labelCurrentColor";
            this.labelCurrentColor.Size = new System.Drawing.Size(68, 20);
            this.labelCurrentColor.TabIndex = 29;
            // 
            // labelCurrent
            // 
            this.labelCurrent.AutoSize = true;
            this.labelCurrent.Location = new System.Drawing.Point(3, 289);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(41, 13);
            this.labelCurrent.TabIndex = 28;
            this.labelCurrent.Text = "Current";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // ColourEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(723, 441);
            this.Controls.Add(this.editorContainer);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.fileOpened);
            this.Controls.Add(this.openFileBtn);
            this.MaximizeBox = false;
            this.Name = "ColourEditor";
            this.Text = "Clone Hero Color Editor";
            this.Load += new System.EventHandler(this.ColourEditor_Load);
            this.editorContainer.Panel1.ResumeLayout(false);
            this.editorContainer.Panel2.ResumeLayout(false);
            this.editorContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorContainer)).EndInit();
            this.editorContainer.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.guitarPage.ResumeLayout(false);
            this.drumsPage.ResumeLayout(false);
            this.otherPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numLuminance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label fileOpened;
        private System.Windows.Forms.ListBox guitarList;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.SplitContainer editorContainer;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label labelHex;
        private System.Windows.Forms.Label labelCurrentColor;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage guitarPage;
        private System.Windows.Forms.TabPage drumsPage;
        private System.Windows.Forms.TabPage otherPage;
        private System.Windows.Forms.ListBox drumsList;
        private System.Windows.Forms.ListBox otherList;
        private System.Windows.Forms.TextBox textboxHexColor;
        private System.Windows.Forms.Button updateColorBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

