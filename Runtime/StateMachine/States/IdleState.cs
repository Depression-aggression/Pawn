using Depra.Pawn.Runtime.Locomotion.Motor.Abstract;
using Depra.Pawn.Runtime.StateMachine.States.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States
{
    public class IdleState : PawnState
    {
        private readonly PawnMotor _motor;

        public override void Enter()
        {
            var velocity = _motor.CurrentVelocity;
            velocity.x = 0f;
            velocity.z = 0f;

            _motor.SetRelativeVelocity(velocity);
        }

        public override void Tick()
        {
            // Do nothing.
        }

        public IdleState(PawnMotor motor)
        {
            _motor = motor;
        }
    }
}