using System;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Types.Terrestrial.Jumping.Impl
{
    [Serializable]
    public struct Q3JumpSettings
    {
        [Tooltip("Initial Y velocity of a Jump in world units per second")]
        [SerializeField] private float _jumpForce;
        [SerializeField] private bool _autoBunnyHop;

        /// <summary>
        /// Gets the character's initial Y velocity of a jump in world units per second
        /// </summary>
        public float JumpForce => _jumpForce;

        public bool AutoBunnyHop => _autoBunnyHop;

        public Q3JumpSettings(float force, bool autoBunnyHop)
        {
            _jumpForce = force;
            _autoBunnyHop = autoBunnyHop;
        }
    }
}