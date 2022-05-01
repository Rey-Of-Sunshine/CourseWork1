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

            gameField.Width = 440;
            gameField.Height = 440;

            field = new GameField(gameField.Width, gameField.Height);
            field.Placement(figures);
        }

        bool clicTr = false, clicRect = false, clicCicle = false, dlt = true, plaer = true;
        int touchX, touchY;
        int coins = 150;
        int costT = 13, costR = 13, costC = 12;


        Figures[,] figures = new Figures[12, 12];
        Figures remember;
        GameField field;
        Graphics graphics;
        //Form f = new Start();


        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            clicTr = true;
            clicRect = false;
            clicCicle = false;
            dlt = false;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            clicTr = false;
            clicRect = true;
            clicCicle = false;
            dlt = false;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            clicTr = false;
            clicRect = false;
            clicCicle = true;
            dlt = false;
        }
        private void dealet_Click(object sender, EventArgs e)
        {
            clicTr = false;
            clicRect = false;
            clicCicle = false;
            dlt = true;
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            touchX = field.TouchCellX(e.X);
            touchY = field.TouchCellY(e.Y);
            int delta = 6;
            int h = (int)field.GetSizeCellH() - delta;
            int w = (int)field.GetSizeCellW() - delta;
            float x = 4 + delta / 2 + touchX * field.GetSizeCellW();
            float y = 4 + delta / 2 + touchY * field.GetSizeCellH();

            //create and dealet object //в одну ячейку не должно помещаться более одной фигуры
            if (field.TouchCell(e.X, e.Y, touchX, touchY) && touchY >= 7)
            {
                if (clicTr && coins >= 12 && figures[touchX, touchY] == null)
                {
                    figures[touchX, touchY] = new Triangle(x, y, w, h, Color.Blue, Color.Black, plaer);
                    coins -= costT;
                    //clicTr = false;
                    remember = figures[touchX, touchY];
                }
                if (clicRect && coins >= 12 && figures[touchX, touchY] == null)
                {
                    figures[touchX, touchY] = new Rect(x, y, w, h, Color.Blue, Color.Black, plaer);
                    coins -= costR;
                    //clicRect = false;
                    remember = figures[touchX, touchY];
                }
                if (clicCicle && coins >= 12 && figures[touchX, touchY] == null)
                {
                    figures[touchX, touchY] = new Circle(x, y, w, h, Color.Blue, Color.Black, plaer);
                    coins -= costC;
                    //clicCicle = false;
                    remember = figures[touchX, touchY];
                }
                if (dlt)
                {
                    if (figures[touchX, touchY] is Triangle) coins += costT;
                    if (figures[touchX, touchY] is Rect) coins += costR;
                    if (figures[touchX, touchY] is Circle) coins += costC;
                    figures[touchX, touchY] = null;
                }
            }
            quantitiTtiangle.Text = Convert.ToString(coins / costT);
            quantitiRectangle.Text = Convert.ToString(coins / costR);
            quantitiCircle.Text = Convert.ToString(coins / costC);
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            int h = (int)field.GetSizeCellH();
            int w = (int)field.GetSizeCellW();

            gameField.Image = new Bitmap(gameField.Width, gameField.Height);
            graphics = Graphics.FromImage(gameField.Image);

            //draw grid
            for (int i = 0; i < 15; i++)
            {
                if (i == 7 || i==5) field.Draw(graphics, 4, 3 + i * h, gameField.Width - 4, 3 + i * h);
                field.Draw(graphics, 4 + i * w, 4, 4 + i * w, gameField.Height - 4);
                field.Draw(graphics, 4, 4 + i * h, gameField.Width - 4, 4 + i * h);
            }

            //draw figures
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (figures[i, j] != null) figures[i, j].Draw(graphics);
                }
            }


            Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //for (int i = 0; i < 12; i++)
            //{
            //    for (int j = 0; j < 12; j++)
            //    {
            //        if (figures[i, j] != null) figures[i, j].Move();
            //    }
            //}

            Refresh();
        }

        private void buttonTriangle_Paint(object sender, PaintEventArgs e)
        {
            Figures trf = new Triangle(5, 5, buttonTriangle.Width - 10, buttonTriangle.Height - 10, Color.Black, Color.Black, plaer);
            trf.Draw(e.Graphics);
        }


        private void buttonRectangle_Paint(object sender, PaintEventArgs e)
        {
            Figures trf1 = new Rect(5, 5, buttonRectangle.Width - 10, buttonRectangle.Height - 10, Color.Black, Color.Black, plaer);
            trf1.Draw(e.Graphics);
        }

        private void buttonCircle_Paint(object sender, PaintEventArgs e)
        {
            Figures trf2 = new Circle(5, 5, buttonCircle.Width - 10, buttonCircle.Height - 10, Color.Black, Color.Black, plaer);
            trf2.Draw(e.Graphics);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            (new StartWindow()).ShowDialog();
            quantitiTtiangle.Text = Convert.ToString(coins / costT);
            quantitiRectangle.Text = Convert.ToString(coins / costR);
            quantitiCircle.Text = Convert.ToString(coins / costC);
        }


    }
}
