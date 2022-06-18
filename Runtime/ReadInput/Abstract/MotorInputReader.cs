using Depra.Pawn.Runtime.Modules.ReadInput.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Modules.ReadInput.Abstract
{
    public abstract class MotorInputReader : ScriptableObject, IMotorInputReader
    {
        public abstract float Horizontal();

        public abstract float Vertical();

        public abstract bool IsJumpPressed();

        public abstract bool IsWalkPressed();

        public abstract bool IsSprintPressed();
        public abstract bool IsCrouchPressed();
    }
}