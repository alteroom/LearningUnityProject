using UnityEngine;

namespace GameEngine.Mechanics
{
    public class TransformSyncMechanics : MonoBehaviour
    {
        [SerializeField] 
        private Transform sourceTransform;

        [SerializeField] 
        private Transform[] movingTransform;
         
        private Vector3 _oldPosition;
        private void Update()
        {
            if (_oldPosition == sourceTransform.position)
            {
                return;
            }
            foreach (var follower in movingTransform)
            {
                follower.position = sourceTransform.position;
            }
            _oldPosition = sourceTransform.position;
        }
    }
}