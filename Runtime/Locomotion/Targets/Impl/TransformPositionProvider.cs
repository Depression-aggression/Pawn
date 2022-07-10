using Depra.Pawn.Runtime.Locomotion.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Targets.Impl
{
    internal class TransformPositionProvider : IPositionProvider
    {
        private readonly Transform _transform;

        public Vector3 Position
        {
            get => _transform.position;
            set => _transform.position = value;
        }

        public TransformPositionProvider(Transform transform)
        {
            _transform = transform;
        }
    }
}