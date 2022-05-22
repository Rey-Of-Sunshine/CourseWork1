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
    public partial class End_Reload : Form
    {
        public End_Reload(GameProcess gameProcess)
        {
            InitializeComponent();
            this.gameProcess = gameProcess;

        }

        GameProcess gameProcess;


        private void buttonReload_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Application.Restart();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void End_Reload_Load(object sender, EventArgs e)
        {
            winer.Text = gameProcess.winer;
        }
    }
}
