using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Terrestrial.Jumping.Abstract;
using Depra.Pawn.Runtime.Locomotion.Modifications.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Impl
{
    public class JumpMotionModification : ILocomotionModification
    {
        private readonly JumpType _jumper;
        
        public Vector3 Modify(ILocomotionContext context)
        {
            var velocity = _jumper.Jump(context.CurrentVelocity);
            return velocity;
        }

        public JumpMotionModification(JumpType jump)
        {
            _jumper = jump;
        }
    }
}