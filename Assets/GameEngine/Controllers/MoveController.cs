using Homeworks._2_GameComponents.Scripts.Components;
using UnityEngine;

namespace Homeworks._2_GameComponents.Scripts.Controllers
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField] 
        private Entity entity;

        private IMoveComponent _moveComponent;
        
        [SerializeField] 
        private InputMap inputMap;
        private void Awake()
        {
            _moveComponent = entity.Get<IMoveComponent>();
        }

        private void Update()
        {
            if (HasMoveInput(out var direction))
            {
                direction = direction.normalized * Time.deltaTime;
                _moveComponent.Move(direction);
            }
            
        }

        private bool HasMoveInput(out Vector3 direction)
        {
            if (Input.GetKey(inputMap.LeftKeyCode))
            {
                direction = Vector3.left;
                return true;
            }
            if (Input.GetKey(inputMap.RightKeyCode))
            {
                direction = Vector3.right;
                return true;
            }
            if (Input.GetKey(inputMap.ForwardKeyCode))
            {
                direction = Vector3.forward;
                return true;
            }
            if (Input.GetKey(inputMap.BackKeyCode))
            {
                direction = Vector3.back;
                return true;
            }
            direction = Vector3.zero;
            return false;
        }

       
    }
}