using UnityEngine;

namespace GameEngine.Entities
{
    public interface IEntity
    {
        T Get<T>();
        bool TryGet<T>(out T result);
        void Add(MonoBehaviour component);
        bool Remove(MonoBehaviour component);
    }
}