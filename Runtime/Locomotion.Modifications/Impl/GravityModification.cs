using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Gravity.Abstract;
using Depra.Pawn.Runtime.Locomotion.Modifications.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Impl
{
    public class GravityModification : ILocomotionModification
    {
        private readonly GravityCalculator _calculator;

        public Vector3 Modify(ILocomotionContext context)
        {
            var velocity = context.Status.HasFlag(PawnFlags.Grounded)
                ? _calculator.SetGroundedGravity(context.CurrentVelocity)
                : _calculator.ApplyGravity(context.CurrentVelocity);

            return velocity;
        }

        public GravityModification(GravityCalculator calculator)
        {
            _calculator = calculator;
        }
    }
}