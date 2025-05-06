using Items;
using UnityEngine;

namespace Game.Weapon
{
    [AddComponentMenu("Gun/Base")]
    public abstract class Base : MonoBehaviour, IInitializable, IWeapon
    {
        [SerializeField] protected BaseWeaponData weaponData;

        public bool       IsInitialized { get; protected set; }
        public BaseWeaponData WeaponData    => weaponData;

        public virtual void Initialize()
        {
            Debug.Log("Initialize successfully!");
            gameObject.SetActive(true);
            IsInitialized = true;
        }

        public abstract void UpdateWeapon(Player owner, float deltaTime);
    }
}