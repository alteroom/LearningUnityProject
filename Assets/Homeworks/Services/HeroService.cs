using GameEngine.Entities;
using Modules.Services;
using UnityEngine;

namespace Homeworks.Services
{
    public class HeroService : MonoBehaviour, ICharacterService
    {
        [SerializeField] private Entity m_Character;
        
        public IEntity GetCharacter()
        {
            return m_Character;
        }
    }
}