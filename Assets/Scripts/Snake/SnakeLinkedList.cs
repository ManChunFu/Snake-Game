using UnityEngine;

namespace Assets.Scripts.Snake
{
    public class SnakeLinkedList 
    {
        private Node _headNode;
        public SnakeLinkedList(Transform head, Transform body, Transform tail)
        {
            _headNode = new Node(head, new Node(body, new Node(tail)));
        }

        public void Move(Vector3 direction, Vector3 euler)
        {
            Vector3 newPosition = _headNode.SnakePartTransform.position + direction;
            _headNode.SetLocation(newPosition, Quaternion.Euler(euler));
        }

        public void Grow(Transform newTransform, Vector3 direction, Vector3 euler)
        {
            newTransform.SetPositionAndRotation(_headNode.SnakePartTransform.position, _headNode.SnakePartTransform.rotation);
            _headNode.SnakePartTransform.SetPositionAndRotation(_headNode.SnakePartTransform.position + direction, Quaternion.Euler(euler));

            _headNode.ChangeNext(newTransform);
        }



        public bool IsHeadTouchingBody
        {
            get
            {
                Node checkNode = _headNode.CurrentNext;

                while (checkNode != null)
                {
                    if (_headNode.SnakePartTransform.position == checkNode.SnakePartTransform.position)
                        return true;

                    checkNode = checkNode.CurrentNext;
                }
                return false;
            }
        }

        internal bool IsAppleInsideBody(Vector3 applePos)
        {
            Node checkNode = _headNode;

            while (checkNode != null)
            {
                if (applePos == checkNode.SnakePartTransform.position)
                    return true;

                checkNode = checkNode.CurrentNext;
            }
            return false;
        }
    }


}



