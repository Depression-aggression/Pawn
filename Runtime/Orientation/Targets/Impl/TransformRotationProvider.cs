using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Targets.Impl
{
    public class TransformRotationProvider : IRotationProvider
    {
        private readonly Transform _transform;
        
        public Quaternion Rotation
        {
            get => _transform.rotation;
            set => _transform.rotation = value;
        }

        public TransformRotationProvider(Transform transform)
        {
            _transform = transform;
        }
    }
}