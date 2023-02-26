using GameEngine.Entities;
using UnityEngine;

namespace GameEngine.Services
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