using System;
using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Gravity.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Contexts.Air.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract;
using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Complex;
using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Terrestrial.Jumping.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Terrestrial.WalkingAndRunning.Impl;
using Depra.Pawn.Runtime.Locomotion.Data.Impl;
using Depra.Pawn.Runtime.Locomotion.Motor.Abstract;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using Depra.Pawn.Runtime.Modules.ReadInput.Abstract;
using Depra.Pawn.Runtime.StateMachine.Impl;
using Depra.Pawn.Runtime.StateMachine.Interfaces;
using Depra.Pawn.Runtime.StateMachine.States;
using Depra.Pawn.Runtime.Locomotion.Modifications.Impl;
using JetBrains.Annotations;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Motor.Q3
{
    [CreateAssetMenu(fileName = "Quake 3 Movement", menuName = "Depra/Character/Movement/Quake 3", order = 51)]
    public class Q3MotorConfigurator : MotorConfigurator
    {
        [SerializeField] private MovementSettings _groundMovement = new(7f, 14f, 10f);
        [SerializeField] private MovementSettings _airMovement = new(7f, 2f, 2f);
        [SerializeField] private MovementSettings _strafeMovement = new(1f, 50f, 50f);

        [SerializeField] private Q3JumpSettings _jump = new(8f, true);

        [Min(0f)] [SerializeField] private float _friction = 6f;
        [Min(0f)] [SerializeField] private float _airControl = 0.3f;
        [SerializeField] private float _gravity = 9.81f;

        [SerializeField] private MotorInputReader _inputReader;

        public override LocomotionType SetupMovement(float frameTime)
        {
            var groundMovement = new Q3GroundLocomotion(_groundMovement, _friction, frameTime);
            var airMovement = new Q3AirLocomotion(_airMovement, _strafeMovement, _airControl, frameTime);

            var complexMovement = new ComplexLocomotionType(groundMovement, airMovement);

            return complexMovement;
        }

        public override IPawnStateMachine SetupMotor(IPawnMotor motor, LocomotionType locomotionType)
        {
            var gravityCalculator = new BasicGravityCalculator(_gravity, Time.fixedDeltaTime);
            motor.SetGravitation(gravityCalculator);
            
            var idleState = new IdleState(motor);
            var fallingState = new FallingState(motor);
            
            var sprintingState = new SprintingState(motor, locomotionType);
            var walkingState = new WalkingState(motor, locomotionType);
            var crouchState = new CrouchState(motor, locomotionType);
            
            var jumpType = new Q3Jump(_jump);
            var jumpState = new JumpingState(motor, jumpType);

            var stateMachine = new PawnStateMachine();

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
                var transition = new CharacterStateTransition(to, conditions);
                stateMachine.AddTransition(from, to, transition);
            }

            void AnyAt(IPawnState to, [NotNull] params Func<bool>[] conditions)
            {
                var transition = new CharacterStateTransition(to, conditions);
                stateMachine.AddAnyTransition(to, transition);
            }

            stateMachine.ChangeState(idleState);

            // Conditions:
            Func<bool> Grounded() => () => motor.Status.HasFlag(PawnFlags.Grounded);
            Func<bool> NotGrounded() => () => motor.Status.HasFlag(PawnFlags.Grounded) == false;

            Func<bool> Moving() => () => motor.LastInput.RawDirection != Vector3.zero;
            Func<bool> NotMoving() => () => motor.LastInput.RawDirection == Vector3.zero;

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

            return stateMachine;
        }
    }
}