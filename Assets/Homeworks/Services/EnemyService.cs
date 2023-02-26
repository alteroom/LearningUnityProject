using GameEngine.Entities;
using Modules.Services;
using UnityEngine;

namespace Homeworks.Services
{
    public class EnemyService : MonoBehaviour, ICharacterService
    {
        [SerializeField] private Entity m_Character;
        
        public IEntity GetCharacter()
        {
            return m_Character;
        }
       
    }
}