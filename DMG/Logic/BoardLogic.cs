using DMG.Entities;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace DMG.Logic
{
    public class BoardLogic
    {
        /// <summary>
        /// Wypełnienie planszy przeciwnikami
        /// </summary>
        /// <param name="enemies"> Lista przeciwników z koordynatami </param>
        /// <param name="size"> Rozmiar planszy </param>
        /// <returns> Plansza z przeciwnikami </returns>
        public Enemy[,] generateBoard(List<Enemy> enemies, ushort size = 9)
        {
            Enemy[,] board = new Enemy[size, size];

            foreach(var enemy in enemies)
            {
                board[enemy.x, enemy.y] = enemy;
            }

            return board;
        }

        /// <summary>
        /// Dodanie przeciwników do planszy
        /// </summary>
        /// <param name="enemies"> Lista przeciwników </param>
        public void populateBoardWithEnemies(List<Enemy> enemies, Grid grid)
        {
            foreach (var enemy in enemies)
            {
                Button btn = new Button();
                btn.Content = enemy.symbol;
                btn.Height = 32;
                btn.Width = 32;
                btn.FontWeight = FontWeights.Bold;
                btn.Background = Brushes.Green;
                btn.BorderBrush = null;

                grid.Children.Add(btn);

                Grid.SetRow(btn, enemy.y);
                Grid.SetColumn(btn, enemy.x);
            }
        }

        public void deleteEnemyFromBoard(Grid grid)
        {
            
        }

        /// <summary>
        /// Wypełnienie planszy buttonami
        /// </summary>
        /// <param name="x"> rozmiar x </param>
        /// <param name="y"> rozmiar y </param>
        public void populateBoard(Grid grid, byte x = 9, byte y = 9)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Button btn = new Button();
                    btn.Content = "";
                    btn.Height = 32;
                    btn.Width = 32;
                    btn.BorderBrush = null;

                    grid.Children.Add(btn);

                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                }
            }
        }
    }
}
