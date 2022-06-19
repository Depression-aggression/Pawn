using Depra.Pawn.Runtime.Components.GroundCheck.Abstract;
using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract;
using Depra.Pawn.Runtime.Locomotion.Data.Impl;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Motor.Abstract;
using Depra.Pawn.Runtime.ReadInput.Abstract;
using Depra.Pawn.Runtime.StateMachine.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Motor.Impl
{
    public class ConfigurablePawnMotor : PawnMotor
    {
        [SerializeField] private GroundChecker _groundCheck;
        [SerializeField] private MotorInputReader _inputReader;
        [SerializeField] private MotorConfigurator _configurator;

        private LocomotionType _locomotionType;
        private IPawnStateMachine _stateMachine;
        
        public override IPawnLocomotionInput LastInput { get; protected set; }

        private void Awake()
        {
            LastInput = new MotionInputData();
            
            _locomotionType = _configurator.SetupMovement(Time.fixedDeltaTime);
            _stateMachine = _configurator.SetupMotor(this, _locomotionType);
        }

        public override void UpdateManual()
        {
            HandleInput();
        }

        public override void UpdateFixed()
        {
            _stateMachine.Tick();
        }
        
        private void HandleInput()
        {
            LastInput.RawDirection = new Vector3(_inputReader.Horizontal(), 0f, _inputReader.Vertical());
            LastInput.TransformedDirection = TransformDirection(LastInput.RawDirection);

            SetGrounded(_groundCheck.IsGrounded);
        }
    }
}