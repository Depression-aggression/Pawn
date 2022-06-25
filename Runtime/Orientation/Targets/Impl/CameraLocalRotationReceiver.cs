using System.Runtime.CompilerServices;
using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Targets.Impl
{
    public readonly struct CameraLocalRotationReceiver : ILocalRotationReceiver
    {
        private readonly Transform _origin;

        public Quaternion LocalRotation => _origin.localRotation;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLocalRotation(Quaternion rotation)
        {
            _origin.localRotation = rotation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLocalRotation(Quaternion horizontalRotation, Quaternion verticalRotation)
        {
            var localRotation = horizontalRotation * verticalRotation;
            _origin.localRotation = localRotation;
        }

        public CameraLocalRotationReceiver(Transform cameraOrigin)
        {
            _origin = cameraOrigin;
        }
    }
}