using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Aerial.ActiveFlight.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Contexts.Air.Impl
{
    /// <summary>
    /// Quake 3 air control.
    /// </summary>
    public class Q3AirControl : AirControl
    {
        private const float Epsilon = 0.001f;

        public override Vector3 ControlVelocity(Vector3 velocity, Vector3 currentDirection, Vector3 wishDirection,
            float targetSpeed)
        {
            if (Control <= 0f)
            {
                return velocity;
            }

            // Only control air movement when moving forward or backward.
            if (Mathf.Abs(currentDirection.z) < Epsilon || Mathf.Abs(targetSpeed) < Epsilon)
            {
                return velocity;
            }

            var zSpeed = velocity.y;
            velocity.y = 0;

            var speed = velocity.magnitude;
            velocity.Normalize();

            var dot = Vector3.Dot(velocity, wishDirection);
            var k = 32.0f;
            k *= Control * dot * dot * TimeStep;

            // Change direction while slowing down.
            if (dot > 0)
            {
                velocity.x *= speed + wishDirection.x * k;
                velocity.y *= speed + wishDirection.y * k;
                velocity.z *= speed + wishDirection.z * k;

                velocity.Normalize();
            }

            velocity.x *= speed;
            velocity.y = zSpeed;
            velocity.z *= speed;

            return velocity;
        }

        public Q3AirControl(float controlConstant, float timeStep) : base(controlConstant, timeStep)
        {
        }
    }
}