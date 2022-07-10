using Depra.Pawn.Runtime.Locomotion.Components;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Types.Abstract;
using Depra.Pawn.Runtime.StateMachine.States.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States
{
    public class SprintingState : MotionState
    {
        public SprintingState(VelocityComponent component, LocomotionType locomotionType,
            float speedMultiplier) : base(component, locomotionType, speedMultiplier)
        {
        }
    }
}