namespace Game.Weapon
{
    public interface IInitializable
    {
        bool IsInitialized { get; }
        void Initialize();
    }

    public interface IWeapon
    {
        void UpdateWeapon(Player owner, float deltaTime);
    }
}