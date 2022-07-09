using System;
using Depra.Pawn.Runtime.Modifications.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Abstract;
using Depra.Pawn.Runtime.Orientation.Systems.Interfaces;
using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Systems
{
    public class OrientationOriginPositionModificationSystem : IOrientationSystem, IModificationContext<OrientationModification<Vector3>>
    {
        private readonly ILocalPositionProvider[] _localPositionProviders;
        private readonly IModificationsCollection<OrientationModification<Vector3>> _modifications;

        public void OnUpdate(float timeStep)
        {
            for (var i = 0; i < _localPositionProviders.Length; i++)
            {
                ModifyReceiverPosition(_localPositionProviders[i], timeStep);
            }
        }
        
        public void AddModification(OrientationModification<Vector3> modification) =>
            _modifications.AddModification(modification);

        public void RemoveModification(Type modificationType) =>
            _modifications.RemoveModification(modificationType);

        public OrientationOriginPositionModificationSystem(ILocalPositionProvider[] positionProviders,
            IModificationsCollection<OrientationModification<Vector3>> modifications)
        {
            _localPositionProviders = positionProviders;
            _modifications = modifications;
        }

        private void ModifyReceiverPosition(ILocalPositionProvider receiver, float timeStep)
        {
            var previousLocalPosition = receiver.LocalPosition;
            var modifiedLocalPosition = ModifyPosition(previousLocalPosition, timeStep);
            receiver.LocalPosition = modifiedLocalPosition;
        }

        private Vector3 ModifyPosition(Vector3 previousRotation, float timeStep)
        {
            var modifiedRotation = previousRotation;
            foreach (var modification in _modifications.GetAll())
            {
                modifiedRotation = modification.Modify(modifiedRotation, timeStep);
            }

            return modifiedRotation;
        }
    }
}