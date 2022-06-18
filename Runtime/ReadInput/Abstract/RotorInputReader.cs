using Depra.Pawn.Runtime.Modules.ReadInput.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Modules.ReadInput.Abstract
{
    public abstract class RotorInputReader : ScriptableObject, IRotorInputReader
    {
        public abstract float Yaw { get; }
        
        public abstract float Pitch { get; }

        public abstract bool IsZoomPressed();
    }
}