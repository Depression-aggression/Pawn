using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Acceleration.Impl
{
    public readonly struct AccelerationParams
    {
        public Vector3 PreviousVelocity { get; }
            
        public Vector3 DesiredDirection { get; }
            
        public float DesiredSpeed { get; }
        
        public float Acceleration { get; }

        public AccelerationParams(Vector3 previousVelocity, Vector3 desiredDirection, float desiredSpeed,
            float acceleration)
        {
            PreviousVelocity = previousVelocity;
            DesiredDirection = desiredDirection;
            DesiredSpeed = desiredSpeed;
            Acceleration = acceleration;
        }
    }
}