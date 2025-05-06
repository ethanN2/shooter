namespace Game.Weapon.Gun
{
    public interface ILaser : IFireWeapon
    {
        float CurrentEnergy { get; }
        float CurrentHeat   { get; }
    }
}