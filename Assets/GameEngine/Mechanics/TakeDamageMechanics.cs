using GameEngine.Primitives.Containers;
using GameEngine.Primitives.Events;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public sealed class TakeDamageMechanics : MonoBehaviour
    {
        [SerializeField]
        private IntEventReceiver takeDamageReceiver;

        [SerializeField]
        private IntBehaviour hitPoints;

        private void OnEnable()
        {
            this.takeDamageReceiver.OnEvent += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this.takeDamageReceiver.OnEvent -= this.OnDamageTaken;
        }

        private void OnDamageTaken(int damage)
        {
            this.hitPoints.Value -= damage;
        }
    }
}