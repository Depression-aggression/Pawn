using System.Linq;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Types.Complex
{
    public class ComplexLocomotionType : LocomotionType
    {
        private readonly LocomotionType[] _types;
        private readonly ILocomotionStateComponent _stateComponent;

        internal override bool AvailableFor(ILocomotionStateComponent state) =>
            _types.Any(style => style.AvailableFor(state));

        public override Vector3 CalculateVelocity(IVelocityComponent context)
        {
            var availableType = _types.FirstOrDefault(style => style.AvailableFor(_stateComponent));
            var velocity = availableType?.CalculateVelocity(context) ?? context.CurrentVelocity;

            return velocity;
        }

        public ComplexLocomotionType(ILocomotionStateComponent stateComponent, params LocomotionType[] types)
        {
            _types = types;
            _stateComponent = stateComponent;
        }
    }
}