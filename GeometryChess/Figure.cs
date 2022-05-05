using System.Drawing;
using System;
using System.Collections.Generic;

namespace GeometryChess
{
    enum WayFigure { NW, N, NE, E, SE, S, SW, W}
    
    internal abstract class Figure
    {
        protected float x, y;
        protected int w, h, dx, dy;
        protected SolidBrush brush;
        protected Pen pen;
        protected bool isPlayer;
        protected int distance = 0;
        public int indexX
        {
            set { if (value>=0 && value<13) indexX = value; }
            get { return indexX; }
        }

        public int indexY
        {
            set { if (value >= 0 && value < 13) indexY = value; }
            get { return indexY; }
        }

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

        WayFigure wayFigure =WayFigure.N;
        protected Dictionary<WayFigure, int[]> figWay = new Dictionary<WayFigure, int[]>()
        {
            { WayFigure.NW , new int[]{ -1, -1 } },
             { WayFigure.N , new int[]{ 0, -1 } },
              { WayFigure.NE , new int[]{ 1, -1 } },
              { WayFigure.E , new int[]{ 1, 0 } },
              { WayFigure.SE , new int[]{ 1, 1 } },
              { WayFigure.S , new int[]{ 0, 1 } },
              { WayFigure.SW , new int[]{ -1, 1 } },
              { WayFigure.W , new int[]{ -1, 0 } },
        };
        //protected bool CheckWay(Figure[,] map) => map[indexX + distance * figWay[WayFigure.N][0], indexY + distance * figWay[WayFigure.N][1]] == null;

        internal abstract void Draw(Graphics g);

        protected abstract bool MoveDirection(Figure[,] map, Random rnd, GameField field);
        protected abstract bool EatDirection(Figure[,] map, Random rnd, GameField field);

        public abstract Figure Clone(float x, float y, int w, int h, Color color, Color colorP, bool player);

        internal void Move(Figure[,] map, Random rnd, GameField field)
        {
            if (!EatDirection(map, rnd, field))
                MoveDirection(map, rnd, field);
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

        public override Figure Clone(float x, float y, int w, int h, Color color, Color colorP, bool player)
        {
            return new Triangle(x, y, w, h, color, colorP, player);
        }

        // траектория шага: x=x, y-=2(3, 4); x=-y (x<x, y>y); x=y (x>x, y>y) 2-4 клетки
        protected override bool MoveDirection(Figure[,] map, Random rnd, GameField field)
        {
            int side = rnd.Next(3);
            int wayX = 0, wayY = 0;

            switch (side)
            {
                case 0: //вперёд
                    wayX = figWay[WayFigure.N][0];
                    wayY = figWay[WayFigure.N][1];
                    //y = (map[indexX, indexY - distance] == null) ? -distance * field.GetSizeCellH() : +0;
                    //dy = -distance;
                    break;
                case 1: //назад влево
                    wayX = figWay[WayFigure.SW][0];
                    wayY = figWay[WayFigure.SW][1];
                    break;
                case 2: // назад вправо
                    wayX = figWay[WayFigure.SE][0];
                    wayY = figWay[WayFigure.SE][1];
                    break;

            }
            if (map[indexX + distance * wayX, indexY + distance * wayY] == null)
            {
                x += distance * field.GetSizeCellH() * figWay[WayFigure.N][0];
                y += distance * field.GetSizeCellH() * figWay[WayFigure.N][1];
            }
            return true;
        }


        protected override bool EatDirection(Figure[,] map, Random rnd, GameField field)
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

        protected override bool MoveDirection(Figure[,] map, Random rnd, GameField field)
        {
            throw new NotImplementedException();
        }

        protected override bool EatDirection(Figure[,] map, Random rnd, GameField field)
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

        protected override bool MoveDirection(Figure[,] map, Random rnd, GameField field)
        {
            throw new NotImplementedException();
        }

        protected override bool EatDirection(Figure[,] map, Random rnd, GameField field)
        {
            throw new NotImplementedException();
        }
    }
}
