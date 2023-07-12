
namespace ObradaSlika
{
    partial class HistogramCutting_Dialog
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
            this.Threshold_Input = new System.Windows.Forms.TextBox();
            this.Label_C = new System.Windows.Forms.Label();
            this.Ok_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter threshold for histogram cutting:";
            // 
            // Threshold_Input
            // 
            this.Threshold_Input.Location = new System.Drawing.Point(224, 6);
            this.Threshold_Input.Name = "Threshold_Input";
            this.Threshold_Input.Size = new System.Drawing.Size(77, 23);
            this.Threshold_Input.TabIndex = 1;
            // 
            // Label_C
            // 
            this.Label_C.AutoSize = true;
            this.Label_C.Location = new System.Drawing.Point(12, 38);
            this.Label_C.Name = "Label_C";
            this.Label_C.Size = new System.Drawing.Size(38, 15);
            this.Label_C.TabIndex = 2;
            this.Label_C.Text = "label2";
            // 
            // Ok_button
            // 
            this.Ok_button.Location = new System.Drawing.Point(224, 68);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(77, 23);
            this.Ok_button.TabIndex = 3;
            this.Ok_button.Text = "OK";
            this.Ok_button.UseVisualStyleBackColor = true;
            this.Ok_button.Click += new System.EventHandler(this.Ok_Click);
            // 
            // HistogramCutting_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 103);
            this.Controls.Add(this.Ok_button);
            this.Controls.Add(this.Label_C);
            this.Controls.Add(this.Threshold_Input);
            this.Controls.Add(this.label1);
            this.Name = "HistogramCutting_Dialog";
            this.Text = "HistogramCutting_Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Threshold_Input;
        private System.Windows.Forms.Label Label_C;
        private System.Windows.Forms.Button Ok_button;
    }
}