using Homeworks._1_GameMechanics.Scripts.Primitives.Events;
using UnityEngine;

namespace Homeworks._2_GameComponents.Scripts.Components
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