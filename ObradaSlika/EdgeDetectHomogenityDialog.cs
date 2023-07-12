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
    public partial class EdgeDetectHomogenityDialog : Form
    {
        public int Threshold { get; set; }
        public EdgeDetectHomogenityDialog()
        {
            InitializeComponent();
            this.Ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Ok_click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.ThresholdTextBox.Text))
            {
                this.Threshold = 0;
            }
            else
            {
                this.Threshold = Convert.ToInt32(this.ThresholdTextBox.Text);
            }
        }
    }
}
