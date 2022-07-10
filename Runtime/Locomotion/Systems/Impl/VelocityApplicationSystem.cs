using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Systems.Impl
{
    public class VelocityApplicationSystem : ILocomotionSystem
    {
        private readonly IDictionary<VelocityComponent, IVelocityReceiver[]> _velocityReceiversMap;

        public void OnUpdate(float frameTime)
        {
            foreach (var (velocityComponent, receivers) in _velocityReceiversMap)
            {
                var targetVelocity = velocityComponent.TargetVelocity;
                var currentVelocity = ApplyOrientationToReceivers(receivers, targetVelocity);
                
                velocityComponent.FrameTime = frameTime;
                velocityComponent.CurrentVelocity = currentVelocity;
            }
        }

        public void AddComponent(VelocityComponent component, params IVelocityReceiver[] velocityReceivers)
        {
            if (component == null)
            {
                throw new NullReferenceException("Component is null!");
            }

            if (velocityReceivers == null || velocityReceivers.Length == 0)
            {
                throw new NullReferenceException("Receivers is null or empty!");
            }

            if (_velocityReceiversMap.ContainsKey(component))
            {
                throw new ArgumentException("Component already registered!");
            }

            _velocityReceiversMap.Add(component, velocityReceivers);
        }
        
        public VelocityApplicationSystem()
        {
            _velocityReceiversMap = new Dictionary<VelocityComponent, IVelocityReceiver[]>();
        }

        public VelocityApplicationSystem(IDictionary<VelocityComponent, IVelocityReceiver[]> receiversMap)
        {
            if (receiversMap == null || receiversMap.Count == 0)
            {
                throw new ArgumentException("Velocity receivers dictionary is null or empty!");
            }
            
            _velocityReceiversMap = receiversMap;
        }

        private static Vector3 ApplyOrientationToReceivers(IReadOnlyList<IVelocityReceiver> receivers, Vector3 velocity)
        {
            for (var i = 0; i < receivers.Count; i++)
            {
                receivers[i].SetRelativeVelocity(velocity);
            }

            return velocity;
        }
    }
}