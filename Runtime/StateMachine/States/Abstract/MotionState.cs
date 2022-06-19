using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract;
using Depra.Pawn.Runtime.Locomotion.Commands;
using Depra.Pawn.Runtime.Locomotion.Motor.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States.Abstract
{
    public abstract class MotionState : PawnState
    {
        private readonly PawnMotor _motor;
        private readonly LocomotionType _locomotionType;

        public override void Tick()
        {
            var command = new LocomotionCommand(_motor, _locomotionType);
            command.Execute();
        }

        protected MotionState(PawnMotor motor, LocomotionType locomotionType)
        {
            _motor = motor;
            _locomotionType = locomotionType;
        }
    }
}