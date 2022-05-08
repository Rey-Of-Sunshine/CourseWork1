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

    enum SelectedFigure { Triangle, Rectangle, Circle, Delete }
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

        bool clicStart = false;

        SelectedFigure selectedFigure = SelectedFigure.Delete;

        Dictionary<SelectedFigure, Figure> figs = new Dictionary<SelectedFigure, Figure>()
        {
            { SelectedFigure.Triangle , new Triangle() },
             { SelectedFigure.Rectangle , new Rect() },
              { SelectedFigure.Circle , new Circle() }
        };

        bool player = true;
        int touchX, touchY;
        int stapPl = 0, stapCm = 0;
        int coins = 150;
        int costT = 13, costR = 13, costC = 12;


        Random rnd = new Random();
        Figure[,] figures = new Figure[12, 12];
        GameField field;


        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            selectedFigure = SelectedFigure.Triangle;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            selectedFigure = SelectedFigure.Rectangle;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            selectedFigure = SelectedFigure.Circle;
        }
        private void dealet_Click(object sender, EventArgs e)
        {
            selectedFigure = SelectedFigure.Delete;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            clicStart = false;
        }

        private void button1_Click(object sender, EventArgs e) // доступность редактора
        {
            clicStart = true;
            buttonTriangle.Enabled = false;
            buttonRectangle.Enabled = false;
            buttonCircle.Enabled = false;
            delete.Enabled = false;
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

            //create and delete object //в одну ячейку не должно помещаться более одной фигуры
            if (field.TouchCell(e.X, e.Y, touchX, touchY) && touchY >= 7)
            {

                if (selectedFigure == SelectedFigure.Delete)
                {
                    if (figures[touchX, touchY] is Triangle) coins += costT;
                    if (figures[touchX, touchY] is Rect) coins += costR;
                    if (figures[touchX, touchY] is Circle) coins += costC;
                    figures[touchX, touchY] = null;
                }
                else if (CheckPlacement(touchX, touchY))
                {
                    figures[touchX, touchY] = figs[selectedFigure].Clone(touchX, touchY, x, y, w, h, Color.Blue, Color.Black, true);
                    coins -= costT;
                }
            }
            quantitiTtiangle.Text = Convert.ToString(coins / costT);
            quantitiRectangle.Text = Convert.ToString(coins / costR);
            quantitiCircle.Text = Convert.ToString(coins / costC);
        }

        private bool CheckPlacement(int x, int y) => coins >= 12 && figures[x, y] == null;

        private bool CheckFigurePl(int a) => stapPl == stapCm && stapPl % 3 == a;
        private bool CheckFigureCm(int a) => stapPl > stapCm && stapCm % 3 == a;

        private void doMovePl (Figure f)
        {
            f.Move(figures, rnd, field);
            stapPl++;
        }

        private void doMoveCm(Figure f)
        {
            f.Move(figures, rnd, field);
            stapCm++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (clicStart)
            {
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (figures[i, j] is Triangle && CheckFigurePl(0)) doMovePl(figures[i, j]);
                        if (figures[i, j] is Triangle && CheckFigureCm(0)) doMoveCm(figures[i, j]);
                        if (figures[i, j] is Rect && CheckFigurePl(1)) doMovePl(figures[i, j]);
                        if (figures[i, j] is Rect && CheckFigureCm(1)) doMoveCm(figures[i, j]);
                        if (figures[i, j] is Circle && CheckFigurePl(2)) doMovePl(figures[i, j]);
                        if (figures[i, j] is Circle && CheckFigureCm(2)) doMoveCm(figures[i, j]);
                        //figures[i, j]?.Move(figures, rnd, field);
                    }
                }
            }
            Refresh();
        }

        private void gameField_Paint(object sender, PaintEventArgs e)
        {
            int h = (int)field.GetSizeCellH();
            int w = (int)field.GetSizeCellW();

            //draw grid
            for (int i = 0; i < 15; i++)
            {
                if (i == 7 || i == 5) e.Graphics.DrawLine(new Pen(Color.Black), 4, 3 + i * h, gameField.Width - 4, 3 + i * h);
                e.Graphics.DrawLine(new Pen(Color.Black), 4 + i * w, 4, 4 + i * w, gameField.Height - 4);
                e.Graphics.DrawLine(new Pen(Color.Black), 4, 4 + i * h, gameField.Width - 4, 4 + i * h);
            }

            //draw figures
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (figures[i, j] != null) figures[i, j].Draw(e.Graphics);
                }
            }
        }

        private void buttonTriangle_Paint(object sender, PaintEventArgs e)
        {
            (new Triangle(-1, -1, 5, 5, buttonTriangle.Width - 10, buttonTriangle.Height - 10, Color.Black, Color.Black, player)).Draw(e.Graphics);
        }


        private void buttonRectangle_Paint(object sender, PaintEventArgs e)
        {
            (new Rect(-1, -1, 5, 5, buttonRectangle.Width - 10, buttonRectangle.Height - 10, Color.Black, Color.Black, player)).Draw(e.Graphics);
        }

        private void buttonCircle_Paint(object sender, PaintEventArgs e)
        {
            (new Circle(-1, -1, 5, 5, buttonCircle.Width - 10, buttonCircle.Height - 10, Color.Black, Color.Black, player)).Draw(e.Graphics);
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
