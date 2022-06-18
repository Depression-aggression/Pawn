using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Acceleration.Abstract;
using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Acceleration.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Aerial.ActiveFlight.Abstract;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Contexts.Air.Impl
{
    /// <summary>
    /// Quake 3 movement.
    /// </summary>
    public class Q3AirLocomotion : AirLocomotion
    {
        private readonly IMovementSettings _movementSettings;
        private readonly IMovementSettings _strafeSettings;

        private readonly AirControl _control;
        private readonly Accelerator _accelerator;
        
        public override Vector3 CalculateVelocity(IMotionInputData inputData, PawnFlags status)
        {
            var velocity = inputData.Velocity;
            var directionInput = inputData.RawDirection;

            var wishDirection = inputData.TransformedDirection;
            var wishSpeed = wishDirection.magnitude * _movementSettings.MaxSpeed;

            wishDirection.Normalize();

            var acceleration = Vector3.Dot(velocity, wishDirection) < 0
                ? _movementSettings.Deceleration
                : _movementSettings.Acceleration;

            // If the player is ONLY strafing left or right.
            if (directionInput.z == 0 && directionInput.x != 0)
            {
                wishSpeed = Mathf.Max(wishSpeed, _strafeSettings.MaxSpeed);
                acceleration = _strafeSettings.Acceleration;
            }

            var accelerationParams =
                new AccelerationParams(velocity, wishDirection, wishSpeed, acceleration);
            velocity = _accelerator.Accelerate(accelerationParams);

            if (_control != null)
            {
                velocity = _control.ControlVelocity(velocity, directionInput, wishDirection, wishSpeed);
            }

            return velocity;
        }
        
        public Q3AirLocomotion(IMovementSettings settings, IMovementSettings strafeSettings, float airControl, float timeStep)
        {
            _movementSettings = settings;
            _strafeSettings = strafeSettings;

            _control = new Q3AirControl(airControl, timeStep);
            _accelerator = new Q2Acceleration(timeStep);
        }
    }
}