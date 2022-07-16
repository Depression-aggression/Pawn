using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Systems.Impl
{
    public class GravityCorrectionAccordStateSystem : ILocomotionSystem
    {
        private readonly IDictionary<GravityComponent, ILocomotionStateComponent> _filter;

        public void OnUpdate(float frameTime)
        {
            foreach (var (gravityComponent, stateComponent) in _filter)
            {
                if (stateComponent.Grounded)
                {
                    continue;
                }

                gravityComponent.GravityForce *= frameTime;
            }
        }

        public void AddComponent(GravityComponent gravityComponent, ILocomotionStateComponent stateComponent)
        {
            if (gravityComponent == null)
            {
                throw new NullReferenceException("Gravity component is null!");
            }

            if (_filter.ContainsKey(gravityComponent))
            {
                throw new ArgumentException("Component already registered!");
            }

            _filter[gravityComponent] =
                stateComponent ?? throw new NullReferenceException("State component is null!");
        }

        public GravityCorrectionAccordStateSystem()
        {
            _filter = new Dictionary<GravityComponent, ILocomotionStateComponent>();
        }

        public GravityCorrectionAccordStateSystem(IDictionary<GravityComponent, ILocomotionStateComponent> filter)
        {
            if (filter == null || filter.Count == 0)
            {
                throw new ArgumentException("Map is null or empty!");
            }

            _filter = filter;
        }
    }
}