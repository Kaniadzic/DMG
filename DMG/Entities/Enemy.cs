using DMG.Enums;

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
        public byte x { get; set; }
        public byte y { get; set; }

        public Enemy() { }

        public Enemy(byte x, byte y) 
        {
            this.x = x;
            this.y = y;
        }

        public Enemy(EnemyTypes type, short hitpoints, short armor, char symbol, byte x, byte y)
        {
            this.type = type;
            this.hitpoints = hitpoints;
            this.armor = armor;
            this.symbol = symbol;
            this.x = x;
            this.y = y;
        }
    }
}
