using GameEngine.Primitives.Collision;
using UnityEngine;

namespace Homeworks.Services
{
    public class AbyssService : MonoBehaviour
    {
        [SerializeField] 
        private TriggerEnterBehaviour m_Trigger;

        public TriggerEnterBehaviour GetTrigger()
        {
            return m_Trigger;
        }
    }
}