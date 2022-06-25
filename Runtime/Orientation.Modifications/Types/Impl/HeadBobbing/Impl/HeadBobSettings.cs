using System;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadBobbing.Impl
{
    [Serializable]
    public struct HeadBobSettings
    {
        [Min(0f)] [SerializeField] private float _amount;
        [Min(0f)] [SerializeField] private float _speed;

        public float Amount => _amount;
        
        public float Speed => _speed;

        public HeadBobSettings(float amount, float speed)
        {
            _amount = amount;
            _speed = speed;
        }
    }
}