using Depra.Pawn.Runtime.Locomotion.Additional.Friction.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.Friction.Impl
{
    /// <summary>
    /// Quake 3 style.
    /// </summary>
    public class Q3Friction : FrictionCalculator
    {
        private readonly float _deceleration;
        
        public override Vector3 CalculateFriction(Vector3 previousVelocity, bool isGrounded, float frameTime)
        {
            var vector = previousVelocity;
            vector.y = 0.0f;

            var speed = vector.magnitude;
            var drop = 0.0f;

            if (isGrounded)
            {
                var control = speed < _deceleration ? _deceleration : speed;
                drop = control * FrictionByFrameTime(frameTime);
            }

            var newSpeed = speed - drop;

            if (newSpeed < 0)
            {
                newSpeed = 0;
            }

            if (speed > 0)
            {
                newSpeed /= speed;
            }

            previousVelocity.x *= newSpeed;
            previousVelocity.z *= newSpeed;

            return previousVelocity;
        }
        
        public Q3Friction(float frictionConstant, float deceleration) : base(frictionConstant)
        {
            _deceleration = deceleration;
        }
    }
}