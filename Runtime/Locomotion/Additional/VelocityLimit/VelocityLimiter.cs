using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.VelocityLimit
{
    public class VelocityLimiter
    {
        private readonly float _maxVelocity;

        public Vector3 ClipVelocity(Vector3 previousVelocity)
        {
            var clippedVelocity = Vector3.ClampMagnitude(previousVelocity, _maxVelocity);
            return clippedVelocity;
        }

        public VelocityLimiter(float maxVelocity)
        {
            _maxVelocity = maxVelocity;
        }
    }
}