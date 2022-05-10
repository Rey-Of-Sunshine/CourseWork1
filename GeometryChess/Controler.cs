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

        int h, w;
        public int coins { get; private set; } = 150;
        int delta = 6;
        bool plaer;

        Dictionary<SelectedFigure, Figure> figs;
        GameField field;


        public Controler() { }

        public Controler( bool plaer, GameField field, Dictionary<SelectedFigure, Figure> figs)
        {
            this.plaer = plaer;
            this.figs = figs;
            this.field = field;

            h = (int)field.GetSizeCellH() - delta;
            w = (int)field.GetSizeCellW() - delta;
        }

        private bool CheckPlacement(Figure f) => coins >= 12 && f == null;
        internal void Placement(int X, int Y, SelectedFigure selectedFigure)
        {
            int touchX = field.TouchCellX(X);
            int touchY = field.TouchCellY(Y);
            float x = 4 + delta / 2 + touchX * field.GetSizeCellW();
            float y = 4 + delta / 2 + touchY * field.GetSizeCellH();

            if (field.TouchCell(X, Y) && touchY >= 7)
            {
                if (selectedFigure == SelectedFigure.Delete)
                {
                    coins += (field.figures[touchX, touchY] != null) ? field.figures[touchX, touchY].cost : 0;
                    field.figures[touchX, touchY] = null;
                }
                else if (CheckPlacement(field.figures[touchX, touchY]))
                {
                    field.figures[touchX, touchY] = figs[selectedFigure].Clone(touchX, touchY, x, y, w, h, Color.Blue, Color.Black, plaer);
                    coins -= field.figures[touchX, touchY].cost;
                }
            }
        }

        internal void Placement(Random rnd)
        {
            

            while (coins > 12)
            {
                SelectedFigure selectedFigure = (SelectedFigure)rnd.Next(3);
                int touchX = rnd.Next(12), touchY = rnd.Next(5);
                float x = 4 + delta / 2 + touchX * field.GetSizeCellW();
                float y = 4 + delta / 2 + touchY * field.GetSizeCellH();
                x = 4 + delta / 2 + touchX * field.GetSizeCellW();
                y = 4 + delta / 2 + touchY * field.GetSizeCellH();

                if (field.figures[touchX, touchY] == null)
                {
                    field.figures[touchX, touchY] = figs[selectedFigure].Clone(touchX, touchY, x, y, w, h, Color.Green, Color.Black, plaer);
                    coins -= field.figures[touchX, touchY].cost;
                }
            }
        }

    }
}
