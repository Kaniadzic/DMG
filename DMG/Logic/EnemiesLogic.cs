using DMG.Entities;
using DMG.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMG.Logic
{
    public class EnemiesLogic
    {
        private List<Enemy> predefinedEnemies = new List<Enemy>();

        public EnemiesLogic()
        {
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Bunker, armor = (ushort)ArmorValues.lot, hitpoints = (ushort)HitpointsValues.medium, symbol = 'B' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Barrack, armor = (ushort)ArmorValues.few, hitpoints = (ushort)HitpointsValues.lot, symbol = 'A' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Trench, armor = (ushort)ArmorValues.few, hitpoints = (ushort)HitpointsValues.medium, symbol = 'U' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.AntiAir, armor = (ushort)ArmorValues.few, hitpoints = (ushort)HitpointsValues.few, symbol = '/' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Tank, armor = (ushort)ArmorValues.medium, hitpoints = (ushort)HitpointsValues.lot, symbol = '=' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Truck, armor = (ushort)ArmorValues.none, hitpoints = (ushort)HitpointsValues.medium, symbol = '-' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.CommandPost, armor = (ushort)ArmorValues.lot, hitpoints = (ushort)HitpointsValues.few, symbol = '*' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Airstrip, armor = (ushort)ArmorValues.lot, hitpoints = (ushort)HitpointsValues.hitpoint, symbol = '|' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Hangar, armor = (ushort)ArmorValues.none, hitpoints = (ushort)HitpointsValues.lot, symbol = 'H' });
        }

        /// <summary>
        /// Generowanie listy przeciwników oraz ich koordynatów na planszy
        /// </summary>
        /// <param name="enemiesCount"> liczba generowanych przeciwników </param>
        /// <returns> Lista przeciwników i koordynatów </returns>
        public List<BoardEnemy> generateBoardEnemies(ushort enemiesCount = 9)
        {
            List<BoardEnemy> boardEnemies = new List<BoardEnemy>();
            Random random = new Random();

            List<EnemyCoordinates> coordinates = generateEnemiesCoordinates(enemiesCount);

            for (int i = 0; i < enemiesCount; i++)
            {
                boardEnemies.Add(new BoardEnemy
                {
                    enemy = predefinedEnemies.ElementAt(random.Next(1, 9)),
                    coordinates = coordinates.ElementAt(i)
                });
            }

            return boardEnemies;
        }

        /// <summary>
        /// Generowanie koordynatów na planszy
        /// </summary>
        /// <param name="enemiesCount"> liczba generowanych koordynatów </param>
        /// <param name="maxX"> maksymalna wartość X </param>
        /// <param name="maxY"> maksymalna wartość Y </param>
        /// <returns> Lista koordynatów </returns>
        public List<EnemyCoordinates> generateEnemiesCoordinates(ushort enemiesCount = 9, byte maxX = 9, byte maxY = 9)
        {
            List<EnemyCoordinates> coordinates = new List<EnemyCoordinates>();
            Random random = new Random();

            // lista pomocnicza
            List<string> helperList = new List<string>();

            while (coordinates.Count < enemiesCount)
            {
                EnemyCoordinates coord = new EnemyCoordinates(
                    (byte)random.Next(0, maxX),
                    (byte)random.Next(0, maxY)
                );

                if (!helperList.Contains($"{coord.x}{coord.y}"))
                {
                    helperList.Add($"{coord.x}{coord.y}");
                    coordinates.Add(coord);
                }
            }

            return coordinates;
        }
    }
}
