using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GeometryChess
{
    internal class Game
    {
        // автошахматы
        // Проблемы: определение победителя и завершения игры + рефакторинг, правила

        int step = 0;

        Random rnd = new Random();
        Controler player, fate;
        GameField field;

        Dictionary<SelectedFigure, Figure> figs = new Dictionary<SelectedFigure, Figure>()
        {
            { SelectedFigure.Triangle , new Triangle() },
             { SelectedFigure.Rectangle , new Rect() },
              { SelectedFigure.Circle , new Circle() }
        };

        public Game() { }
        public Game(GameField field, SelectedFigure selectedFigure)
        {
            player = new Controler(true, field, figs);
            fate = new Controler(false, field, figs);

            this.field = field;
        }

        public void DrawField(Graphics g)
        {
            field.DrawGrid(g);
            field.DrawFigures(g);
        }

        public void Placement(int X, int Y, SelectedFigure selectedFigure)
        {
            player.Placement(X, Y, selectedFigure);
        }

        public void Placement()
        {
            fate.Placement(rnd);
        }

        public int GetQuantiti(Figure f)
        {
            return player.coins / f.cost;
        }


        private void Stap(Type type, bool plaer)
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (field.figures[i, j]?.GetType() == type && field.figures[i, j].isPlayer == plaer) field.figures[i, j].Move(field.figures, rnd, field);
                }
            }
        }

        public void Queue()
        {
            switch (step % 6)
            {
                case 0:
                    Stap(typeof(Triangle), true);
                    break;
                case 1:
                    Stap(typeof(Triangle), false);
                    break;
                case 2:
                    Stap(typeof(Rect), true);
                    break;
                case 3:
                    Stap(typeof(Rect), false);
                    break;
                case 4:
                    Stap(typeof(Circle), true);

                    break;
                case 5:
                    Stap(typeof(Circle), false);
                    break;
            }
            step++;
        }
    }
}
