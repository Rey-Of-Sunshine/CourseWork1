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

        bool clicTr = false, clicRect = false, clicCicle = false, dlt = true;
        int touchX, touchY;
        int coins = 100;

        Random comPlan;
        Figures[,] figures = new Figures[12, 12];
        Figures remember;
        GameField field;
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
            int h = (int)field.GetSizeCellW() - delta;
            int w = (int)field.GetSizeCellW() - delta;

            if (field.TouchCell(e.X, e.Y, touchX, touchY))
            { 
                if (clicTr)
                {
                    figures[touchX, touchY] = new Triangle(4 + delta / 2 + touchX * field.GetSizeCellW(), 4 + delta / 2 + touchY * field.GetSizeCellH(), w, h, 13, coins, Color.Blue, Color.Black);
                    coins -= 13;
                    remember = figures[touchX, touchY];
                }
                if (clicRect)
                {
                    figures[touchX, touchY] = new Rect(4 + delta / 2 + touchX * field.GetSizeCellW(), 4 + delta / 2 + touchY * field.GetSizeCellH(), w, h, 13, coins, Color.Blue, Color.Black);
                    coins -= 13;
                    remember = figures[touchX, touchY];
                }
                if (clicCicle)
                {
                    figures[touchX, touchY] = new Circle(4 + delta / 2 + touchX * field.GetSizeCellW(), 4 + delta / 2 + touchY * field.GetSizeCellH(), w, h, 12, coins, Color.Blue, Color.Black);
                    coins -= 12;
                    remember = figures[touchX, touchY];
                }
                if (dlt)
                {
                    figures[touchX, touchY] = null;
                }
            }
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

            //draw grid
            for (int i=0; i<15;i++)
            {
                field.Draw(graphics, 4+i* (int)field.GetSizeCellW(), 4, 4+i * (int)field.GetSizeCellW(), gameField.Height-4);
                field.Draw(graphics, 4, 4+i * (int)field.GetSizeCellH(), gameField.Width-4, 4+i * (int)field.GetSizeCellH());
            }
            
            for (int i=0; i<12;i++)
            {
                for (int j=0; j<12;j++)
                {
                    if (figures[i, j]!=null) figures[i, j].Draw(graphics);
                }
            }
           

            Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void buttonTriangle_Paint(object sender, PaintEventArgs e)
        {
            Figures trf = new Triangle(5, 5, buttonTriangle.Width-10, buttonTriangle.Height-10, Color.Black, Color.Black);
            trf.Draw(e.Graphics);
        }


        private void buttonRectangle_Paint(object sender, PaintEventArgs e)
        {
            Figures trf1 = new Rect(5, 5, buttonRectangle.Width-10, buttonRectangle.Height-10, Color.Black, Color.Black);
            trf1.Draw(e.Graphics);
        }

        private void buttonCircle_Paint(object sender, PaintEventArgs e)
        {
            Figures trf2 = new Circle(5, 5, buttonCircle.Width-10, buttonCircle.Height-10, Color.Black, Color.Black);
            trf2.Draw(e.Graphics);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (remember!=null)
            {
                quantitiTtiangle.Text = Convert.ToString(((Triangle)remember).Quatiti());
                quantitiRectangle.Text = Convert.ToString(((Rect)remember).Quatiti());
                quantitiCircle.Text = Convert.ToString(((Circle)remember).Quatiti());
            }
            quantitiTtiangle.Text = Convert.ToString(100/13);
            quantitiRectangle.Text = Convert.ToString(100/13);
            quantitiCircle.Text = Convert.ToString(100/12);

            Refresh();
            //f.ShowDialog();
        }


    }
}
