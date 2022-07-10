using Depra.Pawn.Runtime.Locomotion.Components.Impl;

namespace Depra.Pawn.Runtime.Locomotion.Components.Interfaces
{
    public interface ILocomotionStateComponent
    {
        bool Grounded { get; }

        bool Jumped { get; }

        LocomotionStateFlags GetRawData();
    }
}