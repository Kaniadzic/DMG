using DMG.Entities;
using System.Collections.Generic;

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
        public Enemy[,] generateBoard(List<BoardEnemy> enemies, ushort size = 11)
        {
            Enemy[,] board = new Enemy[size, size];

            foreach(var enemy in enemies)
            {
                board[enemy.coordinates.x, enemy.coordinates.y] = enemy.enemy;
            }

            return board;
        }
    }
}
