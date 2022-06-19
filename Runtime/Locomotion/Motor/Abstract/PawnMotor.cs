using System;
using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Gravity.Abstract;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Targets.Abstract;
using Depra.Pawn.Runtime.UpdateMethod.Abstract;
using JetBrains.Annotations;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Motor.Abstract
{
    public abstract class PawnMotor : UpdatablePawnBehavior, ILocomotionContext, IDirectionTransformer
    {
        [SerializeField] private Transform _origin;
        [SerializeField] private VelocityReceiver _target;

        public Vector3 CurrentVelocity { get; private set; }

        [PublicAPI] public float CurrentSpeed => CurrentVelocity.magnitude;

        public bool GravityEnabled { get; private set; }

        public abstract IPawnLocomotionInput LastInput { get; protected set; }

        public PawnFlags Status { get; private set; }

        protected GravityCalculator GravityCalculator { get; set; }

        public event Action<ILocomotionContext> Updated;
        public event Action<Vector3> SpeedChanged;

        public void SetRelativeVelocity(Vector3 velocity)
        {
            CurrentVelocity = velocity;

            if (GravityEnabled)
            {
                ApplyGravity();
            }

            Updated?.Invoke(this);
            SpeedChanged?.Invoke(velocity);

            MoveBy(CurrentVelocity);
        }

        public void MoveBy(Vector3 velocity)
        {
            _target.SetVelocity(velocity);
        }

        public void StopImmediately()
        {
            SetRelativeVelocity(Vector3.zero);
        }

        public void SetActiveGravity(bool active)
        {
            GravityEnabled = active;
        }

        public void SetGravitation(GravityCalculator gravityCalculator, bool enable = true)
        {
            GravityCalculator = gravityCalculator;
            SetActiveGravity(enable);
        }

        public void ApplyGravity()
        {
            CurrentVelocity = Status.HasFlag(PawnFlags.Grounded)
                ? GravityCalculator.SetGroundedGravity(CurrentVelocity)
                : GravityCalculator.ApplyGravity(CurrentVelocity);
        }

        public void SetGrounded(bool grounded)
        {
            if (grounded)
            {
                Status |= PawnFlags.Grounded;
            }
            else
            {
                Status &= ~PawnFlags.Grounded;
            }
        }

        public Vector3 TransformDirection(Vector3 direction) => _origin.TransformDirection(direction);
    }
}