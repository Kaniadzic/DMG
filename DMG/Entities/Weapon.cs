using DMG.Enums;
using System.Collections.Generic;

namespace DMG.Entities
{
    public class Weapon
    {
        public Weapon() { }

        public Weapon(string name, DamageValues damage, PenetrationValues penetration, WeaponType type, ushort hitChance) 
        { 
            this.name = name;
            this.damage = (ushort)damage;
            this.penetration = (ushort)penetration;
            this.type = type;
            this.hitChance = hitChance;
        }

        public string name { get; set; }
        public ushort damage { get; set; }
        public ushort penetration { get; set; }
        public WeaponType type { get; set; }
        public ushort hitChance { get; set; }

        public List<Weapon> initializeWeapons()
        {
            List<Weapon> weapons = new List<Weapon>
            {
                new Weapon("Karabin", DamageValues.weak, PenetrationValues.weak, WeaponType.hitscan, 100),
                new Weapon("Działko", DamageValues.medium, PenetrationValues.medium, WeaponType.hitscan, 100),
                new Weapon("Fleszetki", DamageValues.weak, PenetrationValues.weak, WeaponType.hitscan, 75),
                new Weapon("Rakieta", DamageValues.medium, PenetrationValues.strong, WeaponType.hitscan, 50),
                new Weapon("Bomba burząca", DamageValues.strong, PenetrationValues.strong, WeaponType.hitscan, 100),
                new Weapon("Bomba tocząca", DamageValues.strong, PenetrationValues.strong, WeaponType.hitscan, 100),
                new Weapon("Bomba odłamkowa", DamageValues.weak, PenetrationValues.weak, WeaponType.hitscan, 100),
                new Weapon("Bomba zapalająca", DamageValues.medium, PenetrationValues.weak, WeaponType.hitscan, 100)
            };

            return weapons;
        }
    }
}
