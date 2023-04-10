using DMG.Enums;
using System.Collections.Generic;

namespace DMG.Entities
{
    public class Weapon
    {
        public Weapon() { }

        public Weapon(string name, short minDamage, short maxDamage, PenetrationValues penetration, WeaponType type, short hitChance) 
        { 
            this.name = name;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.penetration = (short)penetration;
            this.type = type;
            this.hitChance = hitChance;
        }

        public string name { get; set; }
        public short minDamage { get; set; }
        public short maxDamage { get; set; }
        public short penetration { get; set; }
        public WeaponType type { get; set; }
        public short hitChance { get; set; }
    }
}
