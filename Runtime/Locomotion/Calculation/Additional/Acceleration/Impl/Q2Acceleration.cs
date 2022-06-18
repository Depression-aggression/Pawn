using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Acceleration.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Acceleration.Impl
{
    /// <summary>
    /// Quake 2 style.
    /// </summary>
    public class Q2Acceleration : Accelerator
    {
        public override Vector3 Accelerate(AccelerationParams parameters)
        {
            var velocity = parameters.PreviousVelocity;

            var currentSpeed = Vector3.Dot(velocity, parameters.DesiredDirection);
            var addSpeed = parameters.DesiredSpeed - currentSpeed;

            if (addSpeed <= 0)
            {
                return velocity;
            }

            var acceleratedSpeed = parameters.Acceleration * parameters.DesiredSpeed * FrameTime;

            if (acceleratedSpeed > addSpeed)
            {
                acceleratedSpeed = addSpeed;
            }

            velocity.x += acceleratedSpeed * parameters.DesiredDirection.x;
            velocity.z += acceleratedSpeed * parameters.DesiredDirection.z;

            return velocity;
        }

        public Q2Acceleration(float frameTime) : base(frameTime)
        {
        }
    }
}