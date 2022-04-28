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

        Figures[,] figures = new Figures[12,5];

        //Bitmap bitmap;
        //Size size;


        public GameField(int width, int height) //Image image
        {
            this.width = width-8;
            this.height = height-8;
            sizeCellX = (this.width) / 12;
            sizeCellY = (this.height) / 12;
            
            //size = new Size(width, height);
            //bitmap = new Bitmap(image, size);
        }

        //public Bitmap GetBitmap()
        //{
        //    return bitmap;
        //}

        internal void Placement()
        {
            Random comPlan = new Random();
            int coins = 100;
            
            Figures f;

            while (coins>=12)
            {

            }

            switch (comPlan.Next(3))
            {
                case 0:
                    //f = new Triangle(x, y, w, h, Color.Blue, Color.Black, plaer);
                    break;
                case 1:
                    //f = new Rect(x, y, w, h, Color.Blue, Color.Black);
                    break;
                case 2:
                    //f = new Circle(x, y, w, h, Color.Blue, Color.Black);
                    break;
            }
        }

        public void Draw(Graphics g, int x1, int y1, int x2, int y2)
        {
            g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
        }

        public int TouchCellX(int X) 
        {
            return (int)((X-2) / sizeCellX);
        }
        public int TouchCellY(int Y)
        {
            return (int)((Y-2) / sizeCellY);
        }

        public bool TouchCell(int X, int Y, int i, int j)
        {
            return X > i * sizeCellX && Y > j * sizeCellY && X< (i+1) * sizeCellX && Y < (j+1) * sizeCellY;
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
