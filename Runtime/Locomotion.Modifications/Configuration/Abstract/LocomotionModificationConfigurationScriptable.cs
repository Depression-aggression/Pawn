using Depra.Pawn.Runtime.Locomotion.Modifications.Configuration.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Modifications.Types.Interfaces;
using Depra.Pawn.Runtime.Modifications.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Configuration.Abstract
{
    public abstract class LocomotionModificationConfigurationScriptable : ScriptableObject, ILocomotionModificationConfiguration
    {
        public abstract IModificationsCollection<IVelocityModification> GetAllModifications();
    }
}