using System;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Structs
{
    [Serializable]
    public struct DegreeAxis
    {
        [SerializeField] private float _minAxis;
        [SerializeField] private float _maxAxis;
        [SerializeField] private bool _isClamp;

        private float _current;

        public float Current
        {
            get => _current;
            set => _current = _isClamp ? Mathf.Clamp(value, _minAxis, _maxAxis) : value;
        }

        public DegreeAxis(float minAxis, float maxAxis, bool isClamp)
        {
            _minAxis = minAxis;
            _maxAxis = maxAxis;
            _isClamp = isClamp;

            _current = 0f;
        }

        public Quaternion this[Vector3 axis] => Quaternion.AngleAxis(_current, axis);
    }
}