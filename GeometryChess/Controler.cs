using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GeometryChess
{
    internal class Controler
    {
        //расстановка фигур

        int touchX, touchY, h, w;
        float x, y;
        int costT = 13, costR = 13, costC = 12;
        int delta = 6;
        bool plaer;

        GameField field;
        Figure[,] figures;
        SelectedFigure selectedFigure;
        Dictionary<SelectedFigure, Figure> figs;

        public Controler() { }
        public Controler(Figure[,] figures, bool plaer, int touchX, int touchY, GameField field, SelectedFigure selectedFigure, Dictionary<SelectedFigure, Figure> figs)
        {
            this.figures = figures;
            this.plaer = plaer;
            this.touchX = touchX;
            this.touchY = touchY;
            this.field = field;
            this.selectedFigure = selectedFigure;
            this.figs = figs;

            h = (int)field.GetSizeCellH() - delta;
            w = (int)field.GetSizeCellW() - delta;
            x = 4 + delta / 2 + touchX * field.GetSizeCellW();
            y = 4 + delta / 2 + touchY * field.GetSizeCellH();
        }
        public Controler(Figure[,] figures, bool plaer, GameField field, SelectedFigure selectedFigure, Dictionary<SelectedFigure, Figure> figs)
        {
            this.figures = figures;
            this.plaer = plaer;
            this.field = field;
            this.selectedFigure = selectedFigure;
            this.figs = figs;

            h = (int)field.GetSizeCellH() - delta;
            w = (int)field.GetSizeCellW() - delta;
            x = 4 + delta / 2 + touchX * field.GetSizeCellW();
            y = 4 + delta / 2 + touchY * field.GetSizeCellH();
        }

        private bool CheckPlacement(int x, int y, int coins) => coins >= 12 && figures[x, y] == null;
        internal void Placement(int X, int Y)
        {
            int coins = 150;

            if (field.TouchCell(X, Y) && touchY >= 7)
            {
                if (selectedFigure == SelectedFigure.Delete)
                {
                    if (figures[touchX, touchY] is Triangle) coins += costT;
                    if (figures[touchX, touchY] is Rect) coins += costR;
                    if (figures[touchX, touchY] is Circle) coins += costC;
                    figures[touchX, touchY] = null;
                }
                else if (CheckPlacement(touchX, touchY, coins))
                {
                    figures[touchX, touchY] = figs[selectedFigure].Clone(touchX, touchY, x, y, w, h, Color.Blue, Color.Black, true);
                    coins -= costT;
                }
            }
        }

        internal void Placement(Random rnd)
        {
            int coins = 150;

            while (coins >= 12)
            {
                if (figures[touchX, touchY] == null)
                {
                    switch (rnd.Next(3))
                    {
                        case 0:
                            figures[touchX, touchY] = new Triangle(touchX, touchY, x, y, w, h, Color.Green, Color.Black, plaer);
                            coins -= costT;
                            break;
                        case 1:
                            figures[touchX, touchY] = new Rect(touchX, touchY, x, y, w, h, Color.Green, Color.Black, plaer);
                            coins -= costR;
                            break;
                        case 2:
                            figures[touchX, touchY] = new Circle(touchX, touchY, x, y, w, h, Color.Green, Color.Black, plaer);
                            coins -= costC;
                            break;
                    }
                }
            }
        }

    }
}
