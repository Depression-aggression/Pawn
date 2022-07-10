using System;

namespace Depra.Pawn.Runtime.Locomotion.Components.Impl
{
    [Flags]
    public enum LocomotionInputFlags : ushort
    {
        JumpHeld = 1,
        WalkHeld = 2,
        SprintHeld = 4,
        CrouchHeld = 8
    }
}