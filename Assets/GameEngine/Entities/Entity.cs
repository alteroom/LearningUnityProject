using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameEngine.Entities
{
    public sealed class Entity : MonoBehaviour, IEntity
    {
        [SerializeField] 
        private List<MonoBehaviour> components;

        public T Get<T>()
        {
            foreach (var component in components)
            {
                if (component is T result)
                {
                    return result;
                }
            }
            throw new Exception($"Component {typeof(T).Name} not found in {this.name}");
        }

        public bool TryGet<T>(out T result)
        {
            foreach (var component in components)
            {
                if (component is T resultComponent)
                {
                    result = resultComponent;
                    return true;
                }
            }

            result = default;
            return false;
        }
        public void Add(MonoBehaviour component)
        {
            components.Add(component);
        }

        public bool Remove(MonoBehaviour component)
        {
            return components.Remove(component);
        }
    }
}
