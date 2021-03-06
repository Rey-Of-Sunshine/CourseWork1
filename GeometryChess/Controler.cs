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
        int delta = 8;
        bool plaer;

        Dictionary<SelectedFigure, Figure> figs;
        GameField field;


        public Controler() { }

        public Controler(bool plaer, GameField field, Dictionary<SelectedFigure, Figure> figs)
        {
            this.plaer = plaer;
            this.figs = figs;
            this.field = field;

            h = (int)field.GetSizeCellH() - delta;
            w = (int)field.GetSizeCellW() - delta;
        }

        private bool CheckPlacement(Figure f, int a) => coins - a >=0 & f == null;
        internal void Placement(int X, int Y, SelectedFigure selectedFigure)
        {
            int touchX = field.TouchCellX(X);
            int touchY = field.TouchCellY(Y);
            float x = 4 + delta / 2 + touchX * field.GetSizeCellW();
            float y = 4 + delta / 2 + touchY * field.GetSizeCellH();

            if (field.TouchCell(X, Y) && touchY >= 6)
            {
                if (selectedFigure == SelectedFigure.Delete /*&& field.figures[touchX, touchY].isPlayer*/)
                {
                    coins += (field.figures[touchX, touchY] != null) ? field.figures[touchX, touchY].cost : 0;
                    field.figures[touchX, touchY] = null;
                }
                else if (selectedFigure == SelectedFigure.Null) ;
                else if (CheckPlacement(field.figures[touchX, touchY], figs[selectedFigure].cost))
                {
                    field.figures[touchX, touchY] = figs[selectedFigure].Clone(touchX, touchY, x, y, w, h, Color.FromArgb(105, 199, 199), Color.FromArgb(57, 153, 146), plaer);
                    coins -= field.figures[touchX, touchY].cost;
                }
            }
        }

        internal void Placement(Random rnd)
        {
            int a = 0;

            while (coins - a >= 0)
            {
                SelectedFigure selectedFigure = (SelectedFigure)rnd.Next(3);
                int touchX = rnd.Next(12), touchY = rnd.Next(6);
                float x = 4 + delta / 2 + touchX * field.GetSizeCellW();
                float y = 4 + delta / 2 + touchY * field.GetSizeCellH();
                x = 4 + delta / 2 + touchX * field.GetSizeCellW();
                y = 4 + delta / 2 + touchY * field.GetSizeCellH();

                if (field.figures[touchX, touchY] == null)
                {
                    field.figures[touchX, touchY] = figs[selectedFigure].Clone(touchX, touchY, x, y, w, h, Color.FromArgb(99, 45, 112), Color.FromArgb(58, 14, 65), plaer);
                    coins -= field.figures[touchX, touchY].cost;
                    a = field.figures[touchX, touchY].cost;
                }
            }
        }

    }
}
