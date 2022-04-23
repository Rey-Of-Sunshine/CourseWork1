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
    public partial class GameProcess : Form
    {
        public GameProcess()
        {
            InitializeComponent();


        }

        bool tr = false, clicTr = false, clicRect = false, clicCicle = false;
        int touchX, touchY;
        Figures[,] figures = new Figures[12, 12];
        GameField field;


        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            clicTr = true;
            clicRect = false;
            clicCicle = false;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            clicTr = false;
            clicRect = true;
            clicCicle = false;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            clicTr = false;
            clicRect = false;
            clicCicle = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tr=true;
            Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            touchX = field.TouchCellX(e.X);
            touchY = field.TouchCellY(e.Y);
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            gameField.Width = 440;
            gameField.Height = 440;

            field = new GameField(gameField.Width, gameField.Height); //Properties.Resources.Grid
            gameField.Image = new Bitmap(gameField.Width, gameField.Height);
            Graphics graphics = Graphics.FromImage(gameField.Image);

            int delta = 6;
            int h = (int)field.GetSizeCellW() - delta;
            int w = (int)field.GetSizeCellW() - delta;

            for (int i=0; i<15;i++)
            {
                field.Draw(graphics, 4+i* (int)field.GetSizeCellW(), 4, 4+i * (int)field.GetSizeCellW(), gameField.Height-4);
                field.Draw(graphics, 4, 4+i * (int)field.GetSizeCellH(), gameField.Width-4, 4+i * (int)field.GetSizeCellH());
            }
           
            if (clicTr)
            {
                Figures tr = new Triangle(4 + delta/2 + touchX * field.GetSizeCellW(), 4 + delta / 2 + touchY * field.GetSizeCellH(), w, h, 3, Color.Blue, Color.Black);
                tr.Draw(graphics);
            }

            if (clicRect)
            {
                Figures tr1 = new Rect(4 + delta / 2 + touchX * field.GetSizeCellW(), 4 + delta / 2 + touchY * field.GetSizeCellH(), w, h, 3, Color.Blue, Color.Black);
                tr1.Draw(graphics);
            }

            if (clicCicle)
            {
                Figures tr2 = new Circle(4 + delta / 2 + touchX * field.GetSizeCellW(), 4 + delta / 2 + touchY * field.GetSizeCellH(), w, h, 2, Color.Blue, Color.Black);
                tr2.Draw(graphics);
            }

            if (tr)
            {

                //textBox1.Text = Convert.ToString(touchX * field.GetSizeCellW());
                //textBox2.Text = Convert.ToString(touchY * field.GetSizeCellH());
                //textBox3.Text = Convert.ToString();

            }

            Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void buttonTriangle_Paint(object sender, PaintEventArgs e)
        {
            Figures trf = new Triangle(5, 5, buttonTriangle.Width-10, buttonTriangle.Height-10, 3, Color.Black, Color.Black);
            trf.Draw(e.Graphics);
        }

        private void buttonRectangle_Paint(object sender, PaintEventArgs e)
        {
            Figures trf1 = new Rect(5, 5, buttonRectangle.Width-10, buttonRectangle.Height-10, 3, Color.Black, Color.Black);
            trf1.Draw(e.Graphics);
        }

        private void buttonCircle_Paint(object sender, PaintEventArgs e)
        {
            Figures trf2 = new Circle(5, 5, buttonCircle.Width-10, buttonCircle.Height-10, 2, Color.Black, Color.Black);
            trf2.Draw(e.Graphics);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            quantitiTtiangle.Text = Convert.ToString(100 / 13);
            quantitiRectangle.Text = Convert.ToString(100 / 13);
            quantitiCircle.Text = Convert.ToString(100 / 12);
        }


    }
}
