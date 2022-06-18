using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using Depra.Pawn.Runtime.StateMachine.States.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States
{
    public class FallingState : PawnState
    {
        private readonly IPawnMotor _motor;
        
        public override void Tick()
        {
            var velocity = _motor.LastInput.Velocity;
            _motor.SetVelocity(velocity);
        }

        public FallingState(IPawnMotor motor)
        {
            _motor = motor;
        }
    }
}