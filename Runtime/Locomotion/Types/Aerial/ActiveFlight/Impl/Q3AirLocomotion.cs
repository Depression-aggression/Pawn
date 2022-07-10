using Depra.Pawn.Runtime.Locomotion.Additional.Acceleration.Abstract;
using Depra.Pawn.Runtime.Locomotion.Additional.Acceleration.Impl;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Types.Aerial.ActiveFlight.Abstract;
using Depra.Pawn.Runtime.Locomotion.Types.Settings.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Types.Aerial.ActiveFlight.Impl
{
    /// <summary>
    /// Quake 3 movement.
    /// </summary>
    public class Q3AirLocomotion : AirLocomotion
    {
        private readonly ILocomotionTypeSettings _movementSettings;
        private readonly ILocomotionTypeSettings _strafeSettings;
        private readonly ILocomotionInputComponent _inputComponent;

        private readonly AirControl _control;
        private readonly Accelerator _accelerator;

        public override Vector3 CalculateVelocity(IVelocityComponent context)
        {
            var velocity = context.CurrentVelocity;
            var directionInput = _inputComponent.RawDirection;

            var wishDirection = _inputComponent.TransformedDirection;
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

            velocity = ApplyAcceleration(
                new Accelerator.Arguments(velocity, wishDirection, wishSpeed, acceleration, context.FrameTime));

            velocity = ApplyAirControl(
                new AirControl.Arguments(velocity, directionInput, wishDirection, wishSpeed, context.FrameTime));

            return velocity;
        }

        public Q3AirLocomotion(ILocomotionInputComponent inputComponent, ILocomotionTypeSettings settings,
            ILocomotionTypeSettings strafeSettings, float airControl)
        {
            _inputComponent = inputComponent;
            _movementSettings = settings;
            _strafeSettings = strafeSettings;

            _control = new Q3AirControl(airControl);
            _accelerator = new Q2Acceleration();
        }
        
        private Vector3 ApplyAcceleration(Accelerator.Arguments args)
        {
            var velocity = _accelerator.Accelerate(args);
            return velocity;
        }

        private Vector3 ApplyAirControl(AirControl.Arguments args)
        {
            var velocity = _control.ControlVelocity(args);
            return velocity;
        }
    }
}