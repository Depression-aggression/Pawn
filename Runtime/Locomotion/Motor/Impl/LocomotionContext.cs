using System;
using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Motor.Impl
{
    [Serializable]
    public struct LocomotionContext : ILocomotionContext
    {
        public Vector3 CurrentVelocity { get; }

        public PawnFlags Status { get; }

        public IPawnLocomotionInput LastInput { get; }

        public LocomotionContext(Vector3 velocity, PawnFlags status, IPawnLocomotionInput input)
        {
            CurrentVelocity = velocity;
            Status = status;
            LastInput = input;
        }

        public LocomotionContext(ILocomotionContext otherContext) : this(otherContext.CurrentVelocity,
            otherContext.Status, otherContext.LastInput)
        {
        }
    }
}