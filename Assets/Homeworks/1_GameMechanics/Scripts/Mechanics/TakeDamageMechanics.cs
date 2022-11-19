
using Homeworks._1_GameMechanics.Scripts.Primitives;
using Homeworks._1_GameMechanics.Scripts.Primitives.Containers;
using Homeworks._1_GameMechanics.Scripts.Primitives.Events;
using UnityEngine;

namespace Homeworks._1_GameMechanics.Scripts.Mechanics
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