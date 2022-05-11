using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometryChess
{
    public partial class Ruuuules : Form
    {
        public Ruuuules()
        {
            InitializeComponent();
            textBox1.Text = Properties.Resources.Rules1;
        }

        private void Ruuuules_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
