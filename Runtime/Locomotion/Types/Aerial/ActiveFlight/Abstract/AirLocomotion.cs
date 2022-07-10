using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Types.Abstract;

namespace Depra.Pawn.Runtime.Locomotion.Types.Aerial.ActiveFlight.Abstract
{
    public abstract class AirLocomotion : LocomotionType
    {
        internal override bool AvailableFor(ILocomotionStateComponent state) => state.Grounded == false;
    }
}