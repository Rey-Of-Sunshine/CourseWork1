using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace GeometryChess
{

    enum SelectedFigure { Triangle, Rectangle, Circle, Delete, Null }
    public partial class GameProcess : Form
    {
        public GameProcess()
        {
            InitializeComponent();

            windowFinish = new End_Reload(this);

            gameField.Width = 440;
            gameField.Height = 440;

            field = new GameField(gameField.Width, gameField.Height);
            game = new Game(field, selectedFigure);

            tr = new Triangle(-1, -1, 5, 5, buttonTriangle.Width - 10, buttonTriangle.Height - 10, Color.Black, Color.Black, true);
            rect = new Rect(-1, -1, 5, 5, buttonRectangle.Width - 10, buttonRectangle.Height - 10, Color.Black, Color.Black, true);
            circle = new Circle(-1, -1, 5, 5, buttonCircle.Width - 10, buttonCircle.Height - 10, Color.Black, Color.Black, true);
        }

        bool clicStart = false;
        public string winer { get; private set; }

        SelectedFigure selectedFigure = SelectedFigure.Delete;

        Triangle tr;
        Rect rect;
        Circle circle;
        Game game;
        GameField field;
        End_Reload windowFinish;

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
            selectedFigure = SelectedFigure.Null;
            buttonTriangle.Enabled = false;
            buttonRectangle.Enabled = false;
            buttonCircle.Enabled = false;
            delete.Enabled = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            game.Placement(e.X, e.Y, selectedFigure);

            quantitiTriangle.Text = Convert.ToString(game.GetQuantiti(new Triangle()));
            quantitiRectangle.Text = Convert.ToString(game.GetQuantiti(new Rect()));
            quantitiCircle.Text = Convert.ToString(game.GetQuantiti(new Circle()));
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (clicStart)
            {
                game.Queue();
                if (game.Winner(true) == 1)
                {
                    clicStart = false;
                    Enabled = false;
                    winer = "Победа!";
                    windowFinish.Show();
                    //MessageBox.Show(winer);
                }
                else if (game.Winner(false) == 2)
                {
                    clicStart = false;
                    Enabled = false;
                    winer = "Вы проиграли!";
                    windowFinish.Show();
                    //MessageBox.Show(winer);
                }
            }
            Refresh();
        }

        private void gameField_Paint(object sender, PaintEventArgs e)
        {
            game.DrawField(e.Graphics);
        }

        private void buttonTriangle_Paint(object sender, PaintEventArgs e)
        {
            tr.Draw(e.Graphics);
        }


        private void buttonRectangle_Paint(object sender, PaintEventArgs e)
        {
            rect.Draw(e.Graphics);
        }

        private void buttonCircle_Paint(object sender, PaintEventArgs e)
        {
            circle.Draw(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            (new StartWindow()).ShowDialog();
            game.Placement();
            quantitiTriangle.Text = Convert.ToString(150 / 13);
            quantitiRectangle.Text = Convert.ToString(150 / 13);
            quantitiCircle.Text = Convert.ToString(150 / 12);
        }

        Ruuuules rul = new Ruuuules();

        private void правила_Click(object sender, EventArgs e)
        {
            rul.Show();
        }
    }
}
