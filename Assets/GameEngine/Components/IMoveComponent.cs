using UnityEngine;

namespace GameEngine.Components
{
    public interface IMoveComponent
    {
        void Move(Vector3 direction);
    }
}