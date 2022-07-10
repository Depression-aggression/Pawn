using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.StateMachine.States.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States
{
    public class IdleState : PawnState
    {
        private readonly VelocityComponent _locomotionComponent;
        
        public override void Enter()
        {
            var velocity = _locomotionComponent.CurrentVelocity;
            velocity.x = 0f;
            velocity.z = 0f;

            _locomotionComponent.TargetVelocity = velocity;
        }

        public override void Tick()
        {
            // Do nothing.
        }

        public IdleState(VelocityComponent locomotionComponent)
        {
            _locomotionComponent = locomotionComponent;
        }
    }
}