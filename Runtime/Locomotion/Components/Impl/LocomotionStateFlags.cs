using System;

namespace Depra.Pawn.Runtime.Locomotion.Components.Impl
{
    [Flags]
    public enum LocomotionStateFlags : ushort
    {
        Grounded = 1,
        Jumped = 2,
        WaterJump = 4,
        Ducked = 8
    }
}