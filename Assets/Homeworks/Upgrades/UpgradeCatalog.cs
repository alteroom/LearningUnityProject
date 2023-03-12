using UnityEngine;

namespace Homeworks.Upgrades
{
    [CreateAssetMenu(fileName = "UpgradeCatalog", menuName = "ScriptableObjects/UpgradeCatalog", order = 0)]
    public class UpgradeCatalog : ScriptableObject
    {
        [SerializeField] 
        public Upgrade[] Upgrades;
    }
}