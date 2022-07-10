using Depra.Pawn.Runtime.Locomotion.Configuration.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Motor.Abstract;
using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Configuration.Abstract
{
    public abstract class LocomotionConfigurationScriptable : ScriptableObject, ILocomotionConfiguration
    {
        public abstract void ConfigureLayer(ILocomotionLayer layer);

        public abstract void ConfigureLayerExtensions(PawnMotorBase monoLayer);
    }
}