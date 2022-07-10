using Depra.Pawn.Runtime.Locomotion.Additional.Friction.Abstract;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Modifications.Types.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Types.Impl
{
    public class FrictionModification : IVelocityModification
    {
        private readonly FrictionCalculator _calculator;
        private readonly ILocomotionStateComponent _stateComponent;
        private readonly IVelocityComponent _velocityComponent;

        public Vector3 Modify(Vector3 velocity)
        {
            var velocityWithFriction =
                _calculator.CalculateFriction(velocity, _stateComponent.Grounded, _velocityComponent.FrameTime);
            
            return velocityWithFriction;
        }

        public FrictionModification(FrictionCalculator calculator, IVelocityComponent actorVelocityComponent,
            ILocomotionStateComponent stateComponent)
        {
            _calculator = calculator;
            _velocityComponent = actorVelocityComponent;
            _stateComponent = stateComponent;
        }
    }
}