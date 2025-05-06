using System.Collections;
using UnityEngine;

namespace Game.Weapon.Gun
{
    public class Laser : Base, ILaser, IReloadable
    {
        [SerializeField] private float _currentEnergy;
        [SerializeField] private float _currentHeat;

        private float     _heatReduceTimeRemain;
        private Coroutine _currentCoroutine;

        public bool  CanUse        => _currentEnergy > 0;
        public bool  IsReloading   { get; private set; }
        public bool  CanReload     => _currentEnergy == 0;
        public float CurrentEnergy => _currentEnergy;
        public float CurrentHeat   => _currentHeat;

        public void OnEnable()
        {
        }

        private void Update()
        {
        }

        public override void Initialize()
        {
            var gunData = (Items.FireWeapons.LaserData)weaponData;
            _currentEnergy = gunData.MaxEnergy;
            _currentHeat   = 0;
            base.Initialize();
        }

        public override void UpdateWeapon(Player owner, float deltaTime)
        {
            if (_heatReduceTimeRemain > 0)
            {
                _heatReduceTimeRemain -= deltaTime;
                return;
            }

            if (_currentHeat <= 0) return;

            var gunData = (Items.FireWeapons.LaserData)weaponData;
            _currentHeat = Mathf.Clamp(_currentHeat - deltaTime * 10, 0, gunData.MaxOverHeat);
        }

        public void CancelReload()
        {
            _currentHeat   = 0;
        }


        public void Reload()
        {
            _currentCoroutine ??= StartCoroutine(Reloading());
        }

        private IEnumerator Reloading()
        {
            var gunData = (Items.FireWeapons.LaserData)weaponData;
            IsReloading = true;
            yield return new WaitForSeconds(gunData.ChargeTime);
            Debug.Log($"{gunData.Name} type {gunData.WeaponType} Reloaded!");
            IsReloading    = false;
            _currentEnergy = gunData.MaxEnergy;
        }

        public void Fire()
        {
            var gunData = (Items.FireWeapons.LaserData)weaponData;
            if (_currentHeat >= gunData.MaxOverHeat)
            {
                Debug.Log($"{gunData.Name} type {gunData.WeaponType} Heat!");
                return;
            }
            _heatReduceTimeRemain =  0.8f;
            _currentHeat          =  Mathf.Clamp(_currentHeat + Time.deltaTime * 10, 0, gunData.MaxOverHeat);
            _currentEnergy        -= 0.01f;
            Debug.Log($"{gunData.Name} type {gunData.WeaponType} Fire!");
        }
    }
}