using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Acceleration.Abstract;
using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Acceleration.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Friction.Abstract;
using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Friction.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Terrestrial.WalkingAndRunning.Abstract;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Types.Terrestrial.WalkingAndRunning.Impl
{
    /// <summary>
    /// Quake 3 ground velocity calculator.
    /// </summary>
    public class Q3GroundLocomotion : GroundLocomotionType
    {
        private readonly IMovementSettings _settings;
        private readonly Accelerator _accelerator;
        private readonly FrictionCalculator _friction;

        public override Vector3 CalculateVelocity(IMotionInputData inputData, PawnFlags status)
        {
            var velocity = _friction.CalculateFriction(inputData.Velocity, status.HasFlag(PawnFlags.Grounded));

            var wishDirection = inputData.TransformedDirection;
            wishDirection.Normalize();

            var wishSpeed = wishDirection.magnitude * _settings.MaxSpeed;

            velocity = _accelerator.Accelerate(
                new AccelerationParams(velocity, wishDirection, wishSpeed, _settings.Acceleration));

            return velocity;
        }

        public Q3GroundLocomotion(IMovementSettings settings, float friction, float timeStep)
        {
            _settings = settings;

            _friction = new Q3Friction(friction, settings.Deceleration, timeStep);
            _accelerator = new Q2Acceleration(timeStep);
        }
    }
}