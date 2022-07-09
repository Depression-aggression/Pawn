using System;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadBobbing.Impl
{
    [Serializable]
    public struct HeadBobSettings
    {
        [SerializeField] private float _defaultHeight;
        [Min(0f)] [SerializeField] private float _amount;
        [Min(0f)] [SerializeField] private float _speed;

        public float DefaultHeight => _defaultHeight;
        
        public float Amount => _amount;
        
        public float Speed => _speed;

        public HeadBobSettings(float defaultHeight, float amount, float speed)
        {
            _defaultHeight = defaultHeight;
            _amount = amount;
            _speed = speed;
        }
    }
}