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
    public partial class ColorInputDialog : Form
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public CIE_Model_Pixel CIE { get; set; }

        public ColorInputDialog(CIE_Model_Pixel cie)
        {
            InitializeComponent();
            this.CIE = cie;
            this.Ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void Ok_button_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.Xcomponent.Text))
            {
                this.X = 0.0;
            }
            else
            {
                double new_value = Convert.ToDouble(this.Xcomponent.Text);
                double max_value = 0.9505;
                double min_value = -0.9505;
                if (new_value > max_value)
                {
                    this.X = max_value;
                }
                else if (new_value < min_value)
                {
                    this.X = min_value;
                }
                else
                {
                    this.X = new_value;
                }
            }
            if (String.IsNullOrEmpty(this.Ycomponent.Text))
            {
                this.Y = 0.0;
            }
            else
            {
                double new_value = Convert.ToDouble(this.Ycomponent.Text);
                double max_value = 1.0;
                double min_value = -1.0;
                if (new_value > max_value)
                {
                    this.Y = max_value;
                }
                else if (new_value < min_value)
                {
                    this.Y = min_value;
                }
                else
                {
                    this.Y = new_value;
                }
            }
            if (String.IsNullOrEmpty(this.Zcomponent.Text))
            {
                this.Z = 0.0;
            }
            else
            {
                double new_value = Convert.ToDouble(this.Zcomponent.Text);
                double max_value = 0.8252; //1.089
                double min_value = -0.8252;
                if (new_value > max_value)
                {
                    this.Z = max_value;
                }
                else if (new_value < min_value)
                {
                    this.Z = min_value;
                }
                else
                {
                    this.Z = new_value;
                }
            }

            this.CIE.X = this.X;
            this.CIE.Y = this.Y;
            this.CIE.Z = this.Z;
            this.CIE.XyzToRgb_Negative();
        }
        
        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
