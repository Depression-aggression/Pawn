using Depra.Pawn.Runtime.Locomotion.Modifications.Types.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Types.Terrestrial.Jumping.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Types.Impl
{
    public class JumpMotionModification : IVelocityModification
    {
        private readonly GroundJumpType _jumper;
        
        public Vector3 Modify(Vector3 velocity)
        {
            var jumpVelocity = _jumper.Jump(velocity);
            return jumpVelocity;
        }

        public JumpMotionModification(GroundJumpType groundJump)
        {
            _jumper = groundJump;
        }
    }
}