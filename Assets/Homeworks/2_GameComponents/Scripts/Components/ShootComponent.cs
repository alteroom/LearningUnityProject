using Homeworks._1_GameMechanics.Scripts.Primitives.Events;
using UnityEngine;

namespace Homeworks._2_GameComponents.Scripts.Components
{
    public sealed class ShootComponent : MonoBehaviour, IShootComponent
    {
        [SerializeField]
        private Vector3EventReceiver shootInDirectionReceiver;
        
        public void Shoot(Vector3 direction)
        {
            shootInDirectionReceiver.Call(direction);
        }
    }
}