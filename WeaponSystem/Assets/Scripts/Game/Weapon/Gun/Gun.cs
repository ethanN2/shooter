using System.Collections;
using UnityEngine;

namespace Game.Weapon.Gun
{
    public class Gun : Base, IGun, IReloadable
    {
        private                  Coroutine _currentCoroutine;
        [SerializeField] private int       _currentAmmo;
        [SerializeField] private int       _currentMagazine;

        public int  CurrentMagazine => _currentMagazine;
        public int  CurrentAmmo     => _currentAmmo;
        public bool CanUse          => _currentMagazine > 0 && _currentAmmo > 0;
        public bool IsReloading     { get; private set; }
        public bool IsFiring        { get; private set; }
        public bool CanReload       => _currentMagazine == 0 && _currentAmmo > 0;

        #region Unity Event

        public void OnEnable()
        {
        }

        #endregion

        #region Public Methods

        public override void Initialize()
        {
            var gunData = (Items.FireWeapons.Gun)weaponData;
            _currentMagazine = gunData.MagazineSize;
            _currentAmmo     = gunData.MaxAmmo - gunData.MagazineSize;
            base.Initialize();
        }

        public void UpdateWeapon(Player owner, float deltaTime)
        {
            
        }

        public void Reload()
        {
            _currentCoroutine ??= StartCoroutine(Reloading());
        }

        public void CancelReload()
        {
            if (_currentCoroutine != null)
                StopCoroutine(Reloading());
        }

        public void Fire()
        {
            _currentCoroutine ??= StartCoroutine(Firing());
        }

        #endregion

        #region Private Methods

        private IEnumerator Firing()
        {
            var gunData = (Items.FireWeapons.Gun)weaponData;
            yield return new WaitForSeconds(gunData.FireRate);
            Debug.Log($"{gunData.Name} type {gunData.WeaponType} Fire!");
            _currentMagazine--;
            _currentCoroutine = null;
        }

        protected virtual IEnumerator Reloading()
        {
            if (weaponData is not Items.FireWeapons.Gun gunData) yield break;
            yield return new WaitForSeconds(gunData.ReloadTime);
            Debug.Log($"{gunData.Name} type {gunData.WeaponType} Reloaded!");
            AdjustAmmoAfterReload(gunData);
            _currentCoroutine = null;
        }

        private void AdjustAmmoAfterReload(Items.FireWeapons.Gun gunData)
        {
            var delta = _currentAmmo - gunData.MagazineSize;
            _currentAmmo     = delta > 0 ? delta : 0;
            _currentMagazine = delta > 0 ? gunData.MagazineSize : 0;
        }

        #endregion
    }
}