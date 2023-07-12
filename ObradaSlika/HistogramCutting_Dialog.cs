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
    public partial class HistogramCutting_Dialog : Form
    {
        public int C { get; set; }
        public double T { get; set; }
        private double limit;
        private string Label_const = "(Cutting constant: ";
        public HistogramCutting_Dialog(int c, string view)
        {
            InitializeComponent();
            this.C = c;
            this.T = 0;
            this.Label_const += this.C+")";
            this.Label_C.Text = this.Label_const;
            if(String.Equals(view, "Histo_XYZ"))
            {
                this.limit = 0.81;
            }
            else
            {
                this.limit = 256;
            }
            this.Ok_button.DialogResult = DialogResult.OK;
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.Threshold_Input.Text))
            {
                double tmp = double.Parse(this.Threshold_Input.Text);
                if(tmp-this.C > 0 || tmp < this.limit)
                {
                    this.T = tmp;
                }
            }
        }
    }
}
