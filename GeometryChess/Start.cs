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
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        Form f = new GameProcess();

        private void buttonStart_Click(object sender, EventArgs e)
        {
            f.Show();
            Hide();
        }
    }
}
