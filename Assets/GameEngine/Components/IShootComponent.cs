using UnityEngine;

namespace GameEngine.Components
{
    public interface IShootComponent
    {
        void Shoot(Vector3 direction);
    }
}