using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Gravity.Abstract;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using JetBrains.Annotations;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Motor.Interfaces
{
    [PublicAPI]
    public interface IPawnMotor
    {
        PawnFlags Status { get; }
        
        IMotionInputData LastInput { get; }
        
        void SetVelocity(Vector3 velocity);

        void SetGrounded(bool grounded);

        void MoveBy(Vector3 velocity);

        void StopImmediately();

        void SetActiveGravity(bool active);

        void ApplyGravity();

        void SetGravitation(GravityCalculator gravityCalculator, bool enable = true);
    }
}