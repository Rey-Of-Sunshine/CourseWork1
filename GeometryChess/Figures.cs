using System.Drawing;

namespace GeometryChess
{
    internal abstract class Figures
    {
        protected float x, y;
        protected int w, h;
        protected SolidBrush brush;
        protected Pen pen;
        protected bool plaer;


        protected Figures(float x, float y, int w, int h, Color color, Color colorP, bool plaer)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.plaer = plaer;

            brush = new SolidBrush(color);
            pen = new Pen(colorP);
        }

        //internal int Quatiti()
        //{
        //    return coins / cost;
        //}

        internal abstract void Draw(Graphics g);

        internal abstract bool Touch(int X, int Y);

        internal abstract void ChangeDirection(int st, int distance, int dx, int dy);                     

        internal void Move(int dx, int dy, bool isObj)
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
                x += dx * direction;
                y += dy * direction;
            }
        }

    }

    interface IStap
    {

    }

    interface IHit
    {

    }


    class Triangle : Figures 
    {
        PointF point1, point2, point3;

        public Triangle(float x, float y, int w, int h, Color color, Color colorP, bool plaer) : base(x, y, w, h, color, colorP, plaer)
        {}

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

        // траектория шага: x=x, y-=2(3, 4); x=-y (x<x, y>y); x=y (x>x, y>y) 2-4 клетки
        internal override void ChangeDirection(int st, int distance, int dx, int dy)
        {
            
            switch(st)
            {
                case 0:
                    dy = -distance;
                    break;
                case 1:
                    dx = -distance;
                    dy = distance;
                    break;
                case 2:
                    dx = distance;
                    dy = distance;
                    break;
            }
        }


        internal override bool Touch(int X, int Y)
        {
            return X > y / 2 && X < -y / 2 && Y > y && Y < y + h;
        }

    }

    class Rect : Figures
    {
        public Rect(float x, float y, int w, int h, Color color, Color colorP, bool plaer) : base(x, y, w, h, color, colorP, plaer)
        { }

        internal override void Draw(Graphics g)
        {
            g.FillRectangle(brush, x, y, w, h);
            g.DrawRectangle(pen, x, y, w, h);
        }

        //траектория шага: x=-y; x=y 1-2 клетки
        internal override void ChangeDirection(int st, int distance, int dx, int dy)
        {
            switch (st)
            {
                case 0:
                    dx = -distance;
                    dy = -distance;
                    break;
                case 1:
                    dx = distance;
                    dy = -distance;
                    break;
                case 2:
                    dx = distance;
                    dy = distance;
                    break;
                case 3:
                    dx = -distance;
                    dy = distance;
                    break;
            }
        }


        internal override bool Touch(int X, int Y)
        {
            return X > x && X < x + w && Y > y && Y < y + h;
        }

    }

    class Circle : Figures
    {
        public Circle(float x, float y, int w, int h, Color color, Color colorP, bool plaer) : base(x, y, w, h, color, colorP, plaer)
        { }

        internal override void Draw(Graphics g)
        {
            g.FillEllipse(brush, x, y, w, h);
            g.DrawEllipse(pen, x, y, w, h);
        }

        //траектория шага: x=-y; x=y  через 1 клетку
        internal override void ChangeDirection(int st, int distance, int dx, int dy)
        {
            switch (st)
            {
                case 0:
                    dx = -distance;
                    dy = -distance;
                    break;
                case 1:
                    dy = -distance;
                    break;
                case 2:
                    dx = distance;
                    dy = -distance;
                    break;
                case 3:
                    dx = distance;
                    break;
                case 4:
                    dx = distance;
                    dy = distance;
                    break;
                case 5:
                    dy = distance;
                    break;
                case 6:
                    dx = -distance;
                    dy = distance;
                    break;
                case 7:
                    dx = -distance;
                    break;
            }
        }


        internal override bool Touch(int X, int Y)
        {
            return X > y / 2 && X < -y / 2 && Y > y && Y < y + h;
        }
    }
}
