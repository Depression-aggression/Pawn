using Depra.Pawn.Runtime.Orientation.Targets.Abstract;
using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Targets.Impl
{
    public class CameraWithBodyOrigin : OrientationOrigin
    {
        private readonly IRotationProvider _bodyOrigin;

        public override void SetLocalRotation(Quaternion horizontalRotation, Quaternion verticalRotation)
        {
            _bodyOrigin.Rotation = horizontalRotation;
            LocalRotation = verticalRotation;
        }

        public CameraWithBodyOrigin(ILocalPositionProvider localPositionProvider, ILocalRotationProvider cameraOrigin,
            IRotationProvider bodyOrigin) : base(localPositionProvider, cameraOrigin)
        {
            _bodyOrigin = bodyOrigin;
        }
    }
}