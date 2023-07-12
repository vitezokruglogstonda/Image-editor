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
    public partial class HuffmanCoding_Dialog : Form
    {
        public bool Coding { get; set; }
        public HuffmanCoding_Dialog()
        {
            InitializeComponent();
            this.Yes_button.DialogResult = DialogResult.OK;
            this.No_button.DialogResult = DialogResult.OK;
        }

        private void No_button_Click(object sender, EventArgs e)
        {
            this.Coding = false;
            this.Close();
        }

        private void Yes_button_Click(object sender, EventArgs e)
        {
            this.Coding = true;
            this.Close();
        }
    }
}
