using UnityEngine;

namespace Homeworks.Upgrades.HeroUpgrade
{
    [CreateAssetMenu(menuName = "Create PlayerInfo", fileName = "PlayerInfo", order = 0)]
    public class PlayerInfo : ScriptableObject
    {
        [SerializeField]
        public string Name;
        [SerializeField]
        public string Description;
        [SerializeField]
        public Sprite Icon;
    }
}