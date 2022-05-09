using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryChess
{
    internal class GameField
    {
        int width, height;
        float sizeCellX, sizeCellY;


        public GameField(int width, int height)
        {
            this.width = width - 8;
            this.height = height - 8;
            sizeCellX = (this.width) / 12;
            sizeCellY = (this.height) / 12;
        }

        public void DrawGrid(Graphics g)
        {
            for (int i = 0; i < 15; i++)
            {
                if (i == 7 || i == 5) g.DrawLine(new Pen(Color.Black), 4, 3 + i * (int)GetSizeCellH(), width + 4, 3 + i * (int)GetSizeCellH());
                g.DrawLine(new Pen(Color.Black), 4 + i * (int)GetSizeCellW(), 4, 4 + i * (int)GetSizeCellW(), height + 4);
                g.DrawLine(new Pen(Color.Black), 4, 4 + i * (int)GetSizeCellH(), width + 4, 4 + i * (int)GetSizeCellH());
            }
        }

        public void DrawFigures(Graphics g, Figure[,] figures)
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (figures[i, j] != null) figures[i, j].Draw(g);
                }
            }
        }

        public int TouchCellX(int X)
        {
            X -= 4;
            int touchCellX = ((X / sizeCellX) >= 12) ? 11 : (int)(X / sizeCellX);
            return touchCellX;
        }
        public int TouchCellY(int Y)
        {
            Y -= 4;
            int touchCellY = ((Y / sizeCellY) >= 12) ? 11 : (int)(Y / sizeCellY);
            return touchCellY;
        }

        public bool TouchCell(int X, int Y)
        {
            X -= 4; Y -= 4;
            return X > TouchCellX(X) * sizeCellX && Y > TouchCellY(Y) * sizeCellY && X < (TouchCellX(X) + 1) * sizeCellX && Y < (TouchCellY(Y) + 1) * sizeCellY;
        }

        public float GetSizeCellW()
        {
            return sizeCellX;
        }

        public float GetSizeCellH()
        {
            return sizeCellY;
        }
    }
}
