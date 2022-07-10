using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Types.Aerial.ActiveFlight.Abstract
{
    /// <summary>
    /// Air control occurs when the player is in the air, it allows players to move side
    /// to side much faster rather than being 'sluggish' when it comes to cornering.
    /// </summary>
    public abstract class AirControl
    {
        public readonly struct Arguments
        {
            public Vector3 Velocity { get; }
            
            public Vector3 CurrentDirection { get; }
            
            public Vector3 WishDirection { get; }

            public float TargetSpeed { get; }
            
            public float FrameTime { get; }

            public Arguments(Vector3 velocity, Vector3 currentDirection, Vector3 wishDirection, float targetSpeed,
                float frameTime)
            {
                Velocity = velocity;
                CurrentDirection = currentDirection;
                WishDirection = wishDirection;
                TargetSpeed = targetSpeed;
                FrameTime = frameTime;
            }

            public void Deconstruct(out Vector3 velocity, out Vector3 currentDirection, out Vector3 wishDirection, out float targetSpeed, out float frameTime)
            {
                velocity = Velocity;
                currentDirection = CurrentDirection;
                wishDirection = WishDirection;
                targetSpeed = TargetSpeed;
                frameTime = FrameTime;
            }
        }
        
        protected float Control { get; }
        
        public abstract Vector3 ControlVelocity(Arguments args);

        protected AirControl(float controlConstant)
        {
            Control = controlConstant;
        }
    }
}