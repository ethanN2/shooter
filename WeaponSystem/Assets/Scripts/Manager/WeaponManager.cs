using System;
using System.Collections.Generic;
using Game.Weapon;
using Game.Weapon.Gun;
using Items;
using Unity.VisualScripting;
using UnityEngine;

namespace Manager
{
    [AddComponentMenu("Default/WeaponManager")]
    public class WeaponManager : MonoBehaviour
    {
        #region Fields

        private static WeaponManager _instance;

        [SerializeField] private List<Base> _weaponPrefabs   = new();
        private                  List<Base> _weaponInstances = new();

        #endregion

        #region Properties

        public static WeaponManager Instance    => _instance;
        public static bool          HasInstance => _instance != null;
        public        bool          IsInit      { get; private set; }

        #endregion

        #region Unity Methods

        // Awake is called once before the first execution of Update after the MonoBehaviour is created
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                return;
            }

            _instance = this;
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            foreach (var prefab in _weaponPrefabs)
            {
                var obj = Instantiate(prefab, transform).GetComponent<Base>();
                obj.gameObject.SetActive(false);
                _weaponInstances.Add(obj);
            }
            IsInit = true;
        }

        // These functions will be called when the attached GameObject is enabled.
        private void OnEnable()
        {
        }

        // Update is called once per frame
        private void Update()
        {
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

        public Base GetWeapon(WeaponType weaponType)
        {
            foreach (var weapon in _weaponInstances)
            {
                if (weapon.WeaponData.WeaponType == weaponType)
                {
                    return weapon;
                }
            }

            return null;
        }
        
        public void ReturnWeapon(GameObject weapon)
        {
            weapon.transform.SetParent(transform);
            weapon.gameObject.SetActive(false);
        }

        #endregion

        #region Private Methods

        #endregion
    }
}