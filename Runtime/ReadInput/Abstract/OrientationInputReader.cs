using Depra.Pawn.Runtime.ReadInput.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.ReadInput.Abstract
{
    public abstract class OrientationInputReader : ScriptableObject, IOrientationInputReader
    {
        public abstract float Yaw { get; }
        
        public abstract float Pitch { get; }

        public abstract bool IsZoomPressed();
    }
}