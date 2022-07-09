using System;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.Zoom.Impl
{
    [Serializable]
    public struct ZoomSettings
    {
        [SerializeField] private float _factor;
        [SerializeField] private float _speed;

        public float Factor => _factor;
        
        public float Speed => _speed;

        public ZoomSettings(float factor, float speed)
        {
            _factor = factor;
            _speed = speed;
        }
    }
}