
namespace ObradaSlika
{
    partial class HuffmanCoding_Dialog
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
            this.Yes_button = new System.Windows.Forms.Button();
            this.No_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Use huffman coding while saving the image?";
            // 
            // Yes_button
            // 
            this.Yes_button.Location = new System.Drawing.Point(59, 40);
            this.Yes_button.Name = "Yes_button";
            this.Yes_button.Size = new System.Drawing.Size(75, 23);
            this.Yes_button.TabIndex = 1;
            this.Yes_button.Text = "YES";
            this.Yes_button.UseVisualStyleBackColor = true;
            this.Yes_button.Click += new System.EventHandler(this.Yes_button_Click);
            // 
            // No_button
            // 
            this.No_button.Location = new System.Drawing.Point(140, 40);
            this.No_button.Name = "No_button";
            this.No_button.Size = new System.Drawing.Size(75, 23);
            this.No_button.TabIndex = 2;
            this.No_button.Text = "NO";
            this.No_button.UseVisualStyleBackColor = true;
            this.No_button.Click += new System.EventHandler(this.No_button_Click);
            // 
            // HuffmanCoding_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 75);
            this.Controls.Add(this.No_button);
            this.Controls.Add(this.Yes_button);
            this.Controls.Add(this.label1);
            this.Name = "HuffmanCoding_Dialog";
            this.Text = "Coding option";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Yes_button;
        private System.Windows.Forms.Button No_button;
    }
}