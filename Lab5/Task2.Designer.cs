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
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(16, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1312, 564);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // drawButton
            // 
            this.drawButton.BackColor = System.Drawing.SystemColors.Info;
            this.drawButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.drawButton.Location = new System.Drawing.Point(1016, 596);
            this.drawButton.Margin = new System.Windows.Forms.Padding(4);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(315, 44);
            this.drawButton.TabIndex = 1;
            this.drawButton.Text = "Построить ломаную";
            this.drawButton.UseVisualStyleBackColor = false;
            this.drawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // roughnessTextBox
            // 
            this.roughnessTextBox.Location = new System.Drawing.Point(680, 602);
            this.roughnessTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.roughnessTextBox.Name = "roughnessTextBox";
            this.roughnessTextBox.Size = new System.Drawing.Size(328, 22);
            this.roughnessTextBox.TabIndex = 2;
            this.roughnessTextBox.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(676, 582);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Шероховатость";
            // 
            // detailLevelBar
            // 
            this.detailLevelBar.BackColor = System.Drawing.Color.White;
            this.detailLevelBar.LargeChange = 1;
            this.detailLevelBar.Location = new System.Drawing.Point(16, 602);
            this.detailLevelBar.Margin = new System.Windows.Forms.Padding(4);
            this.detailLevelBar.Maximum = 15;
            this.detailLevelBar.Name = "detailLevelBar";
            this.detailLevelBar.Size = new System.Drawing.Size(656, 56);
            this.detailLevelBar.TabIndex = 5;
            this.detailLevelBar.Value = 5;
            this.detailLevelBar.ValueChanged += new System.EventHandler(this.DrawButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 582);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Этапы";
            // 
            // Task2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1344, 653);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.detailLevelBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roughnessTextBox);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Task2";
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