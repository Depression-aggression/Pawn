using System;
using Depra.Pawn.Runtime.Orientation.Rotor.Interfaces;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using Depra.Pawn.Runtime.UpdateMethod.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Rotor.Abstract
{
    public abstract class PawnRotor : UpdatablePawnBehavior, ICameraOrientationContext
    {
        public abstract Vector3 CameraPosition { get; }
        public Quaternion CameraRotation { get; internal set; }
        
        protected abstract OrientationType Orientation { get; set; }
        
        public event Action Updated;
        public event Action<Quaternion> CameraRotationChanged;

        protected void UpdateCameraRotation(Quaternion cameraRotation)
        {
            var previousRotation = CameraRotation;
            CameraRotation = cameraRotation;
            
            CameraRotationChanged?.Invoke(previousRotation);

            ApplyCameraRotation();
            
            Updated?.Invoke();
        }

        protected abstract void ApplyCameraRotation();
    }
}