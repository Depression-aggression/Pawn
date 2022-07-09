using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Targets.Impl
{
    public class TransformLocalRotationProvider : ILocalRotationProvider
    {
        private readonly Transform _transform;

        public Quaternion LocalRotation
        {
            get => _transform.localRotation;
            set => _transform.localRotation = value;
        }

        public TransformLocalRotationProvider(Transform transform)
        {
            _transform = transform;
        }
    }
}