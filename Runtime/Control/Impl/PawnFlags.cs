using System;

namespace Depra.Pawn.Runtime.Control.Impl
{
    [Flags]
    public enum PawnFlags
    {
        Ducked = 1,
        Grounded = 2,
        JumpHeld = 4,
        WaterJump = 8
    }
}