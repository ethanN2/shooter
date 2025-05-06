using UnityEngine;

namespace Items.FireWeapons
{
    [CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]
    public class GunData : BaseWeaponData
    {
        [SerializeField] protected float _fireRate;
        [SerializeField] protected int   _bulletFire;
        [SerializeField] protected int   _magazineSize;
        [SerializeField] protected int   _maxAmmo;
        [SerializeField] protected int   _reloadTime;

        public float FireRate     => _fireRate;
        public int   BulletFire   => _bulletFire;
        public int   MagazineSize => _magazineSize;
        public int   ReloadTime   => _reloadTime;
        public int   MaxAmmo      => _maxAmmo;
    }
}