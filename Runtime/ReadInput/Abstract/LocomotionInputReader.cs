using Depra.Pawn.Runtime.ReadInput.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.ReadInput.Abstract
{
    public abstract class LocomotionInputReader : ScriptableObject, ILocomotionInputReader
    {
        public abstract float Horizontal();

        public abstract float Vertical();

        public abstract bool IsJumpPressed();

        public abstract bool IsWalkPressed();

        public abstract bool IsSprintPressed();
        
        public abstract bool IsCrouchPressed();
    }
}