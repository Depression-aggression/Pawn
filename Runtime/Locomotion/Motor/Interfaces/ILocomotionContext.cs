using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using JetBrains.Annotations;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Motor.Interfaces
{
    public interface ILocomotionContext
    {
        Vector3 CurrentVelocity { get; }
        
        PawnFlags Status { get; }
        
        IPawnLocomotionInput LastInput { get; }
    }
}