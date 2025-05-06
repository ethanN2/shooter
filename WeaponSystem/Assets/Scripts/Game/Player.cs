using System.Collections;
using System.Collections.Generic;
using Game.Weapon;
using Game.Weapon.Gun;
using Items;
using Manager;
using TMPro;
using UnityEngine;

namespace Game
{
    [AddComponentMenu("Default/Player")]
    public class Player : MonoBehaviour
    {
        #region Fields

        [SerializeField] private TMP_Dropdown     _dropdownUI;
        [SerializeField] private List<BaseWeapon> _inventory;

        #endregion

        #region Properties

        public Base CurrentWeapon { get; private set; }

        #endregion

        #region Unity Methods

        // Awake is called once before the first execution of Update after the MonoBehaviour is created
        private void Awake()
        {
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private IEnumerator Start()
        {
            // init inventory
            while (!WeaponManager.HasInstance)
            {
                yield return null;
            }

            var optionDatas = new List<TMP_Dropdown.OptionData>();
            foreach (var weapon in _inventory)
            {
                optionDatas.Add(new TMP_Dropdown.OptionData(weapon.Name));
            }

            _dropdownUI.AddOptions(optionDatas);
            ChangeGun(0);
        }

        // These functions will be called when the attached GameObject is enabled.
        private void OnEnable()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            if (CurrentWeapon != null && !((IInitializable)CurrentWeapon).IsInitialized) return;
            HandleReloadGun();

            if (Input.GetMouseButton(0))
            {
                HandleFire();
            }
            else
            {
                ((Weapon.IWeapon)CurrentWeapon).UpdateWeapon(this, Time.deltaTime);
            }
        }

        // These functions will be called when the attached GameObject is toggled.
        private void OnDisable()
        {
        }

        #endregion

        #region Gizmos

        private void OnDrawGizmos()
        {
        }

        private void OnDrawGizmosSelected()
        {
        }

        #endregion

        #region Public Methods

        public void ChangeGun(int index)
        {
            if (CurrentWeapon != null && ((IInitializable)CurrentWeapon).IsInitialized)
            {
                HandleCancelReloadGun();
                WeaponManager.Instance.ReturnWeapon(CurrentWeapon.gameObject);
            }

            var weapon = WeaponManager.Instance.GetWeapon(_inventory[index].WeaponType);
            weapon.transform.SetParent(transform);
            ((IInitializable)weapon).Initialize();
            CurrentWeapon = weapon;
        }

        #endregion

        #region Private Methods

        private void HandleFire()
        {
            if (CurrentWeapon == null) return;

            if (CurrentWeapon is IFireWeapon { CanUse: true } gun)
            {
                gun.Fire();
            }
            else
            {
                Debug.Log($"{CurrentWeapon.name} out of magazine");
            }
        }

        private void HandleCancelReloadGun()
        {
            if (CurrentWeapon == null) return;

            if (CurrentWeapon is IReloadable reloadableWeapon)
            {
                if (reloadableWeapon.IsReloading)
                {
                    reloadableWeapon.CancelReload();
                }
                else
                {
                    Debug.Log(CurrentWeapon.name + " cannot be reloaded now.");
                }
            }
            else
            {
                Debug.Log(CurrentWeapon.name + " is not reloadable.");
            }
        }

        private void HandleReloadGun()
        {
            if (CurrentWeapon == null) return;

            if (CurrentWeapon is IReloadable reloadableWeapon)
            {
                if (reloadableWeapon.CanReload)
                {
                    reloadableWeapon.Reload();
                }
            }
            else
            {
                Debug.Log(CurrentWeapon.name + " is not reloadable.");
            }
        }

        #endregion
    }
}