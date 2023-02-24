using GameEngine.Primitives.Events;
using UnityEngine;

namespace GameEngine.Components
{
    public sealed class DeathComponent : MonoBehaviour, IDeathComponent
    {
        [SerializeField]
        private EventReceiver deathReceiver;
        
        public void Death(object reason)
        {
            Debug.Log($"Death {deathReceiver.name} from reason: {reason}");
            deathReceiver.Call();
        }
    }
}