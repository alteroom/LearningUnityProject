using GameEngine.Components;
using GameEngine.Entities;
using GameEngine.Services;
using Modules.GameSystem.Context;
using Modules.GameSystem.GameElements;
using UnityEngine;

namespace GameEngine.Controllers
{
    public sealed class ShootController : MonoBehaviour,
        
    IGameConstructElement, 
    IGameStartElement, 
    IGamePauseElement, 
    IGameResumeElement, 
    IGameFinishElement
    {
        
        [SerializeField] 
        private InputMap inputMap;
        private IShootComponent m_ShootComponent;

        
        private void Awake()
        {
            enabled = false;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(inputMap.ShootMouseButton))
            {
                var direction = GetShootDirection();
                m_ShootComponent.Shoot(direction);
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

        void IGameConstructElement.ConstructGame(IGameContext context)
        {
            var entity = context.GetService<HeroService>().GetCharacter();
            m_ShootComponent = entity.Get<IShootComponent>();
        }

        void IGameStartElement.StartGame()
        {
            enabled = true;
        }

        void IGamePauseElement.PauseGame()
        {
            enabled = false;
        }

        void IGameResumeElement.ResumeGame()
        {
            enabled = true;
        }

        void IGameFinishElement.FinishGame()
        {
            enabled = false;
        }
    }
}