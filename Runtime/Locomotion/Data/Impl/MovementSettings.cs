using System;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Data.Impl
{
    [Serializable]
    public class MovementSettings : IMovementSettings
    {
        [Tooltip("Maximum movement speed of the pawn in world units per second")]
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _deceleration;

        /// <summary>
        /// Gets the character's maximum movement speed in world units per second.
        /// </summary>
        public float MaxSpeed => _maxSpeed;
        public float Acceleration => _acceleration;
        public float Deceleration => _deceleration;

        public MovementSettings(float maxSpeed, float acceleration, float deceleration)
        {
            _maxSpeed = maxSpeed;
            _acceleration = acceleration;
            _deceleration = deceleration;
        }
    }
}