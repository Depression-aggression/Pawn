using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Targets.Interfaces
{
    public interface IBiaxialLocalRotationReceiver
    {
        void SetLocalRotation(Quaternion horizontalRotation, Quaternion verticalRotation);
    }
}