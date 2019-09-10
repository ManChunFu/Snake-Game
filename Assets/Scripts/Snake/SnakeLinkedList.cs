using System;
using UnityEngine;

namespace Assets.Scripts.Snake
{
    public class SnakeLinkedList 
    {
        private Node _headNode;
        private Vector3 _desiredDirection, _desiredRotation;
        public SnakeLinkedList(Transform head, Transform body, Transform tail)
        {
            _headNode = new Node(head, new Node(body, new Node(tail)));
        }

        public Vector3 Direction { get; internal set; }

        internal void PreSetDirectionAndRotation(Vector3 desiredDirection, Vector3 desiredRotation)
        {
            _desiredDirection = desiredDirection;
            _desiredRotation = desiredRotation;
        }

        public void Move()
        {
            Vector3 newPosition = _headNode.SnakePartTransform.position + _desiredDirection;
            _headNode.SetLocation(newPosition, Quaternion.Euler(_desiredRotation));
            Direction = _desiredDirection;
        }

        public void Grow(Transform newTransform)
        {
            newTransform.SetPositionAndRotation(_headNode.SnakePartTransform.position, _headNode.SnakePartTransform.rotation);
            _headNode.SnakePartTransform.SetPositionAndRotation(_headNode.SnakePartTransform.position + _desiredDirection, Quaternion.Euler(_desiredRotation));

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



