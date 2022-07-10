using Depra.Pawn.Runtime.Locomotion.Additional.Acceleration.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.Acceleration.Impl
{
    /// <summary>
    /// Quake 2 style.
    /// </summary>
    public class Q2Acceleration : Accelerator
    {
        public override Vector3 Accelerate(Arguments arguments)
        {
            var velocity = arguments.PreviousVelocity;

            var currentSpeed = Vector3.Dot(velocity, arguments.DesiredDirection);
            var addSpeed = arguments.DesiredSpeed - currentSpeed;

            if (addSpeed <= 0)
            {
                return velocity;
            }

            var acceleratedSpeed = arguments.Acceleration * arguments.DesiredSpeed * arguments.FrameTime;

            if (acceleratedSpeed > addSpeed)
            {
                acceleratedSpeed = addSpeed;
            }

            velocity.x += acceleratedSpeed * arguments.DesiredDirection.x;
            velocity.z += acceleratedSpeed * arguments.DesiredDirection.z;

            return velocity;
        }
    }
}