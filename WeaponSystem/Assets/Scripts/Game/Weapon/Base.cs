using Items;
using UnityEngine;

namespace Game.Weapon
{
    [AddComponentMenu("Gun/Base")]
    public abstract class Base : MonoBehaviour, IInitializable
    {
        [SerializeField] protected BaseWeapon weaponData;

        public bool       IsInitialized { get; protected set; }
        public BaseWeapon WeaponData    => weaponData;

        public virtual void Initialize()
        {
            Debug.Log("Initialize successfully!");
            gameObject.SetActive(true);
            IsInitialized = true;
        }
    }
}