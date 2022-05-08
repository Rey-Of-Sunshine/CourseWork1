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


        //Bitmap bitmap;
        //Size size;


        public GameField(int width, int height) //Image image
        {
            this.width = width - 8;
            this.height = height - 8;
            sizeCellX = (this.width) / 12;
            sizeCellY = (this.height) / 12;

            //size = new Size(width, height);
            //bitmap = new Bitmap(image, size);
        }

        //public Bitmap GetBitmap()
        //{
        //    return bitmap;
        //}

        internal void Placement(Figure[,] figures)
        {
            int coins = 150;
            bool plaer = false;
            int delta = 6;
            int h = (int)GetSizeCellH() - delta;
            int w = (int)GetSizeCellW() - delta;
            int costT = 13, costR = 13, costC = 12;

            Random comPlan = new Random();

            while (coins >= 12)
            {
                int touchX = comPlan.Next(12);
                int touchY = comPlan.Next(5);
                float x = 4 + delta / 2 + touchX * GetSizeCellW();
                float y = 4 + delta / 2 + touchY * GetSizeCellH();

                if (figures[touchX, touchY] == null)
                {
                    switch (comPlan.Next(3))
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

        public int TouchCellX(int X)
        {
            int touchCellX = ((X / sizeCellX) > 12) ? 11 : (int)(X / sizeCellX);
            return touchCellX;
        }
        public int TouchCellY(int Y)
        {
            int touchCellY = ((Y / sizeCellY) > 12) ? 11 : (int)(Y / sizeCellY);
            return touchCellY;
        }

        public bool TouchCell(int X, int Y, int i, int j)
        {
            return X > i * sizeCellX && Y > j * sizeCellY && X < (i + 1) * sizeCellX && Y < (j + 1) * sizeCellY;
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
