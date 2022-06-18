using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract;
using Depra.Pawn.Runtime.Locomotion.Commands;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;

namespace Depra.Pawn.Runtime.StateMachine.States.Abstract
{
    public abstract class MotionState : PawnState
    {
        private readonly IPawnMotor _motor;
        private readonly LocomotionType _locomotionType;

        public override void Tick()
        {
            var command = new LocomotionCommand(_motor, _locomotionType);
            command.Execute();
        }

        protected MotionState(IPawnMotor motor, LocomotionType locomotionType)
        {
            _motor = motor;
            _locomotionType = locomotionType;
        }
    }
}