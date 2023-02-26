using UnityEngine;

namespace GameEngine.Entities
{
    public class EntityProxy : MonoBehaviour, IEntity
    {
        [SerializeField] private Entity m_Entity;
        public T Get<T>()
        {
            return m_Entity.Get<T>();
        }

        public bool TryGet<T>(out T result)
        {
            var localReturn = m_Entity.TryGet(out T localResult);
            result = localResult;
            return localReturn;
        }

        public void Add(MonoBehaviour component)
        {
            m_Entity.Add(component);
        }

        public bool Remove(MonoBehaviour component)
        {
            return m_Entity.Remove(component);
        }
    }
}