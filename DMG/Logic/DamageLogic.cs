using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMG.Logic
{
    public class DamageLogic
    {
        /// <summary>
        /// Obliczenie damage
        /// </summary>
        /// <param name="minDamage"> min damage </param>
        /// <param name="maxDamage"> max damage </param>
        /// <returns> Surowy damage (bez penetracji) </returns>
        public short calculateDamage(short minDamage, short maxDamage)
        {
            Random random = new Random();

            short calculatedDamage = (short)random.Next(minDamage, maxDamage);

            return calculatedDamage;
        }

        /// <summary>
        /// Obliczenie penetracji
        /// </summary>
        /// <param name="penetration"> wartość penetracji broni </param>
        /// <returns> Penetracja </returns>
        public double calculatePenetration(short penetration)
        {
            double penetrationValue = (double)penetration / 100;

            return penetrationValue;
        }

        /// <summary>
        /// Sprawdzenie czy projectile trafił
        /// </summary>
        /// <param name="hitChance"> Szansa trafienia </param>
        /// <returns> Trafienie </returns>
        public bool calculateHit(short hitChance = 100)
        {
            if (hitChance >= 100) return true;

            Random random = new Random();
            short hit = (short)random.Next(1, 100);

            return hit <= hitChance;
        }
    }
}
