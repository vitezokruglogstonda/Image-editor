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
    public partial class MeanRemovalDialog : Form
    {
        private int threshold;
        public int N { get; set; }
        public MeanRemovalDialog(int dim)
        {
            this.threshold = (dim * dim) - 1; 
            InitializeComponent();
            this.Ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void Ok_button_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(this.N_factor.Text))
            {
                this.Invalidate();
            }
            else
            {
                int value = Convert.ToInt32(this.N_factor.Text);
                if (value > this.threshold)
                {
                    this.N = value;
                }
                else
                {
                    this.Invalidate();
                }
            }
        }
    }
}
