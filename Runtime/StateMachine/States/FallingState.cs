using Depra.Pawn.Runtime.Locomotion.Components;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.StateMachine.States.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States
{
    public class FallingState : PawnState
    {
        private readonly VelocityComponent _locomotionComponent;
        
        public override void Tick()
        {
            var velocity = _locomotionComponent.CurrentVelocity;
            _locomotionComponent.TargetVelocity = velocity;
        }

        public FallingState(VelocityComponent locomotionComponent)
        {
            _locomotionComponent = locomotionComponent;
        }
    }
}