using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Terrestrial.Jumping.Abstract;
using Depra.Pawn.Runtime.Locomotion.Motor.Abstract;
using Depra.Pawn.Runtime.StateMachine.States.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States
{
    public class JumpingState : PawnState
    {
        private readonly JumpType _jumpType;
        private readonly PawnMotor _motor;

        public override void Tick()
        {
            var velocity = _motor.CurrentVelocity;
            velocity = _jumpType.Jump(velocity);

            _motor.SetGrounded(false);
            _motor.SetRelativeVelocity(velocity);
        }

        public JumpingState(PawnMotor motor, JumpType jumpType)
        {
            _motor = motor;
            _jumpType = jumpType;
        }
    }
}