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
            game = new Game(field, selectedFigure);
                                                  
        }

        bool clicStart = false;

        SelectedFigure selectedFigure = SelectedFigure.Delete;

        Game game;
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
            game.Placement(e.X, e.Y);

            quantitiTriangle.Text = Convert.ToString(game.GetQuantiti(new Triangle()));
            quantitiRectangle.Text = Convert.ToString(game.GetQuantiti(new Rect()));
            quantitiCircle.Text = Convert.ToString(game.GetQuantiti(new Circle()));
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (clicStart)
            {
                game.Queue();
            }
            Refresh();
        }

        private void gameField_Paint(object sender, PaintEventArgs e)
        {
            game.DrawField(e.Graphics);
        }

        private void buttonTriangle_Paint(object sender, PaintEventArgs e)
        {
            (new Triangle(-1, -1, 5, 5, buttonTriangle.Width - 10, buttonTriangle.Height - 10, Color.Black, Color.Black, true)).Draw(e.Graphics);
        }


        private void buttonRectangle_Paint(object sender, PaintEventArgs e)
        {
            (new Rect(-1, -1, 5, 5, buttonRectangle.Width - 10, buttonRectangle.Height - 10, Color.Black, Color.Black, true)).Draw(e.Graphics);
        }

        private void buttonCircle_Paint(object sender, PaintEventArgs e)
        {
            new Circle(-1, -1, 5, 5, buttonCircle.Width - 10, buttonCircle.Height - 10, Color.Black, Color.Black, true).Draw(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            (new StartWindow()).ShowDialog();
            game.Placement();
            quantitiTriangle.Text = Convert.ToString(150/13);
            quantitiRectangle.Text = Convert.ToString(150/13);
            quantitiCircle.Text = Convert.ToString(150/12);
        }


    }
}
