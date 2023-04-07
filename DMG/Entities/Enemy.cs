using DMG.Enums;

namespace DMG.Entities
{
    /// <summary>
    /// Przeciwnik ze statystykami
    /// </summary>
    public class Enemy
    {
        public EnemyTypes type { get; set; }
        public ushort hitpoints { get; set; }
        public ushort armor { get; set; }
        public char symbol { get; set; }

        public void takeDamage(ushort damage, ushort penetration)
        {
            if (this.armor >= 0)
            {
                this.armor -= (ushort)(damage * penetration);
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
