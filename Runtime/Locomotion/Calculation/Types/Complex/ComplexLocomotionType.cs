using System.Linq;
using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Types.Complex
{
    public class ComplexLocomotionType : LocomotionType
    {
        private readonly LocomotionType[] _types;

        internal override bool AvailableFor(PawnFlags status) =>
            _types.Any(style => style.AvailableFor(status));

        public override Vector3 CalculateVelocity(IMotionInputData inputData, PawnFlags status)
        {
            var availableType = _types.FirstOrDefault(style => style.AvailableFor(status));
            var velocity = availableType?.CalculateVelocity(inputData, status) ?? inputData.Velocity;

            return velocity;
        }

        public ComplexLocomotionType(params LocomotionType[] types)
        {
            _types = types;
        }
    }
}