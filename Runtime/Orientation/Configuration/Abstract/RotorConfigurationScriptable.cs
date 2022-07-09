using Depra.Pawn.Runtime.Orientation.Configuration.Interfaces;
using Depra.Pawn.Runtime.Orientation.Rotor.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Configuration.Abstract
{
    public abstract class RotorConfigurationScriptable : ScriptableObject, IOrientationLayerConfiguration
    {
        public abstract void ConfigureLayer(IOrientationLayer layer, float initialYaw, float initialPitch);
    }
}