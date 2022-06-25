using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.HeadTilt.Impl
{
    public struct LastTwoDirections
    {
        public Vector2 Direction { get; }

        public Vector2 PreviousDirection { get; }

        public LastTwoDirections(Vector2 direction, Vector2 previousDirection)
        {
            Direction = direction;
            PreviousDirection = previousDirection;
        }
    }
}