using System.Drawing;
using System;

namespace GeometryChess
{
    internal abstract class Figure
    {
        protected float x, y;
        protected int w, h, dx, dy;
        protected SolidBrush brush;
        protected Pen pen;
        protected bool isPlayer;
        protected int distance = 0;


        public Figure() { }
        protected Figure(float x, float y, int w, int h, Color color, Color colorP, bool player)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.isPlayer = player;

            brush = new SolidBrush(color);
            pen = new Pen(colorP);
        }

        //internal int Quatiti()
        //{
        //    return coins / cost;
        //}

        internal abstract void Draw(Graphics g);

        protected abstract bool MoveDirection(Figure[,] map, Random rnd);
        protected abstract bool EatDirection(Figure[,] map, Random rnd);

        public abstract Figure Clone(float x, float y, int w, int h, Color color, Color colorP, bool player);

        internal void Move(Figure[,] map, Random rnd)
        {
            if (!EatDirection(map, rnd))
                MoveDirection(map, rnd);

        }

    }


    class Triangle : Figure
    {
        PointF point1, point2, point3;

        public Triangle() { }

        public Triangle(float x, float y, int w, int h, Color color, Color colorP, bool player) : base(x, y, w, h, color, colorP, player)
        {
            distance = 3;
        }

        internal override void Draw(Graphics g)
        {
            switch (isPlayer)
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
        internal override void MoveDirection(Figure[,] map, Random rnd)
        {
            int side = rnd.Next(3);

            switch (side)
            {
                case 0: //вперёд
                    dy = -distance;
                    break;
                case 1: //назад влево
                    dx = -distance;
                    dy = distance;
                    break;
                case 2: // назад вправо
                    dx = distance;
                    dy = distance;
                    break;
            }
        }

        public override Figure Clone(float x, float y, int w, int h, Color color, Color colorP, bool player)
        {
            return new Triangle(x, y, w, h, color, colorP, player);
        }

        protected override bool EatDirection(Figure[,] map, Random rnd)
        {
            throw new NotImplementedException();
        }
    }

    class Rect : Figure
    {
        public Rect() { }

        public Rect(float x, float y, int w, int h, Color color, Color colorP, bool player) : base(x, y, w, h, color, colorP, player)
        {
            distance = 3;
        }

        internal override void Draw(Graphics g)
        {
            g.FillRectangle(brush, x, y, w, h);
            g.DrawRectangle(pen, x, y, w, h);
        }

        //траектория шага: x=-y; x=y 1-2 клетки
        internal override void ChangeDirection(int distance)
        {


            switch (side)
            {
                case 0: //вперёд влево
                    dx = -distance;
                    dy = -distance;
                    break;
                case 1: //вперёд вправо
                    dx = distance;
                    dy = -distance;
                    break;
                case 2: //назад вправо
                    dx = distance;
                    dy = distance;
                    break;
                case 3: //назад влево
                    dx = -distance;
                    dy = distance;
                    break;
            }
        }
        public override Figure Clone(float x, float y, int w, int h, Color color, Color colorP, bool player)
        {
            return new Rect(x, y, w, h, color, colorP, player);
        }

        protected override bool MoveDirection(Figure[,] map, Random rnd)
        {
            throw new NotImplementedException();
        }

        protected override bool EatDirection(Figure[,] map, Random rnd)
        {
            throw new NotImplementedException();
        }
    }

    class Circle : Figure
    {
        public Circle() { }

        public Circle(float x, float y, int w, int h, Color color, Color colorP, bool player) : base(x, y, w, h, color, colorP, player)
        {
            distance = 3;
        }

        internal override void Draw(Graphics g)
        {
            g.FillEllipse(brush, x, y, w, h);
            g.DrawEllipse(pen, x, y, w, h);
        }

        //траектория шага: x=-y; x=y  через 1 клетку
        internal override void ChangeDirection(int distance)
        {
            switch (side)
            {
                case 0://вперёд влево
                    dx = -distance;
                    dy = -distance;
                    break;
                case 1: //вперёд
                    dy = -distance;
                    break;
                case 2://вперёд вправо
                    dx = distance;
                    dy = -distance;
                    break;
                case 3: //вправо
                    dx = distance;
                    break;
                case 4://назад вправо
                    dx = distance;
                    dy = distance;
                    break;
                case 5: //назад
                    dy = distance;
                    break;
                case 6://назад влево
                    dx = -distance;
                    dy = distance;
                    break;
                case 7:  //влево
                    dx = -distance;
                    break;
            }
        }
        public override Figure Clone(float x, float y, int w, int h, Color color, Color colorP, bool player)
        {
            return new Circle(x, y, w, h, color, colorP, player);
        }

        protected override bool MoveDirection(Figure[,] map, Random rnd)
        {
            throw new NotImplementedException();
        }

        protected override bool EatDirection(Figure[,] map, Random rnd)
        {
            throw new NotImplementedException();
        }
    }
}
