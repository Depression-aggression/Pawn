using System;
using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Gravity.Abstract;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Targets.Abstract;
using JetBrains.Annotations;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Motor.Abstract
{
    public abstract class PawnMotor : MonoBehaviour, IPawnMotor, IDirectionTransformer
    {
        [SerializeField] private Transform _origin;
        [SerializeField] private VelocityReceiver _target;

        [PublicAPI] public Vector3 CurrentVelocity => LastInput.Velocity;

        [PublicAPI] public float CurrentSpeed => CurrentVelocity.magnitude;

        public bool GravityEnabled { get; private set; }
        
        public abstract IMotionInputData LastInput { get; protected set; }
        public PawnFlags Status { get; private set; }
        
        protected GravityCalculator GravityCalculator { get; set; }

        public event Action<IPawnMotor> Updated;
        public event Action<Vector3> SpeedChanged;

        public void SetVelocity(Vector3 velocity)
        {
            LastInput.Velocity = velocity;

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
            SetVelocity(Vector3.zero);
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
            LastInput.Velocity = Status.HasFlag(PawnFlags.Grounded)
                ? GravityCalculator.SetGroundedGravity(LastInput.Velocity)
                : GravityCalculator.ApplyGravity(LastInput.Velocity);
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