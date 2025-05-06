namespace Game.Weapon.Gun
{
    public interface IFireWeapon : IWeapon
    {
        bool CanUse   { get; }
        void Fire();
    }

    public interface IReloadable
    {
        bool IsReloading { get; }
        bool CanReload   { get; }
        void Reload();
        void CancelReload();
    }
}