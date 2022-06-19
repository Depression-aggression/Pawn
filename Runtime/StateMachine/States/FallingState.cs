using Depra.Pawn.Runtime.Locomotion.Motor.Abstract;
using Depra.Pawn.Runtime.StateMachine.States.Abstract;

namespace Depra.Pawn.Runtime.StateMachine.States
{
    public class FallingState : PawnState
    {
        private readonly PawnMotor _motor;
        
        public override void Tick()
        {
            var velocity = _motor.CurrentVelocity;
            _motor.SetRelativeVelocity(velocity);
        }

        public FallingState(PawnMotor motor)
        {
            _motor = motor;
        }
    }
}