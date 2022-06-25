using Depra.Pawn.Runtime.Orientation.Modifications.Types.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Abstract
{
    public abstract class OrientationModification<T> : IOrientationModification
    {
        protected Vector2 MotionDirection { get; private set; }
        protected Vector2 PreviousMotionDirection { get; private set; }

        public abstract T Modify(T previousValue, float timeStep);
        
        public void SetDirection(Vector2 motionDirection)
        {
            MotionDirection = motionDirection;
        }

        public void ClearDirection()
        {
            PreviousMotionDirection = MotionDirection;
            MotionDirection = Vector2.zero;
        }
    }
}