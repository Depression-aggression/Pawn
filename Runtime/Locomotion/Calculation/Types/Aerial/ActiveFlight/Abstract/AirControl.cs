using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Types.Aerial.ActiveFlight.Abstract
{
    /// <summary>
    /// Air control occurs when the player is in the air, it allows players to move side
    /// to side much faster rather than being 'sluggish' when it comes to cornering.
    /// </summary>
    public abstract class AirControl
    {
        protected float Control { get; }
        
        protected float TimeStep { get; }
        
        public abstract Vector3 ControlVelocity(Vector3 velocity, Vector3 currentDirection, Vector3 wishDirection,
            float targetSpeed);

        protected AirControl(float controlConstant, float timeStep)
        {
            Control = controlConstant;
            TimeStep = timeStep;
        }
    }
}