namespace DMG.Enums
{
    public enum EnemyTypes
    {
        Bunker,
        Barrack,
        Trench,
        AntiAir,
        Tank,
        Truck,
        CommandPost,
        Airstrip,
        Hangar
    }

    public enum HitpointsValues
    {
        hitpoint = 1,
        few = 20,
        medium = 50,
        lot = 100
    }

    public enum ArmorValues
    {
        none = 0,
        few = 20,
        medium = 50,
        lot = 100
    }

    public enum PenetrationValues
    {
        none = 10,
        weak = 25,
        medium = 60,
        strong = 90
    }

    public enum DamageValues
    {
        weak = 25,
        medium = 55, 
        strong = 88
    }

    public enum WeaponType
    {
       hitscan,
       projectile,
       area
    }

    public enum WindDirection
    {
        west, 
        north, 
        east,
        south
    }
}
