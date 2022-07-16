using Depra.Pawn.Runtime.Orientation.Configuration.Interfaces;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Configuration.Abstract
{
    internal abstract class OrientationTypeConfigurationScriptable : ScriptableObject, IOrientationTypeConfiguration
    {
        public abstract OrientationType ConfigureOrientationType(float initialYaw, float initialPitch);
    }
}