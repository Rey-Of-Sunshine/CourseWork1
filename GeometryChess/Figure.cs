using System.Drawing;
using System;

namespace GeometryChess
{
    internal abstract class Figure
    {
        protected float x, y;
        protected int w, h;
        public bool isPlayer { get; protected set; }
        protected int distanceStap = 0, distanceHit = 0;
        protected int indexX, indexY;
        protected SolidBrush brush;
        protected Pen pen;
        protected Color color, colorP;
        
        protected bool ChackIndex(Figure[,] map, int distX, int distY) => indexX + distX < 12 && indexX + distX >= 0 && indexY + distY < 12 && indexY + distY >= 0 && map[indexX + distX, indexY + distY] == null;
        protected bool ChackIndexEat(Figure[,] map, int distX, int distY) => indexX + distX < 12 && indexX + distX >= 0 && indexY + distY < 12 && indexY + distY >= 0 && map[indexX + distX, indexY + distY] != null && map[indexX + distX, indexY + distY].isPlayer != isPlayer;

        public Figure() { }
        protected Figure(int indexX, int indexY, float x, float y, int w, int h, Color color, Color colorP, bool player)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.indexX= indexX;
            this.indexY= indexY;
            this.color = color;
            this.colorP = colorP;
            isPlayer = player;

            brush = new SolidBrush(color);
            pen = new Pen(colorP);
        }

        //internal int Quatiti()
        //{
        //    return coins / cost;
        //}


        internal abstract void Draw(Graphics g);

        protected abstract bool MoveDirection(Figure[,] map, Random rnd, GameField field);
        protected abstract bool EatDirection(Figure[,] map, Random rnd, GameField field);

        public abstract Figure Clone(int indexX, int indexY, float x, float y, int w, int h, Color color, Color colorP, bool player);

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

        public Triangle(int indexX, int indexY, float x, float y, int w, int h, Color color, Color colorP, bool isPlayer) : base(indexX, indexY, x, y, w, h, color, colorP, isPlayer)
        {
            distanceStap = 3;
            distanceHit = 2;
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

        public override Figure Clone(int indexX, int indexY, float x, float y, int w, int h, Color color, Color colorP, bool isPlayer)
        {
            return new Triangle(indexX, indexY, x, y, w, h, color, colorP, isPlayer);
        }

        // траектория шага: x=x, y-=2(3, 4); x=-y (x<x, y>y); x=y (x>x, y>y) 2-4 клетки
        protected override bool MoveDirection(Figure[,] map, Random rnd, GameField field)
        {
            int side = rnd.Next(3);
            int distX=0, distY=0;

            switch (side)
            {
                case 0: //вперёд
                    distX = 0;
                    distY = -distanceStap;
                    //y = (map[indexX, indexY - distance] == null) ? -distance * field.GetSizeCellH() : +0;
                    //dy = -distance;
                    break;
                case 1: //назад влево
                    distX = -distanceStap;
                    distY = distanceStap;
                    break;
                case 2: // назад вправо
                    distX = distanceStap;
                    distY = distanceStap;
                    break;
            }

            if (ChackIndex(map, distX, distY))
            {
                x += distX * field.GetSizeCellH();
                y += distY * field.GetSizeCellH();
                map[indexX + distX, indexY + distY] = map[indexX, indexY];
                map[indexX, indexY] = null;
                indexX += distX;
                indexY += distY;
                return true;
            }
            else return false;
        }

        protected override bool EatDirection(Figure[,] map, Random rnd, GameField field)
        {
            int side = rnd.Next(3);
            int distX=0, distY=0;

            switch (side)
            {
                case 0: //назад
                    distX = 0;
                    distY = distanceHit;
                    break;
                case 1: // влево
                    distX = -distanceHit;
                    distY = 0;
                    break;
                case 2: // вправо
                    distX = distanceHit;
                    distY = 0;
                    break;
            }

            if (ChackIndexEat(map, distX, distY))
            {
                x += distX * field.GetSizeCellH();
                y += distY * field.GetSizeCellH();
                map[indexX + distX, indexY + distY] = map[indexX, indexY];
                map[indexX, indexY] = null;
                indexX += distX;
                indexY += distY;
                return true;
            }
            else return false;
        }
    }

    class Rect : Figure
    {
        public Rect() { }

        public Rect(int indexX, int indexY, float x, float y, int w, int h, Color color, Color colorP, bool isPlayer) : base(indexX, indexY, x, y, w, h, color, colorP, isPlayer)
        {
            distanceStap = 1;
            distanceHit = 3;
        }

        internal override void Draw(Graphics g)
        {
            g.FillRectangle(brush, x, y, w, h);
            g.DrawRectangle(pen, x, y, w, h);
        }

        
        public override Figure Clone(int indexX, int indexY, float x, float y, int w, int h, Color color, Color colorP, bool isPlayer)
        {
            return new Rect(indexX, indexY, x, y, w, h, color, colorP, isPlayer);
        }

        //траектория шага: x=-y; x=y 1-2 клетки
        protected override bool MoveDirection(Figure[,] map, Random rnd, GameField field)
        {
            int side = rnd.Next(4);
            int distX = 0, distY = 0;

            switch (side)
            {
                case 0: //вперёд влево
                    distX = -distanceStap;
                    distY = -distanceStap;
                    break;
                case 1: //вперёд вправо
                    distX = distanceStap;
                    distY = -distanceStap;
                    break;
                case 2: //назад вправо
                    distX = distanceStap;
                    distY = distanceStap;
                    break;
                case 3: //назад влево
                    distX = -distanceStap;
                    distY = distanceStap;
                    break;
            }

            if (ChackIndex(map, distX, distY))
            {
                x += distX * field.GetSizeCellH();
                y += distY * field.GetSizeCellH();
                map[indexX + distX, indexY + distY] = map[indexX, indexY];
                map[indexX, indexY] = null;
                indexX += distX;
                indexY += distY;
                return true;
            }
            else return false;
        }

        protected override bool EatDirection(Figure[,] map, Random rnd, GameField field)
        {
            int side = rnd.Next(4);
            int distX = 0, distY = 0;

            switch (side)
            {
                case 0: //вперёд
                    distX = 0;
                    distY = -distanceHit;
                    break;
                case 1: //вправо
                    distX = distanceHit;
                    distY = 0;
                    break;
                case 2: //влево
                    distX = distanceHit;
                    distY = 0;
                    break;
                case 3: //назад
                    distX = 0;
                    distY = distanceHit;
                    break;
            }

            if (ChackIndexEat(map, distX, distY))
            {
                x += distX * field.GetSizeCellH();
                y += distY * field.GetSizeCellH();
                map[indexX + distX, indexY + distY] = map[indexX, indexY];
                map[indexX, indexY] = null;
                indexX += distX;
                indexY += distY;
                return true;
            }
            else return false;
        }
    }

    class Circle : Figure
    {
        public Circle() { }

        public Circle(int indexX, int indexY, float x, float y, int w, int h, Color color, Color colorP, bool isPlayer) : base(indexX, indexY, x, y, w, h, color, colorP, isPlayer)
        {
            distanceStap = 2;
            distanceHit = 1;
        }

        internal override void Draw(Graphics g)
        {
            g.FillEllipse(brush, x, y, w, h);
            g.DrawEllipse(pen, x, y, w, h);
        }

        public override Figure Clone(int indexX, int indexY, float x, float y, int w, int h, Color color, Color colorP, bool isPlayer)
        {
            return new Circle(indexX, indexY, x, y, w, h, color, colorP, isPlayer);
        }

        //траектория шага: x=-y; x=y  через 1 клетку
        protected override bool MoveDirection(Figure[,] map, Random rnd, GameField field)
        {
            int side = rnd.Next(8);
            int distX = 0, distY = 0;

            switch (side)
            {
                case 0://вперёд влево
                    distX = -distanceStap;
                    distY = -distanceStap;
                    break;
                case 1: //вперёд
                    distY = -distanceStap;
                    break;
                case 2://вперёд вправо
                    distX = distanceStap;
                    distY = -distanceStap;
                    break;
                case 3: //вправо
                    distX = distanceStap;
                    break;
                case 4://назад вправо
                    distX = distanceStap;
                    distY = distanceStap;
                    break;
                case 5: //назад
                    distY = distanceStap;
                    break;
                case 6://назад влево
                    distX = -distanceStap;
                    distY = distanceStap;
                    break;
                case 7:  //влево
                    distX = -distanceStap;
                    break;
            }


            if (ChackIndex(map, distX, distY))
            {
                x += distX * field.GetSizeCellH();
                y += distY * field.GetSizeCellH();
                map[indexX + distX, indexY + distY] = map[indexX, indexY];
                map[indexX, indexY] = null;
                indexX += distX;
                indexY += distY;
                return true;
            }
            else return false;
        }

        protected override bool EatDirection(Figure[,] map, Random rnd, GameField field)
        {
            int side = rnd.Next(8);
            int distX = 0, distY = 0;

            switch (side)
            {
                case 0://вперёд влево
                    distX = -distanceHit;
                    distY = -distanceHit;
                    break;
                case 1: //вперёд
                    distY = -distanceHit;
                    break;
                case 2://вперёд вправо
                    distX = distanceHit;
                    distY = -distanceHit;
                    break;
                case 3: //вправо
                    distX = distanceHit;
                    break;
                case 4://назад вправо
                    distX = distanceHit;
                    distY = distanceHit;
                    break;
                case 5: //назад
                    distY = distanceHit;
                    break;
                case 6://назад влево
                    distX = -distanceHit;
                    distY = distanceHit;
                    break;
                case 7:  //влево
                    distX = -distanceHit;
                    break;
            }


            if (ChackIndexEat(map, distX, distY))
            {
                x += distX * field.GetSizeCellH();
                y += distY * field.GetSizeCellH();
                map[indexX + distX, indexY + distY] = map[indexX, indexY];
                map[indexX, indexY] = null;
                indexX += distX;
                indexY += distY;
                return true;
            }
            else return false;
        }
    }
}
