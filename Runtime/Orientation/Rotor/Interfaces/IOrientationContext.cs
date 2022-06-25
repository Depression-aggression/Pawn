using System;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Rotor.Interfaces
{
    public interface IOrientationContext
    {
        Quaternion OriginLocalRotation { get; }

        event Action<Quaternion> RotationChanged;
    }
}