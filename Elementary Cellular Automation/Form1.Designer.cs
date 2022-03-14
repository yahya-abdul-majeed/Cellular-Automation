
namespace Elementary_Cellular_Automation
{
    partial class Form1
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
            this.BtnStartStop = new System.Windows.Forms.Button();
            this.ruleText = new System.Windows.Forms.NumericUpDown();
            this.Rule = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ruleText)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(448, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // BtnStartStop
            // 
            this.BtnStartStop.Location = new System.Drawing.Point(115, 383);
            this.BtnStartStop.Name = "BtnStartStop";
            this.BtnStartStop.Size = new System.Drawing.Size(172, 64);
            this.BtnStartStop.TabIndex = 1;
            this.BtnStartStop.Text = "Generate";
            this.BtnStartStop.UseVisualStyleBackColor = true;
            this.BtnStartStop.Click += new System.EventHandler(this.BtnStartStop_Click);
            // 
            // ruleText
            // 
            this.ruleText.Location = new System.Drawing.Point(157, 335);
            this.ruleText.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ruleText.Name = "ruleText";
            this.ruleText.Size = new System.Drawing.Size(130, 22);
            this.ruleText.TabIndex = 2;
            this.ruleText.Value = new decimal(new int[] {
            110,
            0,
            0,
            0});
            // 
            // Rule
            // 
            this.Rule.AutoSize = true;
            this.Rule.Location = new System.Drawing.Point(112, 337);
            this.Rule.Name = "Rule";
            this.Rule.Size = new System.Drawing.Size(37, 17);
            this.Rule.TabIndex = 3;
            this.Rule.Text = "Rule";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fill First Row to generate pattern";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(136, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 780);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rule);
            this.Controls.Add(this.ruleText);
            this.Controls.Add(this.BtnStartStop);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ruleText)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnStartStop;
        private System.Windows.Forms.NumericUpDown ruleText;
        private System.Windows.Forms.Label Rule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}