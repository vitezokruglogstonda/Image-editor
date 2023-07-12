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
    public partial class CrossDomainColorize_Dialog : Form
    {
        public double Hue { get; set; }
        public double? Saturation { get; set; }
        public CrossDomainColorize_Dialog()
        {
            InitializeComponent();
            this.Hue = 1;
            this.Saturation = null;
            this.Saturation_input.BackColor = Color.Gray;
            this.Saturation_input.Enabled = false;
            this.Ok_button.DialogResult = DialogResult.OK;
        }
        private void Enable_Saturation(object sender, EventArgs e)
        {
            if(this.CheckBox_Enable.Checked == true)
            {
                this.Saturation_input.Enabled = true;
                this.Saturation_input.BackColor = Color.White;
            }
            else
            {
                this.Saturation_input.Enabled = false;
                this.Saturation_input.BackColor = Color.Gray;
            }
        }

        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (this.CheckBox_Enable.Checked)
            {
                this.Saturation = Convert.ToDouble(this.Saturation_input.Value);
            }
            else
            {
                this.Saturation = null;
            }
            this.Hue = Convert.ToDouble(this.Hue_input.Value);
            this.Close();
        }
        
    }
}
