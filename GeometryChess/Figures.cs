using System.Drawing;

namespace GeometryChess
{
    internal abstract class Figures
    {
        protected float x, y;
        protected int w, h, cost;
        protected SolidBrush brush;
        protected Pen pen;

        protected Figures(float x, float y, int w, int h, int cost, Color color, Color colorP)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.cost = cost;

            brush = new SolidBrush(color);
            pen = new Pen(colorP);
        }
        internal abstract void Draw(Graphics g);

        internal abstract bool Touch(int X, int Y);
    }

    interface IStap
    {

    }

    interface IHit
    {

    }

    class Triangle : Figures
    {
        public Triangle(float x, float y, int w, int h, int cost, Color color, Color colorP) : base (x, y, w, h, cost, color, colorP)
        { }
        
        internal override void Draw(Graphics g)
        {
            PointF point1 = new PointF(x + w / 2, y ); 
            PointF point2 = new PointF(x, y+h);
            PointF point3 = new PointF(x + w, y+h);
            PointF[] point = new PointF[] { point1, point2, point3 };
            g.FillPolygon(brush, point);
            g.DrawPolygon(pen, point);
        } 

        internal override bool Touch(int X, int Y)
        {
            return X > y / 2 && X < -y / 2 && Y > y && Y < y + h;
        }
    }

    class Rect : Figures
    {
        public Rect(float x, float y, int w, int h, int cost, Color color, Color colorP) : base(x, y, w, h, cost, color, colorP)
        { }

        internal override void Draw(Graphics g)
        {
            g.FillRectangle(brush, x, y, w, h);
            g.DrawRectangle(pen, x, y, w, h);
        }

        internal override bool Touch(int X, int Y)
        {
            return X > x && X < x + w && Y > y && Y < y + h;
        }
    }

    class Circle : Figures
    {
        public Circle(float x, float y, int w, int h, int cost, Color color, Color colorP) : base(x, y, w, h, cost, color, colorP)
        { }

        internal override void Draw(Graphics g)
        {
            g.FillEllipse(brush, x, y, w, h);
            g.DrawEllipse(pen, x, y, w, h);
        }

        internal override bool Touch(int X, int Y)
        {
            return X > y / 2 && X < -y / 2 && Y > y && Y < y + h;
        }
    }
}
