using Depra.Pawn.Runtime.Locomotion.Additional.Acceleration.Impl;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.Acceleration.Abstract
{
    /// <summary>
    /// Handles user intended acceleration.
    /// </summary>
    public abstract class Accelerator
    {
        public readonly struct Arguments
        {
            public Vector3 PreviousVelocity { get; }
            
            public Vector3 DesiredDirection { get; }
            
            public float DesiredSpeed { get; }
        
            public float Acceleration { get; }
        
            public float FrameTime { get; }

            public Arguments(Vector3 previousVelocity, Vector3 desiredDirection, float desiredSpeed,
                float acceleration, float frameTime)
            {
                PreviousVelocity = previousVelocity;
                DesiredDirection = desiredDirection;
                DesiredSpeed = desiredSpeed;
                Acceleration = acceleration;
                FrameTime = frameTime;
            }
        }
        
        /// <summary>
        /// Calculates acceleration based on desired speed and direction.
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public abstract Vector3 Accelerate(Arguments arguments);
    }
}