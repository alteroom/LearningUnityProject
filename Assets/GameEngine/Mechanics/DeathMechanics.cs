using GameEngine.Primitives.Containers;
using GameEngine.Primitives.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameEngine.Mechanics
{
    public sealed class DeathMechanics : MonoBehaviour
    {
        [SerializeField]
        private IntBehaviour m_HitPoints;

        [SerializeField]
        private ObjectEventReceiver m_DeathReceiver;

        private void OnEnable()
        {
            m_HitPoints.OnValueChanged += this.OnHitPointsChanged;
        }

        private void OnDisable()
        {
            m_HitPoints.OnValueChanged -= this.OnHitPointsChanged;
        }

        private void OnHitPointsChanged(int newHitPoints)
        {
            if (newHitPoints <= 0)
            {
                m_DeathReceiver.Call("NoHitPoints");
            }
        }
    }
}