using UnityEngine;

namespace GameEngine.Controllers
{
    [CreateAssetMenu(fileName = "InputMapSettings", menuName = "ScriptableObjects/InputMap", order = 1)]
    public class InputMap : ScriptableObject
    {
        public KeyCode ForwardKeyCode = KeyCode.W;
        public KeyCode BackKeyCode = KeyCode.S;
        public KeyCode LeftKeyCode = KeyCode.A;
        public KeyCode RightKeyCode = KeyCode.D;
        public KeyCode JumpKeyCode = KeyCode.Space;
        public int ShootMouseButton = 0;
    }
}
