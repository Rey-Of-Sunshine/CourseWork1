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
        int width, height, i, j;

        Bitmap bitmap;
        Size size;

        public GameField(int width, int height, Image image)
        {
            this.width = width;
            this.height = height;
            
            size = new Size(width, height);
            bitmap = new Bitmap(image, size);
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void TouchCell(int X, int Y) // 30*30  
        {
            i = X / (width / 12);
            j = Y / (height / 12);
        }
    }
}
