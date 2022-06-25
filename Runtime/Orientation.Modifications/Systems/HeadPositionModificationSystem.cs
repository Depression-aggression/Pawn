using System;
using Depra.Pawn.Runtime.Modifications.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Systems
{
    public class HeadPositionModificationSystem : IModificationContext<OrientationModification<Vector3>>
    {
        private readonly Transform _headOrigin;
        private readonly IModificationsCollection<OrientationModification<Vector3>> _modifications;

        public void ApplyPositionModifications(Vector3 previousOriginPosition, float timeStep)
        {
            var modifiedPosition = previousOriginPosition;
            foreach (var modification in _modifications.GetAll())
            {
                modifiedPosition = modification.Modify(modifiedPosition, timeStep);
            }

            _headOrigin.localPosition = modifiedPosition;
        }

        public void AddModification(OrientationModification<Vector3> modification) =>
            _modifications.AddModification(modification);

        public void RemoveModification(Type modificationType) => 
            _modifications.RemoveModification(modificationType);
        
        public HeadPositionModificationSystem(Transform headOrigin, IOrientationOriginPositionModificationConfiguration configuration)
        {
            _headOrigin = headOrigin;
            _modifications = configuration.GetPositionModifications();
        }
    }
}