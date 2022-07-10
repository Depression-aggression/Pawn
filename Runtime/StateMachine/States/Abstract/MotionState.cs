using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Types.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States.Abstract
{
    public abstract class MotionState : PawnState
    {
        private readonly float _speedMultiplier;
        private readonly LocomotionType _locomotionType;
        private readonly VelocityComponent _locomotionComponent;

        public override void Tick()
        {
            var velocity = _locomotionType.CalculateVelocity(_locomotionComponent);
            velocity *= _speedMultiplier;

            _locomotionComponent.TargetVelocity = velocity;
        }

        protected MotionState(VelocityComponent component, LocomotionType locomotionType,
            float speedMultiplier)
        {
            _locomotionComponent = component;
            _locomotionType = locomotionType;
            _speedMultiplier = speedMultiplier;
        }
    }
}