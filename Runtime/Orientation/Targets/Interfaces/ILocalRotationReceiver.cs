using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Targets.Interfaces
{
    public interface ILocalRotationReceiver
    {
        Quaternion LocalRotation { get; }

        void SetLocalRotation(Quaternion rotation);
        
        void SetLocalRotation(Quaternion horizontalRotation, Quaternion verticalRotation);
    }
}