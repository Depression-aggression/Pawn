using Depra.Pawn.Runtime.Locomotion.Types.Terrestrial.Jumping.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Types.Terrestrial.Jumping.Impl
{
    /// <summary>
    /// Quake 3 style.
    /// </summary>
    public class Q3GroundJump : GroundJumpType
    {
        private readonly bool _autoBunnyHop;
        private bool _jumping;

        public override bool Jumping => _jumping;

        public override Vector3 Jump(Vector3 velocity)
        {
            velocity.y = JumpForce;

            if (_autoBunnyHop == false)
            {
                _jumping = false;
            }

            return velocity;
        }

        public Q3GroundJump(float force, bool autoBunnyHop = true) : base(force)
        {
            _autoBunnyHop = autoBunnyHop;
        }

        public Q3GroundJump(Q3JumpSettings settings) : base(settings.JumpForce)
        {
            _autoBunnyHop = settings.AutoBunnyHop;
        }
    }
}