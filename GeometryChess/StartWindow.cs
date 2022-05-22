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
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartWindow_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
        }
    }
}
