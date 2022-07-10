using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Systems.Abstract;
using Depra.Pawn.Runtime.StateMachine.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Systems.Impl
{
    public class StateMachineBasedLocomotionStateProcessingSystem : LocomotionStateProcessingSystem
    {
        private readonly IPawnStateMachine _stateMachine;

        public override void OnUpdate(float frameTime) => _stateMachine.Tick();

        public StateMachineBasedLocomotionStateProcessingSystem(IPawnStateMachine stateMachine,
            ILocomotionStateComponent initialState = null) : base(initialState ?? new LocomotionStateComponent())
        {
            _stateMachine = stateMachine;
        }
    }
}