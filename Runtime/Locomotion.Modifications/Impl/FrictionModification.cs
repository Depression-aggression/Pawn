using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Friction.Abstract;
using Depra.Pawn.Runtime.Locomotion.Modifications.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Impl
{
    public class FrictionModification : ILocomotionModification
    {
        private readonly FrictionCalculator _calculator;

        public Vector3 Modify(ILocomotionContext context)
        {
            var velocity =
                _calculator.CalculateFriction(context.CurrentVelocity, context.Status.HasFlag(PawnFlags.Grounded));

            return velocity;
        }

        public FrictionModification(FrictionCalculator calculator)
        {
            _calculator = calculator;
        }
    }
}