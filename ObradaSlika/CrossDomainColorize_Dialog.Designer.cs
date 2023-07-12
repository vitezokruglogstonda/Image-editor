
namespace ObradaSlika
{
    partial class CrossDomainColorize_Dialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.Hue_input = new System.Windows.Forms.NumericUpDown();
            this.Saturation_input = new System.Windows.Forms.NumericUpDown();
            this.Ok_button = new System.Windows.Forms.Button();
            this.CheckBox_Enable = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Hue_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Saturation_input)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter HUE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter Saturation (optional):";
            // 
            // Hue_input
            // 
            this.Hue_input.Location = new System.Drawing.Point(181, 7);
            this.Hue_input.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.Hue_input.Name = "Hue_input";
            this.Hue_input.Size = new System.Drawing.Size(120, 23);
            this.Hue_input.TabIndex = 2;
            // 
            // Saturation_input
            // 
            this.Saturation_input.DecimalPlaces = 2;
            this.Saturation_input.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Saturation_input.Location = new System.Drawing.Point(181, 41);
            this.Saturation_input.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Saturation_input.Name = "Saturation_input";
            this.Saturation_input.Size = new System.Drawing.Size(120, 23);
            this.Saturation_input.TabIndex = 3;
            // 
            // Ok_button
            // 
            this.Ok_button.Location = new System.Drawing.Point(125, 81);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(75, 23);
            this.Ok_button.TabIndex = 4;
            this.Ok_button.Text = "OK";
            this.Ok_button.UseVisualStyleBackColor = true;
            this.Ok_button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // CheckBox_Enable
            // 
            this.CheckBox_Enable.AutoSize = true;
            this.CheckBox_Enable.Location = new System.Drawing.Point(315, 42);
            this.CheckBox_Enable.Name = "CheckBox_Enable";
            this.CheckBox_Enable.Size = new System.Drawing.Size(61, 19);
            this.CheckBox_Enable.TabIndex = 5;
            this.CheckBox_Enable.Text = "Enable";
            this.CheckBox_Enable.UseVisualStyleBackColor = true;
            this.CheckBox_Enable.Click += new System.EventHandler(this.Enable_Saturation);
            // 
            // CrossDomainColorize_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 117);
            this.Controls.Add(this.CheckBox_Enable);
            this.Controls.Add(this.Ok_button);
            this.Controls.Add(this.Saturation_input);
            this.Controls.Add(this.Hue_input);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CrossDomainColorize_Dialog";
            this.Text = "HSV input";
            ((System.ComponentModel.ISupportInitialize)(this.Hue_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Saturation_input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown Hue_input;
        private System.Windows.Forms.NumericUpDown Saturation_input;
        private System.Windows.Forms.Button Ok_button;
        private System.Windows.Forms.CheckBox CheckBox_Enable;
    }
}