﻿using DMG.Enums;

namespace DMG.Entities
{
    /// <summary>
    /// Przeciwnik ze statystykami
    /// </summary>
    public class Enemy
    {
        public EnemyTypes type { get; set; }
        public short hitpoints { get; set; }
        public short armor { get; set; }
        public char symbol { get; set; }

        public void takeDamage(short damage, short penetration)
        {
            if (this.armor >= 0)
            {
                this.armor -= (short)(damage * (penetration / 100));
            }
            else
            {
                this.hitpoints -= damage;
            }
        }


        public bool checkIfTargetDestroyed()
        {
            if (this.hitpoints == 0)
            {
                return true;
            }

            return false;
        }
    }

    /// <summary>
    /// Koordynaty przeciwnika
    /// </summary>
    public class EnemyCoordinates
    {
        public EnemyCoordinates() { }

        public EnemyCoordinates(byte x, byte y)
        {
            this.x = x;
            this.y = y;
        }

        public byte x { get; set; }
        public byte y { get; set; }
    }

    /// <summary>
    /// Encja przeciwnik - koordyanty
    /// </summary>
    public class BoardEnemy
    {
        public Enemy enemy { get; set; }
        public EnemyCoordinates coordinates { get; set; }
    }
}
