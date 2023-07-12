
namespace ObradaSlika
{
    partial class SelectChannel_Dialog
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
            this.Channel_ComboBox = new System.Windows.Forms.ComboBox();
            this.Ok_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select 1 of 3 channels for saving:";
            // 
            // Channel_ComboBox
            // 
            this.Channel_ComboBox.FormattingEnabled = true;
            this.Channel_ComboBox.Items.AddRange(new object[] {
            "X channel (top-right)",
            "Y channel (bottom-left)",
            "Z channel (bottom-right)"});
            this.Channel_ComboBox.Location = new System.Drawing.Point(194, 6);
            this.Channel_ComboBox.Name = "Channel_ComboBox";
            this.Channel_ComboBox.Size = new System.Drawing.Size(256, 23);
            this.Channel_ComboBox.TabIndex = 1;
            // 
            // Ok_button
            // 
            this.Ok_button.Location = new System.Drawing.Point(194, 35);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(75, 23);
            this.Ok_button.TabIndex = 2;
            this.Ok_button.Text = "OK";
            this.Ok_button.UseVisualStyleBackColor = true;
            this.Ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // SelectChannel_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 68);
            this.Controls.Add(this.Ok_button);
            this.Controls.Add(this.Channel_ComboBox);
            this.Controls.Add(this.label1);
            this.Name = "SelectChannel_Dialog";
            this.Text = "Channel Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Channel_ComboBox;
        private System.Windows.Forms.Button Ok_button;
    }
}