using DMG.Enums;
using System.Collections.Generic;

namespace DMG.Entities
{
    public class Weapon
    {
        public Weapon() { }

        public Weapon(string name, ushort minDamage, ushort maxDamage, PenetrationValues penetration, WeaponType type, ushort hitChance) 
        { 
            this.name = name;
            this.minDamage = (ushort)minDamage;
            this.maxDamage = (ushort)maxDamage;
            this.penetration = (ushort)penetration;
            this.type = type;
            this.hitChance = hitChance;
        }

        public string name { get; set; }
        public ushort minDamage { get; set; }
        public ushort maxDamage { get; set; }
        public ushort penetration { get; set; }
        public WeaponType type { get; set; }
        public ushort hitChance { get; set; }
    }
}
