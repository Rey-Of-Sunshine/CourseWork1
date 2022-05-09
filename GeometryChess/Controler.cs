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
        public int coinsPl { get; private set; } = 150;
        int coinsCm = 150;
        float x, y;
        int delta = 6;
        bool plaer;

        GameField field;
        Figure[,] figures;
        SelectedFigure selectedFigure;
        Dictionary<SelectedFigure, Figure> figs;

        public Controler() { }

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

        private bool CheckPlacement(int x, int y) => coinsPl >= 12 && figures[x, y] == null;
        internal void Placement(int X, int Y)
        {
            int touchX = field.TouchCellX(X);
            int touchY = field.TouchCellY(Y);


            if (field.TouchCell(X, Y) && touchY >= 7)
            {
                if (selectedFigure == SelectedFigure.Delete)
                {
                    coinsPl = (figures[touchX, touchY] != null) ? +figures[touchX, touchY].cost : 0;
                    figures[touchX, touchY] = null;
                }
                else if (CheckPlacement(touchX, touchY))
                {
                    figures[touchX, touchY] = figs[selectedFigure].Clone(touchX, touchY, x, y, w, h, Color.Blue, Color.Black, true);
                    coinsPl -= figures[touchX, touchY].cost;
                }
            }
        }

        internal void Placement(Random rnd)
        {

            while (coinsCm >= 12)
            {
                int touchX = rnd.Next(12), touchY = rnd.Next(5);
                float x = 4 + delta / 2 + touchX * field.GetSizeCellW();
                float y = 4 + delta / 2 + touchY * field.GetSizeCellH();

                if (figures[touchX, touchY] == null)
                {
                    switch (rnd.Next(3))
                    {
                        case 0:
                            figures[touchX, touchY] = new Triangle(touchX, touchY, x, y, w, h, Color.Green, Color.Black, plaer);
                            coinsCm -= figures[touchX, touchY].cost;
                            break;
                        case 1:
                            figures[touchX, touchY] = new Rect(touchX, touchY, x, y, w, h, Color.Green, Color.Black, plaer);
                            coinsCm -= figures[touchX, touchY].cost;
                            break;
                        case 2:
                            figures[touchX, touchY] = new Circle(touchX, touchY, x, y, w, h, Color.Green, Color.Black, plaer);
                            coinsCm -= figures[touchX, touchY].cost;
                            break;
                    }
                }
            }
        }

    }
}
