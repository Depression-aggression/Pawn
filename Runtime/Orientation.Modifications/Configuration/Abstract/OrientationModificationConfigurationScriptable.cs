using System.Collections.Generic;
using Depra.Pawn.Runtime.Modifications.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Abstract;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Abstract
{
    public abstract class OrientationModificationConfigurationScriptable : ScriptableObject,
        IRotationModificationConfiguration, IOrientationOriginPositionModificationConfiguration
    {
        public abstract IModificationsCollection<OrientationModification<Quaternion>> GetRotationModifications();

        public abstract IModificationsCollection<OrientationModification<Vector3>> GetPositionModifications();

        public abstract ICollection<IOrientationModification> GetAllModifications();
    }
}