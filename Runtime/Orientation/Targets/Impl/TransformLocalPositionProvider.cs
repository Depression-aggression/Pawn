using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Targets.Impl
{
    public class TransformLocalPositionProvider :  ILocalPositionProvider
    {
        private readonly Transform _transform;
        
        public Vector3 LocalPosition
        {
            get => _transform.localPosition;
            set => _transform.localPosition = value;
        }

        public TransformLocalPositionProvider(Transform transform)
        {
            _transform = transform;
        }
    }
}