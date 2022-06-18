using System;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Types.Terrestrial.Jumping.Impl
{
    [Serializable]
    public struct Q3JumpSettings
    {
        [SerializeField] private float _jumpForce;
        [SerializeField] private bool _autoBunnyHop;

        public float JumpForce => _jumpForce;

        public bool AutoBunnyHop => _autoBunnyHop;

        public Q3JumpSettings(float force, bool autoBunnyHop)
        {
            _jumpForce = force;
            _autoBunnyHop = autoBunnyHop;
        }
    }
}