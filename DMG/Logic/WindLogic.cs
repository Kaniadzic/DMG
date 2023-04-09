using DMG.Enums;
using System;

namespace DMG.Logic
{
    public static class WindLogic
    {
        /// <summary>
        /// Losowanie kierunku wiatru
        /// </summary>
        /// <returns> Kierunek wiatru </returns>
        public static WindDirection randomizeWindDirection()
        {
            Random random = new Random();

            switch(random.Next(0, 4))
            {
                case 0:
                    return WindDirection.east;
                case 1:
                    return WindDirection.north;
                case 2:
                    return WindDirection.west;
                case 3:
                    return WindDirection.south;
            }

            return WindDirection.north;
        }
    }
}
