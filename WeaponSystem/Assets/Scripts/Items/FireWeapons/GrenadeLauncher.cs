using UnityEngine;

namespace Items.FireWeapons
{
    [CreateAssetMenu(fileName = "GrenadeLauncher", menuName = "Weapon/GrenadeLauncher")]
    public class GrenadeLauncherData : GunData
    {
        public float launchForce = 500f;
    }
}