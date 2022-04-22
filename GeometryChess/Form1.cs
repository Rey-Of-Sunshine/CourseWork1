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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        bool tr = false;
        List<Figures> figures = new List<Figures>();

        private void button1_Click(object sender, EventArgs e)
        {
            tr=true;
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GameField field = new GameField(pictureBox1.Width - 1, pictureBox1.Height - 1, Properties.Resources.Grid);
            //Size size = new Size(pictureBox1.Width - 1, pictureBox1.Height - 1);
            //Bitmap bt = new Bitmap(Properties.Resources.Grid, size);
            pictureBox1.Image = field.GetBitmap();
            Graphics graphics = Graphics.FromImage(field.GetBitmap());
            if (tr)
            {

                Figures tr = new Triangle(40, 85, 30, 30, Color.Blue);
                tr.Draw(graphics);

                Figures tr1 = new Rect(40, 105, 30, 30, Color.Blue);
                tr1.Draw(graphics);

                Figures tr2 = new Circle(40, 145, 30, 30, Color.Blue);
                tr2.Draw(graphics);


                Figures trf = new Triangle(440, 85, 20, 20, Color.Red);
                trf.Draw(e.Graphics);

                Figures trf1 = new Rect(440, 105, 20, 20, Color.Red);
                trf1.Draw(e.Graphics);

                Figures trf2 = new Circle(440, 145, 20, 20, Color.Red);
                trf2.Draw(e.Graphics);
            }

            Refresh();
        }

    }
}
