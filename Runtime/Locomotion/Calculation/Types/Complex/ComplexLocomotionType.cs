using System.Linq;
using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Types.Complex
{
    public class ComplexLocomotionType : LocomotionType
    {
        private readonly LocomotionType[] _types;

        internal override bool AvailableFor(PawnFlags status) =>
            _types.Any(style => style.AvailableFor(status));

        public override Vector3 CalculateVelocity(ILocomotionContext context)
        {
            var availableType = _types.FirstOrDefault(style => style.AvailableFor(context.Status));
            var velocity = availableType?.CalculateVelocity(context) ?? context.CurrentVelocity;

            return velocity;
        }

        public ComplexLocomotionType(params LocomotionType[] types)
        {
            _types = types;
        }
    }
}