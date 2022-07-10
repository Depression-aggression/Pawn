using Depra.Pawn.Runtime.Locomotion.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Targets.Impl
{
    internal class TransformDirectionTransformer : IDirectionTransformer
    {
        private readonly Transform _transform;

        public Vector3 WorldToLocalDirection(Vector3 direction) => _transform.TransformDirection(direction);

        public TransformDirectionTransformer(Transform transform)
        {
            _transform = transform;
        }
    }
}