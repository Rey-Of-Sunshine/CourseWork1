using System;
using System.Collections.Generic;
using System.Drawing;
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
            game = new Game(field, selectedFigure, figs);
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
        int stap = 0;
        int coins = 150;                                                     
        int costT = 13, costR = 13, costC = 12;

        Game game;
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
            touchX = field.TouchCellX(e.X);                                                                                             ////
            touchY = field.TouchCellY(e.Y);                                                                                             ////
            int delta = 6;                                                                                                              ////
            int h = (int)field.GetSizeCellH() - delta;                                                                                  ////
            int w = (int)field.GetSizeCellW() - delta;                                                                                  ////
            float x = 4 + delta / 2 + touchX * field.GetSizeCellW();                                                                    ////
            float y = 4 + delta / 2 + touchY * field.GetSizeCellH();                                                                    ////
                                                                                                                                        ////
            //create and delete object //в одну ячейку не должно помещаться более одной фигуры                                          ////
            if (field.TouchCell(e.X, e.Y) && touchY >= 7)                                                                               ////
            {                                                                                                                           ////
                                                                                                                                        ////
                if (selectedFigure == SelectedFigure.Delete)                                                                            ////
                {                                                                                                                       ////
                    if (figures[touchX, touchY] is Triangle) coins += costT;                                                            ////
                    if (figures[touchX, touchY] is Rect) coins += costR;                                                                ////
                    if (figures[touchX, touchY] is Circle) coins += costC;                                                              ////
                    figures[touchX, touchY] = null;                                                                                     ////
                }                                                                                                                       ////
                else if (CheckPlacement(touchX, touchY))                                                                                ////
                {                                                                                                                       ////
                    figures[touchX, touchY] = figs[selectedFigure].Clone(touchX, touchY, x, y, w, h, Color.Blue, Color.Black, true);    ////
                    coins -= costT;                                                                                                     ////
                }                                                                                                                       ////
            }
            quantitiTtiangle.Text = Convert.ToString(coins / costT);
            quantitiRectangle.Text = Convert.ToString(coins / costR);
            quantitiCircle.Text = Convert.ToString(coins / costC);
        }

        private bool CheckPlacement(int x, int y) => coins >= 12 && figures[x, y] == null;


        public void Queue(int a)
        {
            switch (a)
            {
                case 0:
                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (figures[i, j] is Triangle && figures[i, j].isPlayer) figures[i, j].Move(figures, rnd, field);
                        }
                    }
                    stap++;
                    break;
                case 1:

                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (figures[i, j] is Triangle && !figures[i, j].isPlayer) figures[i, j].Move(figures, rnd, field);
                        }
                    }
                    stap++;
                    break;
                case 2:
                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (figures[i, j] is Rect && figures[i, j].isPlayer) figures[i, j].Move(figures, rnd, field);
                        }
                    }
                    stap++;
                    break;
                case 3:
                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (figures[i, j] is Rect && !figures[i, j].isPlayer) figures[i, j].Move(figures, rnd, field);
                        }
                    }
                    stap++;
                    break;
                case 4:
                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (figures[i, j] is Circle && figures[i, j].isPlayer) figures[i, j].Move(figures, rnd, field);
                        }
                    }
                    stap++;
                    break;
                case 5:
                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (figures[i, j] is Circle && !figures[i, j].isPlayer) figures[i, j].Move(figures, rnd, field);
                        }
                    }
                    stap++;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (clicStart)
            {
                Queue(stap % 6);
            }
            Refresh();
        }

        private void gameField_Paint(object sender, PaintEventArgs e)
        {
            //draw grid
            field.DrawGrid(e.Graphics);

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
            new Circle(-1, -1, 5, 5, buttonCircle.Width - 10, buttonCircle.Height - 10, Color.Black, Color.Black, player).Draw(e.Graphics);
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
