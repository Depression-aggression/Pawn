using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Modifications.Types.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;
using Depra.Pawn.Runtime.Modifications.Abstract;
using Depra.Pawn.Runtime.Modifications.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Systems.Impl
{
    public class VelocityModificationSystem : ILocomotionSystem
    {
        private readonly IDictionary<VelocityComponent, IModificationsCollection<IVelocityModification>>
            _modificationsMap;

        public void OnUpdate(float frameTime)
        {
            foreach (var (component, modifications) in _modificationsMap)
            {
                component.FrameTime = frameTime;
                ModifyVelocity(component, modifications);
            }
        }

        public void AddModification(VelocityComponent velocityComponent, IVelocityModification modification)
        {
            if (_modificationsMap.ContainsKey(velocityComponent))
            {
                _modificationsMap[velocityComponent].AddModification(modification);
            }
            else
            {
                _modificationsMap.Add(velocityComponent, new ModificationsDictionary<IVelocityModification>(modification));
            }
        }
        
        public VelocityModificationSystem()
        {
            _modificationsMap =
                new Dictionary<VelocityComponent, IModificationsCollection<IVelocityModification>>();
        }

        public VelocityModificationSystem(
            IDictionary<VelocityComponent, IModificationsCollection<IVelocityModification>> modificationsMap)
        {
            if (modificationsMap == null || modificationsMap.Count == 0)
            {
                throw new ArgumentException("Modifications map is null or empty!");
            }
            
            _modificationsMap = modificationsMap;
        }

        private static void ModifyVelocity(VelocityComponent component,
            IModificationsCollection<IVelocityModification> modifications)
        {
            var modifiedVelocity = component.TargetVelocity;
            foreach (var modification in modifications.GetAll())
            {
                modifiedVelocity = modification.Modify(modifiedVelocity);
            }

            component.TargetVelocity = modifiedVelocity;
        }
    }
}