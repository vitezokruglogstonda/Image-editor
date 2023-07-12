using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObradaSlika
{
    public partial class SettingsDialog : Form
    {
        public int Buffer_Size { get; set; }
        public bool UnsafeMode { get; set; }
        public bool NewImage { get; set; }
        public int Kernel_Size { get; set; }
        public bool FilterChannels { get; set; }
        public bool SimpleColorize { get; set; }        
        public SettingsDialog(int bufferSize, int kernelSize, bool unsafeMode, bool newImage, bool filterChannels, bool simpleColorize)
        {
            InitializeComponent();
            this.Buffer_Size = bufferSize;
            this.Kernel_Size = kernelSize;
            this.UnsafeMode = unsafeMode;
            this.NewImage = newImage;
            this.FilterChannels = filterChannels;
            this.SimpleColorize = simpleColorize;
            this.Apply_button.DialogResult = DialogResult.OK;
            this.Cancel_button.DialogResult = DialogResult.Cancel;
            this.Refresh();
        }
        private void Refresh()
        {
            this.BufferSize.Value = this.Buffer_Size;
            this.KernelSize.Value = this.Kernel_Size;
            if (this.UnsafeMode)
            {
                this.ProcessingMode_Standard.Checked = false;
                this.ProcessingMode_Unsafe.Checked = true;
            }
            else
            {
                this.ProcessingMode_Unsafe.Checked = false;
                this.ProcessingMode_Standard.Checked = true;
            }
            if (this.NewImage)
            {
                this.Execution_New.Checked = true;
                this.Execution_Old.Checked = false;
            }
            else
            {
                this.Execution_Old.Checked = true;
                this.Execution_New.Checked = false;
            }
            if (this.FilterChannels)
            {
                this.FilterChannel_Yes.Checked = true;
                this.FilterChannel_No.Checked = false;
            }
            else
            {
                this.FilterChannel_No.Checked = true;
                this.FilterChannel_Yes.Checked = false;
            }
            if (this.SimpleColorize)
            {
                this.Colorize_Custom.Checked = true;
                this.Colorize_Default.Checked = false;
            }
            else
            {
                this.Colorize_Default.Checked = true;
                this.Colorize_Custom.Checked = false;
            }
            this.Invalidate();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Apply_button_Click(object sender, EventArgs e)
        {
            this.Buffer_Size = (int)this.BufferSize.Value;
            this.Kernel_Size = (int)this.KernelSize.Value;
            if (this.ProcessingMode_Standard.Checked)
            {
                this.UnsafeMode = false;
            }
            else if(this.ProcessingMode_Unsafe.Checked)
            {
                this.UnsafeMode = true;
            }
            if (this.Execution_New.Checked)
            {
                this.NewImage = true;
            }
            else if (this.Execution_Old.Checked)
            {
                this.NewImage = false;
            }
            if (this.FilterChannel_Yes.Checked)
            {
                this.FilterChannels = true;
            }
            else if (this.FilterChannel_No.Checked)
            {
                this.FilterChannels = false;
            }
            if (this.Colorize_Custom.Checked)
            {
                this.SimpleColorize = true;
            }
            else if (this.Colorize_Default.Checked)
            {
                this.SimpleColorize = false;
            }
        }

        private void Standard_CheckUncheck(object sender, EventArgs e)
        {
            if (this.ProcessingMode_Standard.Checked)
            {
                this.UnsafeMode = false;
                this.Refresh();
            }
        }

        private void Unsafe_CheckUncheck(object sender, EventArgs e)
        {
            if (this.ProcessingMode_Unsafe.Checked)
            {
                this.UnsafeMode = true;
                this.Refresh();
            }
        }

        private void Execution_New_CheckUncheck(object sender, EventArgs e)
        {
            if (this.Execution_New.Checked)
            {
                this.NewImage = true;
                this.Refresh();
            }
        }

        private void Execution_Old_CheckUncheck(object sender, EventArgs e)
        {
            if (this.Execution_Old.Checked)
            {
                this.NewImage = false;
                this.Refresh();
            }
        }

        private void FilterChannel_Yes_CheckUncheck(object sender, EventArgs e)
        {
            if (this.FilterChannel_Yes.Checked)
            {
                this.FilterChannels = true;
                this.Refresh();
            }
        }

        private void FilterChannel_No_CheckUncheck(object sender, EventArgs e)
        {
            if (this.FilterChannel_No.Checked)
            {
                this.FilterChannels = false;
                this.Refresh();
            }
        }
        private void Colorize_Default_CheckUncheck(object sender, EventArgs e)
        {
            if (this.Colorize_Default.Checked)
            {
                this.SimpleColorize = false;
                this.Refresh();
            }
        }
        private void Colorize_Custom_CheckUncheck(object sender, EventArgs e)
        {
            if (this.Colorize_Custom.Checked)
            {
                this.SimpleColorize = true;
                this.Refresh();
            }
        }
    }
}
