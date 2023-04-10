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
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Bunker, armor = (short)ArmorValues.lot, hitpoints = (short)HitpointsValues.medium, symbol = 'B' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Barrack, armor = (short)ArmorValues.few, hitpoints = (short)HitpointsValues.lot, symbol = 'A' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Trench, armor = (short)ArmorValues.few, hitpoints = (short)HitpointsValues.medium, symbol = 'U' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.AntiAir, armor = (short)ArmorValues.few, hitpoints = (short)HitpointsValues.few, symbol = '/' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Tank, armor = (short)ArmorValues.medium, hitpoints = (short)HitpointsValues.lot, symbol = '=' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Truck, armor = (short)ArmorValues.none, hitpoints = (short)HitpointsValues.medium, symbol = '-' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.CommandPost, armor = (short)ArmorValues.lot, hitpoints = (short)HitpointsValues.few, symbol = '*' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Airstrip, armor = (short)ArmorValues.lot, hitpoints = (short)HitpointsValues.hitpoint, symbol = '|' });
            predefinedEnemies.Add(new Enemy { type = EnemyTypes.Hangar, armor = (short)ArmorValues.none, hitpoints = (short)HitpointsValues.lot, symbol = 'H' });
        }

        /// <summary>
        /// Generowanie listy przeciwników oraz ich koordynatów na planszy
        /// </summary>
        /// <param name="enemiesCount"> liczba generowanych przeciwników </param>
        /// <returns> Lista przeciwników i koordynatów </returns>
        public List<Enemy> generateBoardEnemies(ushort enemiesCount = 9)
        {
            List<Enemy> boardEnemies = new List<Enemy>();
            Random random = new Random();

            List<Enemy> coordinates = generateEnemiesCoordinates(enemiesCount);

            for (int i = 0; i < enemiesCount; i++)
            {
                boardEnemies.Add(new Enemy
                {
                    hitpoints = predefinedEnemies.ElementAt(random.Next(1, 9)).hitpoints,
                    armor = predefinedEnemies.ElementAt(random.Next(1, 9)).armor,
                    symbol = predefinedEnemies.ElementAt(random.Next(1, 9)).symbol,
                    type = predefinedEnemies.ElementAt(random.Next(1, 9)).type,
                    x = coordinates.ElementAt(i).x,
                    y = coordinates.ElementAt(i).y
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
        public List<Enemy> generateEnemiesCoordinates(ushort enemiesCount = 9, byte maxX = 9, byte maxY = 9)
        {
            List<Enemy> coordinates = new List<Enemy>();
            Random random = new Random();

            // lista pomocnicza
            List<string> helperList = new List<string>();

            while (coordinates.Count < enemiesCount)
            {
                Enemy coord = new Enemy(
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
