using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Friction.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Friction.Impl
{
    public class FrictionBasic : FrictionCalculator
    {
        public override Vector3 CalculateFriction(Vector3 previousVelocity, bool isGrounded)
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

            var drop = speed * Friction;
            var velocity = previousVelocity * Mathf.Max(speed - drop, 0) / speed;

            return velocity;
        }

        public FrictionBasic(float frictionConstant, float frameTime) : base(frictionConstant, frameTime)
        {
        }
    }
}