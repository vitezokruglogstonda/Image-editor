
namespace ObradaSlika
{
    partial class ColorInputDialog
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Xcomponent = new System.Windows.Forms.TextBox();
            this.Ycomponent = new System.Windows.Forms.TextBox();
            this.Zcomponent = new System.Windows.Forms.TextBox();
            this.Ok_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter values (x,y,z):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "X (-0.9505 : 0.9505):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Y (-1.0 : 1.0):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Z (-0.8252 : 0.8252):";
            // 
            // Xcomponent
            // 
            this.Xcomponent.Location = new System.Drawing.Point(161, 68);
            this.Xcomponent.Name = "Xcomponent";
            this.Xcomponent.Size = new System.Drawing.Size(100, 23);
            this.Xcomponent.TabIndex = 4;
            // 
            // Ycomponent
            // 
            this.Ycomponent.Location = new System.Drawing.Point(161, 105);
            this.Ycomponent.Name = "Ycomponent";
            this.Ycomponent.Size = new System.Drawing.Size(100, 23);
            this.Ycomponent.TabIndex = 5;
            // 
            // Zcomponent
            // 
            this.Zcomponent.Location = new System.Drawing.Point(161, 141);
            this.Zcomponent.Name = "Zcomponent";
            this.Zcomponent.Size = new System.Drawing.Size(100, 23);
            this.Zcomponent.TabIndex = 6;
            // 
            // Ok_button
            // 
            this.Ok_button.Location = new System.Drawing.Point(57, 205);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(75, 23);
            this.Ok_button.TabIndex = 7;
            this.Ok_button.Text = "OK";
            this.Ok_button.UseVisualStyleBackColor = true;
            this.Ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Location = new System.Drawing.Point(161, 205);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.TabIndex = 8;
            this.Cancel_button.Text = "Cancel";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // ColorInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(309, 259);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Ok_button);
            this.Controls.Add(this.Zcomponent);
            this.Controls.Add(this.Ycomponent);
            this.Controls.Add(this.Xcomponent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ColorInputDialog";
            this.Text = "CIE color input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Xcomponent;
        private System.Windows.Forms.TextBox Ycomponent;
        private System.Windows.Forms.TextBox Zcomponent;
        private System.Windows.Forms.Button Ok_button;
        private System.Windows.Forms.Button Cancel_button;
    }
}