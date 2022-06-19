using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.VelocityLimit;
using Depra.Pawn.Runtime.Locomotion.Modifications.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Impl
{
    public class ClipVelocityModification : ILocomotionModification
    {
        private readonly VelocityLimiter _limiter;

        public Vector3 Modify(ILocomotionContext context)
        {
            var velocity = _limiter.ClipVelocity(context.CurrentVelocity);
            return velocity;
        }
        
        public ClipVelocityModification(VelocityLimiter limiter)
        {
            _limiter = limiter;
        }
    }
}