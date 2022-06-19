using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract;
using Depra.Pawn.Runtime.Locomotion.Motor.Abstract;
using Depra.Pawn.Runtime.StateMachine.States.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States
{
    public class SprintingState : MotionState
    {
        public SprintingState(PawnMotor motor, LocomotionType locomotionType) : base(motor, locomotionType)
        {
        }
    }
}