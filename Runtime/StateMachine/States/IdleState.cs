using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using Depra.Pawn.Runtime.StateMachine.States.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States
{
    public class IdleState : PawnState
    {
        private readonly IPawnMotor _motor;

        public override void Enter()
        {
            var velocity = _motor.LastInput.Velocity;
            velocity.x = 0f;
            velocity.z = 0f;

            _motor.SetVelocity(velocity);
        }

        public override void Tick()
        {
            // Do nothing.
        }

        public IdleState(IPawnMotor motor)
        {
            _motor = motor;
        }
    }
}