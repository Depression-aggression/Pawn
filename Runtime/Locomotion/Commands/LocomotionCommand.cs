using Depra.Pawn.Runtime.Commands.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract;
using Depra.Pawn.Runtime.Locomotion.Motor.Abstract;

namespace Depra.Pawn.Runtime.Locomotion.Commands
{
    /// <summary>
    /// Command that moves <see cref="PawnMotor"/> at the specified directional velocity.
    /// </summary>
    public readonly struct LocomotionCommand : IPawnCommand
    {
        private readonly PawnMotor _motor;
        private readonly LocomotionType _locomotionType;

        public void Execute()
        {
            var velocity = _locomotionType.CalculateVelocity(_motor);
            _motor.SetRelativeVelocity(velocity);
        }

        public void Undo()
        {
            var velocity = _locomotionType.CalculateVelocity(_motor);
            _motor.SetRelativeVelocity(-velocity);
        }

        internal LocomotionCommand(PawnMotor motor, LocomotionType locomotionType)
        {
            _motor = motor;
            _locomotionType = locomotionType;
        }
    }
}