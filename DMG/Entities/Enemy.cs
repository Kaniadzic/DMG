using DMG.Enums;

namespace DMG.Entities
{
    public class Enemy
    {
        public EnemyTypes type { get; set; }
        public ushort hitpoints { get; set; }
        public ushort armor { get; set; }
        public char symbol { get; set; }
    }

    public class BoardEnemy
    {
        public Enemy enemy { get; set; }
        public EnemyCoordinates coordinates { get; set; }
    }

    public class EnemyCoordinates
    {
        public EnemyCoordinates() {}

        public EnemyCoordinates(byte x, byte y)
        {
            this.x = x;
            this.y = y;
        }

        public byte x { get; set; }
        public byte y { get; set; }
    }
}
