using System;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.HeadTilt.Impl
{
    [Serializable]
    public struct HeadTiltSettings
    {
        [Min(0f)] [SerializeField] private float _maxRotation;
        [Min(0f)] [SerializeField] private float _rate;
        [Min(0f)] [SerializeField] private float _returnRate;

        public float MaxRotation => _maxRotation;
        
        public float Rate => _rate;
        
        public float ReturnRate => _returnRate;

        public HeadTiltSettings(float maxRotation, float rate, float returnRate)
        {
            _maxRotation = maxRotation;
            _rate = rate;
            _returnRate = returnRate;
        }
    }
}