using Depra.Pawn.Runtime.Orientation.Configuration.Interfaces;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Configuration.Abstract
{
    public abstract class RotorConfigurator : ScriptableObject, IOrientationConfiguration
    {
        public abstract OrientationType SetupOrientation(float initialYaw, float initialPitch);
    }
}