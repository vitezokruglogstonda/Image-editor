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
    public partial class SelectChannel_Dialog : Form
    {
        public int ChannelIndex { get; set; }
        public SelectChannel_Dialog()
        {
            InitializeComponent();
            this.ChannelIndex = 0;
            this.Ok_button.DialogResult = DialogResult.OK;
        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            this.ChannelIndex = this.Channel_ComboBox.SelectedIndex;
            this.Close();
        }
    }
}
