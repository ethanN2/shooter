using System;
using UnityEngine;

namespace Items
{
    public abstract class BaseWeaponData : ScriptableObject, IIdentity, IInfo, IWeapon
    {
        #region Variables

        [SerializeField] protected Guid       _guid;
        [SerializeField] protected string     _id;
        [SerializeField] protected string     _name;
        [SerializeField] protected string     _description;
        [SerializeField] protected float      _damage;
        [SerializeField] protected WeaponType _type;

        public Guid       Guid        => _guid;
        public string     Id          => _id;
        public string     Name        => _name;
        public string     Description => _description;
        public float      Damage      => _damage;
        public WeaponType WeaponType  => _type;

        #endregion

        #region Unity Methods

        public virtual void Start()
        {
            _guid = Guid.NewGuid();
        }

        public virtual void Update()
        {
        }

        #endregion
    }
}