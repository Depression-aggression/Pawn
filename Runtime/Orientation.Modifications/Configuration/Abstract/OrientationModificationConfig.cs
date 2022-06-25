using Depra.Pawn.Runtime.Modifications.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Abstract
{
    public abstract class OrientationModificationConfig : ScriptableObject, IRotationModificationConfiguration,
        IOrientationOriginPositionModificationConfiguration
    {
        protected Vector3 InitialOriginPosition { get; private set; }
        
        public abstract IModificationsCollection<OrientationModification<Quaternion>> GetRotationModifications();

        public abstract IModificationsCollection<OrientationModification<Vector3>> GetPositionModifications();
        
        internal void Initialize(Vector3 initialOriginPosition)
        {
            InitialOriginPosition = initialOriginPosition;
        }
    }
}