using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Targets.Abstract
{
    public abstract class OrientationOrigin : ILocalRotationProvider, ILocalPositionProvider,
        IBiaxialLocalRotationReceiver
    {
        private readonly ILocalPositionProvider _localPositionProvider;
        private readonly ILocalRotationProvider _localRotationProvider;

        public Quaternion LocalRotation
        {
            get => _localRotationProvider.LocalRotation;
            set => _localRotationProvider.LocalRotation = value;
        }

        public Vector3 LocalPosition
        {
            get => _localPositionProvider.LocalPosition;
            set => _localPositionProvider.LocalPosition = value;
        }

        public abstract void SetLocalRotation(Quaternion horizontalRotation, Quaternion verticalRotation);

        protected OrientationOrigin(ILocalPositionProvider localPositionProvider,
            ILocalRotationProvider localRotationProvider)
        {
            _localPositionProvider = localPositionProvider;
            _localRotationProvider = localRotationProvider;
        }
    }
}