using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Terrestrial.Jumping.Abstract;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using Depra.Pawn.Runtime.StateMachine.States.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States
{
    public class JumpingState : PawnState
    {
        private readonly JumpType _jumpType;
        private readonly IPawnMotor _motor;

        public override void Tick()
        {
            var motorData = _motor.LastInput;
            motorData.Velocity = _jumpType.Jump(motorData.Velocity);

            _motor.SetGrounded(false);
            _motor.SetVelocity(motorData.Velocity);
        }

        public JumpingState(IPawnMotor motor, JumpType jumpType)
        {
            _motor = motor;
            _jumpType = jumpType;
        }
    }
}