using Depra.Pawn.Runtime.Common;
using Depra.Pawn.Runtime.Locomotion.Modifications.Configuration.Abstract;
using Depra.Pawn.Runtime.Locomotion.Modifications.Types.Interfaces;
using Depra.Pawn.Runtime.Modifications.Abstract;
using Depra.Pawn.Runtime.Modifications.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Configuration.Impl
{
    [CreateAssetMenu(fileName = "Locomotion Modifications",
        menuName = Constants.FrameworkPath + Constants.ModulePath + "Locomotion/Modifications/Basic", order = 52)]
    public class BasicLocomotionModificationConfigurationScriptable : LocomotionModificationConfigurationScriptable
    {
        public override IModificationsCollection<IVelocityModification> GetAllModifications()
        {
            var modifications = new ModificationsDictionary<IVelocityModification>();

            return modifications;
        }
    }
}