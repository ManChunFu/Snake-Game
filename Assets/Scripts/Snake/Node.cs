using UnityEngine;

namespace Assets.Scripts.Snake
{
    public class Node
    {
        /// <summary>
        /// Create last part of snake without next 
        /// </summary>
        /// <param name="newSnakePartTransform">the transform of the new GameObject</param>
        public Node(Transform newSnakePartTransform) 
        {
            SnakePartTransform = newSnakePartTransform;
        }
        /// <summary>
        /// Create snake part
        /// </summary>
        /// <param name="newSnakePartTransform"></param>
        /// <param name="newNext"></param>
        public Node(Transform newSnakePartTransform, Node newNext) 
        {
            SnakePartTransform = newSnakePartTransform;
            this.CurrentNext = newNext;
        }
        
        public Node CurrentNext;

        public Transform SnakePartTransform;

        /// <summary>
        /// Set a new position and rotation to the next body 
        /// </summary>
        public void SetLocation(Vector3 newPosition, Quaternion newRotation)
        {
            if (CurrentNext != null)
                CurrentNext.SetLocation(SnakePartTransform.position, SnakePartTransform.rotation);
            
            SnakePartTransform.SetPositionAndRotation(newPosition, newRotation);
        }       

        /// <summary>
        /// Grow new body part
        /// </summary>
        /// <param name="newTransform"></param>
        public void ChangeNext(Transform newTransform)
        {
            CurrentNext = new Node(newTransform, CurrentNext);
        }

    }

}
