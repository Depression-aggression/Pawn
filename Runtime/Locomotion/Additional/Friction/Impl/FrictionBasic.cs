using Depra.Pawn.Runtime.Locomotion.Additional.Friction.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.Friction.Impl
{
    public class FrictionBasic : FrictionCalculator
    {
        public override Vector3 CalculateFriction(Vector3 previousVelocity, bool isGrounded, float frameTime)
        {
            if (isGrounded == false)
            {
                return previousVelocity;
            }

            var speed = previousVelocity.magnitude;
            if (speed <= 0)
            {
                return previousVelocity;
            }

            var friction = FrictionByFrameTime(frameTime);
            var drop = speed * friction;
            var velocity = previousVelocity * Mathf.Max(speed - drop, 0) / speed;

            return velocity;
        }

        public FrictionBasic(float frictionConstant) : base(frictionConstant)
        {
        }
    }
}