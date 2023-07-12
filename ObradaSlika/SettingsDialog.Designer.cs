
namespace ObradaSlika
{
    partial class SettingsDialog
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
            this.BufferSize = new System.Windows.Forms.NumericUpDown();
            this.ProcessingMode_Standard = new System.Windows.Forms.RadioButton();
            this.ProcessingMode_Unsafe = new System.Windows.Forms.RadioButton();
            this.Execution_New = new System.Windows.Forms.RadioButton();
            this.Execution_Old = new System.Windows.Forms.RadioButton();
            this.Apply_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.KernelSize = new System.Windows.Forms.NumericUpDown();
            this.ProcessingMode_Group = new System.Windows.Forms.GroupBox();
            this.Execution_Group = new System.Windows.Forms.GroupBox();
            this.Channel_Group = new System.Windows.Forms.GroupBox();
            this.FilterChannel_No = new System.Windows.Forms.RadioButton();
            this.FilterChannel_Yes = new System.Windows.Forms.RadioButton();
            this.Colorize_Group = new System.Windows.Forms.GroupBox();
            this.Colorize_Custom = new System.Windows.Forms.RadioButton();
            this.Colorize_Default = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.BufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KernelSize)).BeginInit();
            this.ProcessingMode_Group.SuspendLayout();
            this.Execution_Group.SuspendLayout();
            this.Channel_Group.SuspendLayout();
            this.Colorize_Group.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buffer size:";
            // 
            // BufferSize
            // 
            this.BufferSize.Location = new System.Drawing.Point(82, 9);
            this.BufferSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.BufferSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BufferSize.Name = "BufferSize";
            this.BufferSize.Size = new System.Drawing.Size(45, 23);
            this.BufferSize.TabIndex = 1;
            this.BufferSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ProcessingMode_Standard
            // 
            this.ProcessingMode_Standard.AutoSize = true;
            this.ProcessingMode_Standard.Location = new System.Drawing.Point(6, 22);
            this.ProcessingMode_Standard.Name = "ProcessingMode_Standard";
            this.ProcessingMode_Standard.Size = new System.Drawing.Size(72, 19);
            this.ProcessingMode_Standard.TabIndex = 6;
            this.ProcessingMode_Standard.TabStop = true;
            this.ProcessingMode_Standard.Text = "Standard";
            this.ProcessingMode_Standard.UseVisualStyleBackColor = true;
            this.ProcessingMode_Standard.Click += new System.EventHandler(this.Standard_CheckUncheck);
            // 
            // ProcessingMode_Unsafe
            // 
            this.ProcessingMode_Unsafe.AutoSize = true;
            this.ProcessingMode_Unsafe.Location = new System.Drawing.Point(97, 22);
            this.ProcessingMode_Unsafe.Name = "ProcessingMode_Unsafe";
            this.ProcessingMode_Unsafe.Size = new System.Drawing.Size(61, 19);
            this.ProcessingMode_Unsafe.TabIndex = 7;
            this.ProcessingMode_Unsafe.TabStop = true;
            this.ProcessingMode_Unsafe.Text = "Unsafe";
            this.ProcessingMode_Unsafe.UseVisualStyleBackColor = true;
            this.ProcessingMode_Unsafe.Click += new System.EventHandler(this.Unsafe_CheckUncheck);
            // 
            // Execution_New
            // 
            this.Execution_New.AutoSize = true;
            this.Execution_New.Location = new System.Drawing.Point(6, 22);
            this.Execution_New.Name = "Execution_New";
            this.Execution_New.Size = new System.Drawing.Size(85, 19);
            this.Execution_New.TabIndex = 8;
            this.Execution_New.TabStop = true;
            this.Execution_New.Text = "New Image";
            this.Execution_New.UseVisualStyleBackColor = true;
            this.Execution_New.Click += new System.EventHandler(this.Execution_New_CheckUncheck);
            // 
            // Execution_Old
            // 
            this.Execution_Old.AutoSize = true;
            this.Execution_Old.Location = new System.Drawing.Point(97, 22);
            this.Execution_Old.Name = "Execution_Old";
            this.Execution_Old.Size = new System.Drawing.Size(80, 19);
            this.Execution_Old.TabIndex = 9;
            this.Execution_Old.TabStop = true;
            this.Execution_Old.Text = "Old Image";
            this.Execution_Old.UseVisualStyleBackColor = true;
            this.Execution_Old.Click += new System.EventHandler(this.Execution_Old_CheckUncheck);
            // 
            // Apply_button
            // 
            this.Apply_button.Location = new System.Drawing.Point(119, 168);
            this.Apply_button.Name = "Apply_button";
            this.Apply_button.Size = new System.Drawing.Size(75, 23);
            this.Apply_button.TabIndex = 10;
            this.Apply_button.Text = "Apply";
            this.Apply_button.UseVisualStyleBackColor = true;
            this.Apply_button.Click += new System.EventHandler(this.Apply_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Location = new System.Drawing.Point(200, 168);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.TabIndex = 11;
            this.Cancel_button.Text = "Cancel";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Filter dimension (n X n):";
            // 
            // KernelSize
            // 
            this.KernelSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.KernelSize.Location = new System.Drawing.Point(339, 9);
            this.KernelSize.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.KernelSize.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.KernelSize.Name = "KernelSize";
            this.KernelSize.Size = new System.Drawing.Size(45, 23);
            this.KernelSize.TabIndex = 13;
            this.KernelSize.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // ProcessingMode_Group
            // 
            this.ProcessingMode_Group.Controls.Add(this.ProcessingMode_Standard);
            this.ProcessingMode_Group.Controls.Add(this.ProcessingMode_Unsafe);
            this.ProcessingMode_Group.Location = new System.Drawing.Point(12, 47);
            this.ProcessingMode_Group.Name = "ProcessingMode_Group";
            this.ProcessingMode_Group.Size = new System.Drawing.Size(182, 52);
            this.ProcessingMode_Group.TabIndex = 14;
            this.ProcessingMode_Group.TabStop = false;
            this.ProcessingMode_Group.Text = "Processing mode:";
            // 
            // Execution_Group
            // 
            this.Execution_Group.Controls.Add(this.Execution_New);
            this.Execution_Group.Controls.Add(this.Execution_Old);
            this.Execution_Group.Location = new System.Drawing.Point(200, 47);
            this.Execution_Group.Name = "Execution_Group";
            this.Execution_Group.Size = new System.Drawing.Size(182, 52);
            this.Execution_Group.TabIndex = 15;
            this.Execution_Group.TabStop = false;
            this.Execution_Group.Text = "Operations executed on:";
            // 
            // Channel_Group
            // 
            this.Channel_Group.Controls.Add(this.FilterChannel_No);
            this.Channel_Group.Controls.Add(this.FilterChannel_Yes);
            this.Channel_Group.Location = new System.Drawing.Point(12, 105);
            this.Channel_Group.Name = "Channel_Group";
            this.Channel_Group.Size = new System.Drawing.Size(182, 54);
            this.Channel_Group.TabIndex = 16;
            this.Channel_Group.TabStop = false;
            this.Channel_Group.Text = "Separate channel filtering:";
            // 
            // FilterChannel_No
            // 
            this.FilterChannel_No.AutoSize = true;
            this.FilterChannel_No.Location = new System.Drawing.Point(97, 22);
            this.FilterChannel_No.Name = "FilterChannel_No";
            this.FilterChannel_No.Size = new System.Drawing.Size(41, 19);
            this.FilterChannel_No.TabIndex = 1;
            this.FilterChannel_No.TabStop = true;
            this.FilterChannel_No.Text = "No";
            this.FilterChannel_No.UseVisualStyleBackColor = true;
            this.FilterChannel_No.Click += new System.EventHandler(this.FilterChannel_No_CheckUncheck);
            // 
            // FilterChannel_Yes
            // 
            this.FilterChannel_Yes.AutoSize = true;
            this.FilterChannel_Yes.Location = new System.Drawing.Point(6, 22);
            this.FilterChannel_Yes.Name = "FilterChannel_Yes";
            this.FilterChannel_Yes.Size = new System.Drawing.Size(42, 19);
            this.FilterChannel_Yes.TabIndex = 0;
            this.FilterChannel_Yes.TabStop = true;
            this.FilterChannel_Yes.Text = "Yes";
            this.FilterChannel_Yes.UseVisualStyleBackColor = true;
            this.FilterChannel_Yes.Click += new System.EventHandler(this.FilterChannel_Yes_CheckUncheck);
            // 
            // Colorize_Group
            // 
            this.Colorize_Group.Controls.Add(this.Colorize_Custom);
            this.Colorize_Group.Controls.Add(this.Colorize_Default);
            this.Colorize_Group.Location = new System.Drawing.Point(200, 105);
            this.Colorize_Group.Name = "Colorize_Group";
            this.Colorize_Group.Size = new System.Drawing.Size(182, 54);
            this.Colorize_Group.TabIndex = 17;
            this.Colorize_Group.TabStop = false;
            this.Colorize_Group.Text = "Colorization:";
            // 
            // Colorize_Custom
            // 
            this.Colorize_Custom.AutoSize = true;
            this.Colorize_Custom.Location = new System.Drawing.Point(97, 21);
            this.Colorize_Custom.Name = "Colorize_Custom";
            this.Colorize_Custom.Size = new System.Drawing.Size(67, 19);
            this.Colorize_Custom.TabIndex = 1;
            this.Colorize_Custom.TabStop = true;
            this.Colorize_Custom.Text = "Custom";
            this.Colorize_Custom.UseVisualStyleBackColor = true;
            this.Colorize_Custom.Click += new System.EventHandler(this.Colorize_Custom_CheckUncheck);
            // 
            // Colorize_Default
            // 
            this.Colorize_Default.AutoSize = true;
            this.Colorize_Default.Location = new System.Drawing.Point(7, 21);
            this.Colorize_Default.Name = "Colorize_Default";
            this.Colorize_Default.Size = new System.Drawing.Size(63, 19);
            this.Colorize_Default.TabIndex = 0;
            this.Colorize_Default.TabStop = true;
            this.Colorize_Default.Text = "Default";
            this.Colorize_Default.UseVisualStyleBackColor = true;
            this.Colorize_Default.Click += new System.EventHandler(this.Colorize_Default_CheckUncheck);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(394, 203);
            this.Controls.Add(this.Colorize_Group);
            this.Controls.Add(this.Channel_Group);
            this.Controls.Add(this.Execution_Group);
            this.Controls.Add(this.ProcessingMode_Group);
            this.Controls.Add(this.KernelSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Apply_button);
            this.Controls.Add(this.BufferSize);
            this.Controls.Add(this.label1);
            this.Name = "SettingsDialog";
            this.Text = "SettingsDialog";
            ((System.ComponentModel.ISupportInitialize)(this.BufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KernelSize)).EndInit();
            this.ProcessingMode_Group.ResumeLayout(false);
            this.ProcessingMode_Group.PerformLayout();
            this.Execution_Group.ResumeLayout(false);
            this.Execution_Group.PerformLayout();
            this.Channel_Group.ResumeLayout(false);
            this.Channel_Group.PerformLayout();
            this.Colorize_Group.ResumeLayout(false);
            this.Colorize_Group.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown BufferSize;
        private System.Windows.Forms.RadioButton ProcessingMode_Standard;
        private System.Windows.Forms.RadioButton ProcessingMode_Unsafe;
        private System.Windows.Forms.RadioButton Execution_New;
        private System.Windows.Forms.RadioButton Execution_Old;
        private System.Windows.Forms.Button Apply_button;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown KernelSize;
        private System.Windows.Forms.GroupBox ProcessingMode_Group;
        private System.Windows.Forms.GroupBox Execution_Group;
        private System.Windows.Forms.GroupBox Channel_Group;
        private System.Windows.Forms.RadioButton FilterChannel_No;
        private System.Windows.Forms.RadioButton FilterChannel_Yes;
        private System.Windows.Forms.GroupBox Colorize_Group;
        private System.Windows.Forms.RadioButton Colorize_Custom;
        private System.Windows.Forms.RadioButton Colorize_Default;
    }
}