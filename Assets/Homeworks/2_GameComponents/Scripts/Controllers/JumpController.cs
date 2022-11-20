using System;
using Homeworks._2_GameComponents.Scripts.Components;
using UnityEngine;

namespace Homeworks._2_GameComponents.Scripts.Controllers
{
    public sealed class JumpController : MonoBehaviour
    {
        [SerializeField] 
        private Entity entity;

        [SerializeField] private InputMap inputMap;
        
        private IJumpComponent _jumpComponent;
        
        private void Awake()
        {
            _jumpComponent = entity.Get<IJumpComponent>();
        }

        private void Update()
        {
            if (Input.GetKey(inputMap.JumpKeyCode))
            {
                _jumpComponent.Jump();
            }
        }
    }
}