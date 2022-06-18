using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Rotor.Abstract
{
    public abstract class RotorConfigurator : ScriptableObject
    {
        public abstract OrientationType SetupOrientation(float initialYaw, float initialPitch);
    }
}