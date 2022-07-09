using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Structs
{
    public readonly struct BiaxialRotation
    {
        public Quaternion HorizontalRotation { get; }
        
        public Quaternion VerticalRotation { get; }

        public BiaxialRotation(Quaternion horizontalRotation, Quaternion verticalRotation)
        {
            HorizontalRotation = horizontalRotation;
            VerticalRotation = verticalRotation;
        }
    }
}