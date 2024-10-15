namespace Lab5
{
    partial class Task2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.drawButton = new System.Windows.Forms.Button();
            this.roughnessTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.detailLevelBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailLevelBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(984, 458);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(420, 579);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(165, 23);
            this.drawButton.TabIndex = 1;
            this.drawButton.Text = "Построить ломаную";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // roughnessTextBox
            // 
            this.roughnessTextBox.Location = new System.Drawing.Point(12, 553);
            this.roughnessTextBox.Name = "roughnessTextBox";
            this.roughnessTextBox.Size = new System.Drawing.Size(984, 20);
            this.roughnessTextBox.TabIndex = 2;
            this.roughnessTextBox.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 537);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Шероховатость";
            // 
            // detailLevelBar
            // 
            this.detailLevelBar.Location = new System.Drawing.Point(12, 489);
            this.detailLevelBar.Name = "detailLevelBar";
            this.detailLevelBar.Size = new System.Drawing.Size(984, 45);
            this.detailLevelBar.TabIndex = 5;
            this.detailLevelBar.Value = 5;
            this.detailLevelBar.ValueChanged += new System.EventHandler(this.DrawButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 473);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Этапы";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 614);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.detailLevelBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roughnessTextBox);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailLevelBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.TextBox roughnessTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar detailLevelBar;
        private System.Windows.Forms.Label label2;
    }
}