using Homeworks._2_GameComponents.Scripts.Components;
using UnityEngine;

namespace Homeworks._2_GameComponents.Scripts.Controllers
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField] 
        private Entity entity;

        private IMoveComponent _moveComponent;
        private IMoveSpeedComponent _moveSpeedComponent;

        [SerializeField] 
        private InputMap inputMap;
        private void Awake()
        {
            _moveComponent = entity.Get<IMoveComponent>();
            _moveSpeedComponent = entity.Get<IMoveSpeedComponent>();
        }

        private void Update()
        {
            if (HasMoveInput(out var direction))
            {
                var speed = _moveSpeedComponent.Speed * Time.deltaTime;
                var moveAmount = direction.normalized * speed;
                _moveComponent.Move(moveAmount);
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