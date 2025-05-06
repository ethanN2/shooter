using UnityEngine;

namespace Items.FireWeapons
{
    [CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Laser")]
    public class Laser : BaseWeapon
    {
        [SerializeField]
        protected int _maxEnergy;
        [SerializeField]
        protected float _maxOverHeat;
        [SerializeField]
        protected float _chargeTime;
        
        public int MaxEnergy => _maxEnergy;
        public float MaxOverHeat => _maxOverHeat;
        public float ChargeTime => _chargeTime;
    }
}