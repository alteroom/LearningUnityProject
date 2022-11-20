using Homeworks._2_GameComponents.Scripts.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace Homeworks._2_GameComponents.Scripts.Controllers
{
    public sealed class ShootController : MonoBehaviour
    {
        [SerializeField] 
        private Entity entity;

        [SerializeField] 
        private InputMap inputMap;
        private IShootComponent _shootComponent;

        
        private void Awake()
        {
            _shootComponent = entity.Get<IShootComponent>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(inputMap.ShootMouseButton))
            {
                var direction = GetShootDirection();
                _shootComponent.Shoot(direction);
            }
        }

        private Vector3 GetShootDirection()
        {
            if (Input.GetKey(inputMap.LeftKeyCode))
                return Vector3.left;
            if (Input.GetKey(inputMap.RightKeyCode))
                return Vector3.right;
            if (Input.GetKey(inputMap.BackKeyCode))
                return Vector3.back;
            return Vector3.forward;
        }
    }
}