using System;
using Depra.Pawn.Runtime.Common;
using Depra.Pawn.Runtime.Extensions.GroundCheck.Abstract;
using Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Impl;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Configuration.Abstract;
using Depra.Pawn.Runtime.Locomotion.Motor.Abstract;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Systems.Impl;
using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Targets.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Types.Abstract;
using Depra.Pawn.Runtime.Locomotion.Types.Aerial.ActiveFlight.Impl;
using Depra.Pawn.Runtime.Locomotion.Types.Complex;
using Depra.Pawn.Runtime.Locomotion.Types.Settings.Impl;
using Depra.Pawn.Runtime.Locomotion.Types.Terrestrial.Jumping.Impl;
using Depra.Pawn.Runtime.Locomotion.Types.Terrestrial.WalkingAndRunning.Impl;
using Depra.Pawn.Runtime.ReadInput.Abstract;
using Depra.Pawn.Runtime.StateMachine.Impl;
using Depra.Pawn.Runtime.StateMachine.Interfaces;
using Depra.Pawn.Runtime.StateMachine.States;
using JetBrains.Annotations;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Q3.Configuration
{
    [CreateAssetMenu(fileName = "Quake 3 Locomotion",
        menuName = Constants.FrameworkPath + Constants.ModulePath + "Locomotion/Quake 3", order = 51)]
    public class Q3LocomotionConfigurationScriptable : LocomotionConfigurationScriptable
    {
        [SerializeField] private MovementSettings _groundMovement = new(7f, 14f, 10f);
        [SerializeField] private MovementSettings _airMovement = new(7f, 2f, 2f);
        [SerializeField] private MovementSettings _strafeMovement = new(1f, 50f, 50f);

        [SerializeField] private Q3JumpSettings _jump = new(8f, true);

        [Min(0f)] [SerializeField] private float _friction = 6f;
        [Min(0f)] [SerializeField] private float _airControl = 0.3f;
        [SerializeField] private float _gravity = 9.81f;

        [SerializeField] private LocomotionInputReader _inputReader;

        private GravityComponent _gravityComponent;
        private VelocityComponent _velocityComponent;
        private LocomotionStateComponent _stateComponent;
        private LocomotionInputComponent _inputComponent;

        public override void ConfigureLayer(ILocomotionLayer layer)
        {
            ConfigureComponents();

            var inputSystem = GetInputProcessingSystem(layer.DirectionTransformer);
            var stateProcessingSystem = GetStateProcessingSystem();

            var gravityCalculationSystem = new GravityCalculationSystem();
            var gravitySource = new DirectionalGravitySource(_gravity, Vector3.down);
            gravityCalculationSystem.AddComponent(_gravityComponent, gravitySource);

            var gravityCorrectionSystem = new GravityCorrectionAccordStateSystem();
            gravityCorrectionSystem.AddComponent(_gravityComponent, _stateComponent);

            var gravityApplicationSystem = new GravityApplicationSystem();
            gravityApplicationSystem.Add(_gravityComponent, _velocityComponent, _stateComponent);

            var velocityApplicationSystem = new VelocityApplicationSystem();
            velocityApplicationSystem.AddComponent(_velocityComponent, layer.VelocityReceivers);

            layer.AddSystem(inputSystem);
            layer.AddPhysicsSystem(stateProcessingSystem);
            layer.AddPhysicsSystem(gravityCalculationSystem);
            layer.AddPhysicsSystem(gravityCorrectionSystem);
            layer.AddPhysicsSystem(gravityApplicationSystem);
            layer.AddPhysicsSystem(velocityApplicationSystem);
        }

        public override void ConfigureLayerExtensions(PawnMotorBase monoLayer)
        {
            if (monoLayer.TryGetComponent(out GroundChecker groundChecker) == false)
            {
                throw new NullReferenceException("Ground checker not found!");
            }

            var groundCheckSystem = new GroundCheckSystem();
            groundCheckSystem.AddComponent(_stateComponent, groundChecker);

            monoLayer.AddPhysicsSystem(groundCheckSystem);
        }

        private void ConfigureComponents()
        {
            _gravityComponent = new GravityComponent();
            _velocityComponent = new VelocityComponent();
            _stateComponent = new LocomotionStateComponent();
            _inputComponent = new LocomotionInputComponent();
        }

        private ILocomotionSystem GetInputProcessingSystem(IDirectionTransformer directionTransformer)
        {
            var inputSystem = new PlayerLocomotionInputSystem(_inputComponent, _inputReader, directionTransformer);
            return inputSystem;
        }

        private ILocomotionSystem GetStateProcessingSystem()
        {
            var stateMachine = new PawnStateMachine();
            var stateProcessingSystem = new StateMachineBasedLocomotionStateProcessingSystem(stateMachine);
            var locomotionType = GetLocomotionType(_inputComponent, _stateComponent);

            var idleState = new IdleState(_velocityComponent);
            var fallingState = new FallingState(_velocityComponent);

            var speedMultiplier = _groundMovement.SpeedMultiplier;
            var sprintingState = new SprintingState(_velocityComponent, locomotionType, speedMultiplier);
            var walkingState = new WalkingState(_velocityComponent, locomotionType, speedMultiplier);
            var crouchState = new CrouchState(_velocityComponent, locomotionType, speedMultiplier);

            var jumpType = new Q3GroundJump(_jump);
            var jumpState = new JumpingState(_velocityComponent, _stateComponent, jumpType);

            AnyAt(jumpState, CanJump());
            At(idleState, jumpState, CantJump());

            At(fallingState, idleState, Falling());
            At(idleState, fallingState, Idle());

            At(idleState, walkingState, Idle());
            At(idleState, sprintingState, Idle());
            At(idleState, crouchState, CantCrouch());

            At(sprintingState, idleState, Moving());
            At(sprintingState, fallingState, Moving());

            At(walkingState, fallingState, CanWalk());
            At(walkingState, idleState, CanWalk());
            At(walkingState, sprintingState, CanWalk());

            At(crouchState, idleState, CrouchButtonPressed());

            void At(IPawnState to, IPawnState from, [NotNull] params Func<bool>[] conditions)
            {
                var transition = new PawnStateTransition(to, conditions);
                stateMachine.AddTransition(from, to, transition);
            }

            void AnyAt(IPawnState to, [NotNull] params Func<bool>[] conditions)
            {
                var transition = new PawnStateTransition(to, conditions);
                stateMachine.AddAnyTransition(to, transition);
            }

            stateMachine.ChangeState(idleState);

            // Conditions:
            Func<bool> Grounded() => () => _stateComponent.Grounded;
            Func<bool> NotGrounded() => () => _stateComponent.Grounded == false;

            Func<bool> Moving() => () => _inputComponent.RawDirection != Vector3.zero;
            Func<bool> NotMoving() => () => _inputComponent.RawDirection == Vector3.zero;

            Func<bool> JumpButtonPressed() => () => _inputReader.IsJumpPressed();
            Func<bool> WalkButtonPressed() => () => _inputReader.IsWalkPressed();
            Func<bool> CrouchButtonPressed() => () => _inputReader.IsCrouchPressed();

            Func<bool> WalkButtonNonPressed() => () => _inputReader.IsWalkPressed() == false;
            Func<bool> CrouchButtonNonPressed() => () => _inputReader.IsCrouchPressed() == false;

            // Composite conditions:
            Func<bool> Idle() => () => Grounded().Invoke() && NotMoving().Invoke();
            Func<bool> Falling() => () => NotGrounded().Invoke() && NotMoving().Invoke();

            Func<bool> CanJump() => () => Grounded().Invoke() && JumpButtonPressed().Invoke();
            Func<bool> CanWalk() => () => Moving().Invoke() && WalkButtonPressed().Invoke();

            Func<bool> CantJump() => () => Grounded().Invoke() == false || JumpButtonPressed().Invoke() == false;
            Func<bool> CantWalk() => () => WalkButtonNonPressed().Invoke() && Moving().Invoke();
            Func<bool> CantCrouch() => () => CrouchButtonNonPressed().Invoke() && NotMoving().Invoke();

            return stateProcessingSystem;
        }

        private LocomotionType GetLocomotionType(ILocomotionInputComponent input, ILocomotionStateComponent state)
        {
            var groundMovement =
                new Q3GroundLocomotion(input, state, _groundMovement, _friction);
            var airMovement = new Q3AirLocomotion(input, _airMovement, _strafeMovement, _airControl);

            var complexMovement = new ComplexLocomotionType(state, groundMovement, airMovement);

            return complexMovement;
        }
    }
}