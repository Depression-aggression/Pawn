using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Types.Abstract;

namespace Depra.Pawn.Runtime.Locomotion.Types.Terrestrial.WalkingAndRunning.Abstract
{
    public abstract class GroundLocomotionType : LocomotionType
    {
        internal override bool AvailableFor(ILocomotionStateComponent state) => state.Grounded;
    }
}