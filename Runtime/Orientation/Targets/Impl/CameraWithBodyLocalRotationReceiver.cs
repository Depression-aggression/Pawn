using System.Runtime.CompilerServices;
using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Targets.Impl
{
    public readonly struct CameraWithBodyLocalRotationReceiver : ILocalRotationReceiver
    {
        private readonly Transform _bodyOrigin;
        private readonly Transform _cameraOrigin;

        public Quaternion LocalRotation => _cameraOrigin.localRotation;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLocalRotation(Quaternion rotation)
        {
            _cameraOrigin.localRotation = rotation;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLocalRotation(Quaternion horizontalRotation, Quaternion verticalRotation)
        {
            _bodyOrigin.rotation = horizontalRotation;
            _cameraOrigin.localRotation = verticalRotation;
        }

        public CameraWithBodyLocalRotationReceiver(Transform cameraOrigin, Transform bodyOrigin)
        {
            _cameraOrigin = cameraOrigin;
            _bodyOrigin = bodyOrigin;
        }
    }
}