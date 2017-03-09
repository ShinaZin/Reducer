namespace Reducer
{
    partial class FormSettingsOfReduce
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.trackBarVowels = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.numericSyllables = new System.Windows.Forms.NumericUpDown();
            this.checkBoxDeleteSpaces = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteNewLines = new System.Windows.Forms.CheckBox();
            this.numericSyllToHyphen = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVowels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSyllables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSyllToHyphen)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Максимально слогов:";
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(16, 227);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 2;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // trackBarVowels
            // 
            this.trackBarVowels.LargeChange = 10;
            this.trackBarVowels.Location = new System.Drawing.Point(12, 71);
            this.trackBarVowels.Maximum = 100;
            this.trackBarVowels.Minimum = 1;
            this.trackBarVowels.Name = "trackBarVowels";
            this.trackBarVowels.Size = new System.Drawing.Size(142, 45);
            this.trackBarVowels.SmallChange = 5;
            this.trackBarVowels.TabIndex = 3;
            this.trackBarVowels.Value = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Удалить процент гласных:";
            // 
            // numericSyllables
            // 
            this.numericSyllables.Location = new System.Drawing.Point(16, 29);
            this.numericSyllables.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericSyllables.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSyllables.Name = "numericSyllables";
            this.numericSyllables.Size = new System.Drawing.Size(138, 20);
            this.numericSyllables.TabIndex = 5;
            this.numericSyllables.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // checkBoxDeleteSpaces
            // 
            this.checkBoxDeleteSpaces.AutoSize = true;
            this.checkBoxDeleteSpaces.Checked = true;
            this.checkBoxDeleteSpaces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDeleteSpaces.Location = new System.Drawing.Point(16, 110);
            this.checkBoxDeleteSpaces.Name = "checkBoxDeleteSpaces";
            this.checkBoxDeleteSpaces.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxDeleteSpaces.Size = new System.Drawing.Size(157, 17);
            this.checkBoxDeleteSpaces.TabIndex = 6;
            this.checkBoxDeleteSpaces.Text = "Удалить лишние пробелы";
            this.checkBoxDeleteSpaces.UseVisualStyleBackColor = true;
            // 
            // checkBoxDeleteNewLines
            // 
            this.checkBoxDeleteNewLines.AutoSize = true;
            this.checkBoxDeleteNewLines.Location = new System.Drawing.Point(16, 133);
            this.checkBoxDeleteNewLines.Name = "checkBoxDeleteNewLines";
            this.checkBoxDeleteNewLines.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxDeleteNewLines.Size = new System.Drawing.Size(154, 17);
            this.checkBoxDeleteNewLines.TabIndex = 7;
            this.checkBoxDeleteNewLines.Text = "Удалить переводы строк";
            this.checkBoxDeleteNewLines.UseVisualStyleBackColor = true;
            // 
            // numericSyllToHyphen
            // 
            this.numericSyllToHyphen.Location = new System.Drawing.Point(16, 191);
            this.numericSyllToHyphen.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericSyllToHyphen.Name = "numericSyllToHyphen";
            this.numericSyllToHyphen.Size = new System.Drawing.Size(138, 20);
            this.numericSyllToHyphen.TabIndex = 8;
            this.numericSyllToHyphen.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Сократить дефисом, если слогов больше, чем";
            // 
            // FormSettingsOfReduce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 256);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericSyllToHyphen);
            this.Controls.Add(this.checkBoxDeleteNewLines);
            this.Controls.Add(this.checkBoxDeleteSpaces);
            this.Controls.Add(this.numericSyllables);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trackBarVowels);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(357, 298);
            this.MinimumSize = new System.Drawing.Size(357, 298);
            this.Name = "FormSettingsOfReduce";
            this.Text = "Настройки сокращения";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVowels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSyllables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSyllToHyphen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.TrackBar trackBarVowels;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericSyllables;
        private System.Windows.Forms.CheckBox checkBoxDeleteSpaces;
        private System.Windows.Forms.CheckBox checkBoxDeleteNewLines;
        private System.Windows.Forms.NumericUpDown numericSyllToHyphen;
        private System.Windows.Forms.Label label3;
    }
}