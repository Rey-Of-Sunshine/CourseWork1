using System.Drawing;

namespace GeometryChess
{
    internal abstract class Figures
    {
        protected int x, y, w, h;
        protected SolidBrush brush;

        protected Figures(int x, int y, int w, int h, Color color)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;

            brush = new SolidBrush(color);
        }
        internal abstract void Draw(Graphics g);
    }

    interface IStap
    {

    }

    interface IHit
    {

    }

    class Triangle : Figures
    {
        public Triangle(int x, int y, int w, int h, Color color): base (x, y, w, h, color)
        { }
        
        internal override void Draw(Graphics g)
        {
            Point point1 = new Point(x + w / 2, y - h ); 
            Point point2 = new Point(x, y);
            Point point3 = new Point(x + w, y);
            Point[] point = new Point[] { point1, point2, point3 };
            g.FillPolygon(brush, point);
        }
    }

    class Rect : Figures
    {
        public Rect(int x, int y, int w, int h, Color color) : base(x, y, w, h, color)
        { }

        internal override void Draw(Graphics g)
        {
            g.FillRectangle(brush, x, y, w, h);
        }
    }

    class Circle : Figures
    {
        public Circle(int x, int y, int w, int h, Color color) : base(x, y, w, h, color)
        { }

        internal override void Draw(Graphics g)
        {
            g.FillEllipse(brush, x, y, w, h);
        }
    }
}
