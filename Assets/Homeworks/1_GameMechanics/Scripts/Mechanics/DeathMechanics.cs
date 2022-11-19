
using Homeworks._1_GameMechanics.Scripts.Primitives;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Mechanics
{
    public sealed class DeathMechanics : MonoBehaviour
    {
        [SerializeField]
        private IntBehaviour hitPoints;

        [SerializeField]
        private EventReceiver deathReceiver;

        private void OnEnable()
        {
            this.hitPoints.OnValueChanged += this.OnHitPointsChanged;
        }

        private void OnDisable()
        {
            this.hitPoints.OnValueChanged -= this.OnHitPointsChanged;
        }

        private void OnHitPointsChanged(int newHitPoints)
        {
            if (newHitPoints <= 0)
            {
                this.deathReceiver.Call();
            }
        }
    }
}