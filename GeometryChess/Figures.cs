using System.Drawing;

namespace GeometryChess
{
    internal abstract class Figures
    {
        protected float x, y;
        protected int w, h;
        protected SolidBrush brush;
        protected Pen pen;


        protected Figures(float x, float y, int w, int h, Color color, Color colorP)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;

            brush = new SolidBrush(color);
            pen = new Pen(colorP);
        }

        //internal int Quatiti()
        //{
        //    return coins / cost;
        //}

        internal abstract void Draw(Graphics g);

        internal abstract bool Touch(int X, int Y);

        internal abstract void Move(int dx, int dy, bool isObj);
    }

    interface IStap
    {

    }

    interface IHit
    {

    }


    class Triangle : Figures 
    {
        bool plaer;
        int step, hit;

        PointF point1, point2, point3;

        public Triangle(float x, float y, int w, int h, Color color, Color colorP, bool plaer) : base(x, y, w, h, color, colorP)
        {
            this.plaer = plaer;
        }

        internal override void Draw(Graphics g)
        {
            switch (plaer)
            {
                case true:
                    point1 = new PointF(x + w / 2, y);
                    point2 = new PointF(x, y + h);
                    point3 = new PointF(x + w, y + h);
                    break;
                case false: //фигура противника перевёрнутая
                    point1 = new PointF(x + w / 2, y + h);
                    point2 = new PointF(x, y);
                    point3 = new PointF(x + w, y);
                    break;
            }
            PointF[] point = new PointF[] { point1, point2, point3 };
            g.FillPolygon(brush, point);
            g.DrawPolygon(pen, point);
        }
        internal override void Move(int dx, int dy, bool isObj)
        {
            int direction = 1;
            
            switch (plaer)
            {
                case true:
                    direction = 1;
                    break;
                case false: //ии
                    direction = -1;
                    break;
            }

            if (isObj)
            {

            }

            x += dx * direction;
            y += dy * direction;
        }

        internal override bool Touch(int X, int Y)
        {
            return X > y / 2 && X < -y / 2 && Y > y && Y < y + h;
        }

    }

    class Rect : Figures
    {
        public Rect(float x, float y, int w, int h, Color color, Color colorP) : base(x, y, w, h, color, colorP)
        { }

        internal override void Draw(Graphics g)
        {
            g.FillRectangle(brush, x, y, w, h);
            g.DrawRectangle(pen, x, y, w, h);
        }
        internal override void Move(int dx, int dy, bool isObj)
        {
            x += dx;
            y += dy;
        }

        internal override bool Touch(int X, int Y)
        {
            return X > x && X < x + w && Y > y && Y < y + h;
        }

    }

    class Circle : Figures
    {
        public Circle(float x, float y, int w, int h, Color color, Color colorP) : base(x, y, w, h, color, colorP)
        { }

        internal override void Draw(Graphics g)
        {
            g.FillEllipse(brush, x, y, w, h);
            g.DrawEllipse(pen, x, y, w, h);
        }

        internal override void Move(int dx, int dy, bool isObj)
        {
            x += dx;
            y += dy;
        }

        internal override bool Touch(int X, int Y)
        {
            return X > y / 2 && X < -y / 2 && Y > y && Y < y + h;
        }
    }
}
