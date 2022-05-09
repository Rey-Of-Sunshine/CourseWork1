﻿using System;
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

        int stap = 0;

        Random rnd = new Random();
        Figure[,] figures = new Figure[12, 12];
        Controler player, fate;
        GameField field;
        SelectedFigure selectedFigure;
        Dictionary<SelectedFigure, Figure> figs;


        public Game() { }
        public Game(GameField field, SelectedFigure selectedFigure, Dictionary<SelectedFigure, Figure> figs)
        {
            player = new Controler(figures, true, field, selectedFigure, figs);
            fate = new Controler(figures, false, rnd.Next(12), rnd.Next(5), field, selectedFigure, figs);

            this.field = field;
            this.selectedFigure = selectedFigure;
            this.figs = figs;
        }

        public void DrawField(Graphics g)
        {
            field.DrawGrid(g);
            field.DrawFigures(g, figures);
        }

        public void Queue(int a)
        {
            switch (a)
            {
                case 0:
                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (figures[i, j] is Triangle && figures[i, j].isPlayer) figures[i, j].Move(figures, rnd, field);
                        }
                    }
                    stap++;
                    break;
                case 1:

                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (figures[i, j] is Triangle && !figures[i, j].isPlayer) figures[i, j].Move(figures, rnd, field);
                        }
                    }
                    stap++;
                    break;
                case 2:
                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (figures[i, j] is Rect && figures[i, j].isPlayer) figures[i, j].Move(figures, rnd, field);
                        }
                    }
                    stap++;
                    break;
                case 3:
                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (figures[i, j] is Rect && !figures[i, j].isPlayer) figures[i, j].Move(figures, rnd, field);
                        }
                    }
                    stap++;
                    break;
                case 4:
                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (figures[i, j] is Circle && figures[i, j].isPlayer) figures[i, j].Move(figures, rnd, field);
                        }
                    }
                    stap++;
                    break;
                case 5:
                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (figures[i, j] is Circle && !figures[i, j].isPlayer) figures[i, j].Move(figures, rnd, field);
                        }
                    }
                    stap++;
                    break;
            }
        }
    }
}
