using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Types.Terrestrial.WalkingAndRunning.Abstract
{
    public abstract class GroundLocomotionType : LocomotionType
    {
        internal override bool AvailableFor(PawnFlags status) => status.HasFlag(PawnFlags.Grounded);
    }
}