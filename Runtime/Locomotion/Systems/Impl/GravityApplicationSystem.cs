using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Systems.Impl
{
    public class GravityApplicationSystem : ILocomotionSystem
    {
        private readonly IDictionary<GravityComponent, VelocityComponent> _velocityComponentsMap;

        public void OnUpdate(float frameTime)
        {
            foreach (var (gravityComponent, velocityComponent) in _velocityComponentsMap)
            {
                velocityComponent.TargetVelocity += gravityComponent.GravityForce;
            }
        }

        public void AddComponent(GravityComponent gravityComponent, VelocityComponent velocityComponent)
        {
            if (gravityComponent == null)
            {
                throw new NullReferenceException("Gravity component is null!");
            }

            if (_velocityComponentsMap.ContainsKey(gravityComponent))
            {
                throw new ArgumentException("Component already registered!");
            }

            _velocityComponentsMap[gravityComponent] =
                velocityComponent ?? throw new NullReferenceException("Velocity component is null!");
        }

        public GravityApplicationSystem()
        {
            _velocityComponentsMap = new Dictionary<GravityComponent, VelocityComponent>();
        }

        public GravityApplicationSystem(IDictionary<GravityComponent, VelocityComponent> velocityComponentsMap)
        {
            if (velocityComponentsMap == null || velocityComponentsMap.Count == 0)
            {
                throw new ArgumentException("Map is null or empty!");
            }

            _velocityComponentsMap = velocityComponentsMap;
        }
    }
}