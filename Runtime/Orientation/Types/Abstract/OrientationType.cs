using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Types.Abstract
{
    public abstract class OrientationType
    {
        public abstract Quaternion CalculateHorizontalRotation(float yaw);
        
        public abstract Quaternion CalculateVerticalRotation(float pitch);
    }
}