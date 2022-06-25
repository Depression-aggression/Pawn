using System;
using Depra.Pawn.Runtime.Modifications.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Abstract;
using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Systems
{
    public class HeadRotationModificationSystem : IModificationContext<OrientationModification<Quaternion>>
    {
        private readonly ILocalRotationReceiver _receiver;
        private readonly IModificationsCollection<OrientationModification<Quaternion>> _modifications;

        public void ApplyRotationModifications(Quaternion previousRotation, float timeStep)
        {
            var modifiedRotation = previousRotation;
            foreach (var modification in _modifications.GetAll())
            {
                modifiedRotation = modification.Modify(modifiedRotation, timeStep);
            }
            
            _receiver.SetLocalRotation(modifiedRotation);
        }

        public void AddModification(OrientationModification<Quaternion> modification) =>
            _modifications.AddModification(modification);

        public void RemoveModification(Type modificationType) => 
            _modifications.RemoveModification(modificationType);

        public HeadRotationModificationSystem(ILocalRotationReceiver receiver, IRotationModificationConfiguration configuration)
        {
            _receiver = receiver;
            _modifications = configuration.GetRotationModifications();
        }
    }
}