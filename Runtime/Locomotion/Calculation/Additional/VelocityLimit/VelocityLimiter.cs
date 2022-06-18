using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Additional.VelocityLimit
{
    public class VelocityLimiter
    {
        private readonly float _maxVelocity;

        public Vector3 ClipVelocity(Vector3 previousVelocity)
        {
            return Vector3.ClampMagnitude(previousVelocity, _maxVelocity);
        }

        public VelocityLimiter(float maxVelocity)
        {
            _maxVelocity = maxVelocity;
        }
    }
}