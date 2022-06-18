using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract
{
    public abstract class LocomotionType
    {
        public abstract Vector3 CalculateVelocity(IMotionInputData inputData, PawnFlags status);
        
        internal abstract bool AvailableFor(PawnFlags status);
    }
}