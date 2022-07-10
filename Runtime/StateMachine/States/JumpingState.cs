using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Types.Terrestrial.Jumping.Abstract;
using Depra.Pawn.Runtime.StateMachine.States.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States
{
    public class JumpingState : PawnState
    {
        private readonly GroundJumpType _groundJumpType;
        private readonly LocomotionStateComponent _stateComponent;
        private readonly VelocityComponent _velocityComponent;

        public override void Tick()
        {
            var velocity = _velocityComponent.CurrentVelocity;
            velocity = _groundJumpType.Jump(velocity);

            _stateComponent.Grounded = false;
            _velocityComponent.TargetVelocity = velocity;
        }

        public JumpingState(VelocityComponent velocityComponent, LocomotionStateComponent stateComponent,
            GroundJumpType groundJumpType)
        {
            _groundJumpType = groundJumpType;
            _stateComponent = stateComponent;
            _velocityComponent = velocityComponent;
        }
    }
}