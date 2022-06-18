using System;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Rotor.Interfaces
{
    public interface ICameraOrientationContext
    {
        Vector3 CameraPosition { get; }
        
        Quaternion CameraRotation { get; }
        
        event Action<Quaternion> CameraRotationChanged;
    }
}