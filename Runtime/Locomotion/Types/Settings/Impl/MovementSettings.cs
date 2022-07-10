using System;
using Depra.Pawn.Runtime.Locomotion.Types.Settings.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Types.Settings.Impl
{
    [Serializable]
    public struct MovementSettings : ILocomotionTypeSettings
    {
        [Tooltip("Maximum movement speed of the pawn in world units per second")]
        [Min(0f)] [SerializeField] private float _maxSpeed;
        [Min(0f)] [SerializeField] private float _speedMultiplier;
        
        [SerializeField] private float _acceleration;
        [SerializeField] private float _deceleration;

        /// <summary>
        /// Gets the character's maximum movement speed in world units per second.
        /// </summary>
        public float MaxSpeed => _maxSpeed;

        public float SpeedMultiplier => _speedMultiplier;

        public float Acceleration => _acceleration;
        
        public float Deceleration => _deceleration;

        public MovementSettings(float maxSpeed, float acceleration, float deceleration, float speedMultiplier = 1f)
        {
            _maxSpeed = maxSpeed;
            _acceleration = acceleration;
            _deceleration = deceleration;
            _speedMultiplier = speedMultiplier;
        }
    }
}