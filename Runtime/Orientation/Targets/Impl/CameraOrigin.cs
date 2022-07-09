using Depra.Pawn.Runtime.Orientation.Targets.Abstract;
using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Targets.Impl
{
    public class CameraOrigin : OrientationOrigin
    {
        public override void SetLocalRotation(Quaternion horizontalRotation, Quaternion verticalRotation)
        {
            LocalRotation = horizontalRotation * verticalRotation;
        }

        public CameraOrigin(ILocalPositionProvider positionProvider, ILocalRotationProvider cameraOrigin) : base(
            positionProvider, cameraOrigin)
        {
        }
    }
}