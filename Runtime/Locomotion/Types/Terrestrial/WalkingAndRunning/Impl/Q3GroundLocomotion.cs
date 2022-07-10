using Depra.Pawn.Runtime.Locomotion.Additional.Acceleration.Abstract;
using Depra.Pawn.Runtime.Locomotion.Additional.Acceleration.Impl;
using Depra.Pawn.Runtime.Locomotion.Additional.Friction.Abstract;
using Depra.Pawn.Runtime.Locomotion.Additional.Friction.Impl;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Types.Settings.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Types.Terrestrial.WalkingAndRunning.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Types.Terrestrial.WalkingAndRunning.Impl
{
    /// <summary>
    /// Quake 3 ground velocity calculator.
    /// </summary>
    public class Q3GroundLocomotion : GroundLocomotionType
    {
        private readonly Accelerator _accelerator;
        private readonly FrictionCalculator _friction;
        private readonly ILocomotionTypeSettings _settings;

        private readonly ILocomotionStateComponent _stateComponent;
        private readonly ILocomotionInputComponent _inputComponent;

        public override Vector3 CalculateVelocity(IVelocityComponent context)
        {
            var grounded = _stateComponent.Grounded;
            var velocity = _friction.CalculateFriction(context.CurrentVelocity, grounded, context.FrameTime);

            var wishDirection = _inputComponent.TransformedDirection;
            wishDirection.Normalize();

            var wishSpeed = wishDirection.magnitude * _settings.MaxSpeed;

            velocity = ApplyAcceleration(new Accelerator.Arguments(velocity, wishDirection, wishSpeed,
                _settings.Acceleration, context.FrameTime));

            return velocity;
        }

        public Q3GroundLocomotion(ILocomotionInputComponent inputComponent,
            ILocomotionStateComponent stateComponent, ILocomotionTypeSettings settings, float friction)
        {
            _inputComponent = inputComponent;
            _stateComponent = stateComponent;

            _settings = settings;

            _friction = new Q3Friction(friction, settings.Deceleration);
            _accelerator = new Q2Acceleration();
        }

        private Vector3 ApplyAcceleration(Accelerator.Arguments args)
        {
            var acceleratedVelocity = _accelerator.Accelerate(args);
            return acceleratedVelocity;
        }
    }
}