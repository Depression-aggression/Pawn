using System;
using Depra.Pawn.Runtime.Modifications.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Abstract;
using Depra.Pawn.Runtime.Orientation.Systems.Interfaces;
using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Systems
{
    public class OrientationOriginRotationModificationSystem : IOrientationSystem, IModificationContext<OrientationModification<Quaternion>>
    {
        private readonly ILocalRotationProvider[] _rotationReceivers;
        private readonly IModificationsCollection<OrientationModification<Quaternion>> _modifications;

        public void OnUpdate(float timeStep)
        {
            for (var i = 0; i < _rotationReceivers.Length; i++)
            {
                ModifyReceiverRotation(_rotationReceivers[i], timeStep);
            }
        }

        public void AddModification(OrientationModification<Quaternion> modification) =>
            _modifications.AddModification(modification);

        public void RemoveModification(Type modificationType) =>
            _modifications.RemoveModification(modificationType);

        public OrientationOriginRotationModificationSystem(ILocalRotationProvider[] receivers, IModificationsCollection<OrientationModification<Quaternion>> modifications)
        {
            _rotationReceivers = receivers;
            _modifications = modifications;
        }

        private void ModifyReceiverRotation(ILocalRotationProvider rotationProvider, float timeStep)
        {
            var previousRotation = rotationProvider.LocalRotation;
            var modifiedRotation = ModifyRotation(previousRotation, timeStep);
            rotationProvider.LocalRotation = modifiedRotation;
        }
        
        private Quaternion ModifyRotation(Quaternion previousRotation, float timeStep)
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