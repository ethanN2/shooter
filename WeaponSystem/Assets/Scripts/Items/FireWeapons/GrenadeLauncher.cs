using UnityEngine;

namespace Items.FireWeapons
{
    [CreateAssetMenu(fileName = "GrenadeLauncher", menuName = "Weapon/GrenadeLauncher")]
    public class GrenadeLauncher : Gun
    {
        public float launchForce = 500f;
    }
}