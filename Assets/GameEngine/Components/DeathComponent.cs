using System;
using GameEngine.Primitives.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameEngine.Components
{
    public sealed class DeathComponent : MonoBehaviour, IDeathComponent
    {
        [SerializeField]
        private ObjectEventReceiver m_DeathReceiver;

        public event Action<object> OnDeath;

        private void OnEnable()
        {
            m_DeathReceiver.OnEvent += OnDeathEventReceived;
        }

        private void OnDeathEventReceived(object reason)
        {
            OnDeath?.Invoke(reason);
        }

        private void OnDisable()
        {
            m_DeathReceiver.OnEvent -= OnDeathEventReceived;
        }

        

        public void Death(object reason)
        {
            Debug.Log($"Death {m_DeathReceiver.name} from reason: {reason}");
            m_DeathReceiver.Call(reason);
        }
    }
}