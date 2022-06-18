using Depra.Pawn.Runtime.Control.Impl;
using Depra.Pawn.Runtime.Locomotion.Calculation.Types.Abstract;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Types.Aerial.ActiveFlight.Abstract
{
    public abstract class AirLocomotion : LocomotionType
    {
        internal override bool AvailableFor(PawnFlags status) => status.HasFlag(PawnFlags.Grounded) == false;
    }
}