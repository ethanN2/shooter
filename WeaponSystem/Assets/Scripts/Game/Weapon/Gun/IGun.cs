namespace Game.Weapon.Gun
{
    public interface IGun : IFireWeapon
    {
        int CurrentMagazine { get; }
        int CurrentAmmo     { get; }
    }
}