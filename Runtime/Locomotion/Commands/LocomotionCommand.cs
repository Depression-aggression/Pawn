using Depra.Pawn.Runtime.Commands.Interfaces;
using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Commands
{
    /// <summary>
    /// Command that moves <see cref="IPawnMotor"/> at the specified directional velocity.
    /// </summary>
    public readonly struct LocomotionCommand : IPawnCommand
    {
        private readonly IPawnMotor _motor;
        private readonly LocomotionType _locomotionType;

        private readonly PawnFlags _status;
        private readonly IMotionInputData _inputData;

        public void Execute()
        {
            var velocity = _locomotionType.CalculateVelocity(_inputData, _status);
            _motor.SetVelocity(velocity);
        }

        public void Undo()
        {
            var velocity = _locomotionType.CalculateVelocity(_inputData, _status);
            _motor.SetVelocity(-velocity);
        }

        internal LocomotionCommand(IPawnMotor motor, LocomotionType locomotionType)
        {
            _motor = motor;
            _status = _motor.Status;
            _inputData = _motor.LastInput;

            _locomotionType = locomotionType;
        }
    }
}