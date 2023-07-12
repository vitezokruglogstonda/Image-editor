
namespace ObradaSlika
{
    partial class MeanRemovalDialog
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
            this.N_factor = new System.Windows.Forms.TextBox();
            this.Ok_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter factor (must be >"+this.threshold+"):";
            // 
            // N_factor
            // 
            this.N_factor.Location = new System.Drawing.Point(27, 49);
            this.N_factor.Name = "N_factor";
            this.N_factor.Size = new System.Drawing.Size(142, 23);
            this.N_factor.TabIndex = 1;
            // 
            // Ok_button
            // 
            this.Ok_button.Location = new System.Drawing.Point(60, 88);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(75, 23);
            this.Ok_button.TabIndex = 2;
            this.Ok_button.Text = "OK";
            this.Ok_button.UseVisualStyleBackColor = true;
            this.Ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // MeanRemovalDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 128);
            this.Controls.Add(this.Ok_button);
            this.Controls.Add(this.N_factor);
            this.Controls.Add(this.label1);
            this.Name = "MeanRemovalDialog";
            this.Text = "Factor input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox N_factor;
        private System.Windows.Forms.Button Ok_button;
    }
}