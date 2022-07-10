using Depra.Pawn.Runtime.Locomotion.Additional.VelocityLimit;
using Depra.Pawn.Runtime.Locomotion.Modifications.Types.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Types.Impl
{
    public class ClipVelocityModification : IVelocityModification
    {
        private readonly VelocityLimiter _limiter;

        public Vector3 Modify(Vector3 velocity)
        {
            var clippedVelocity = _limiter.ClipVelocity(velocity);
            return clippedVelocity;
        }
        
        public ClipVelocityModification(VelocityLimiter limiter)
        {
            _limiter = limiter;
        }
    }
}