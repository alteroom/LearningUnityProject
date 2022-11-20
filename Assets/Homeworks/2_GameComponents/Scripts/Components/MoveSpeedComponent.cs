using Homeworks._1_GameMechanics.Scripts.Primitives.Containers;
using UnityEngine;

namespace Homeworks._2_GameComponents.Scripts.Components
{
    public class MoveSpeedComponent : MonoBehaviour, IMoveSpeedComponent
    {
        [SerializeField] private FloatBehaviour speed;
        
        public float Speed => speed.Value;
    }
}