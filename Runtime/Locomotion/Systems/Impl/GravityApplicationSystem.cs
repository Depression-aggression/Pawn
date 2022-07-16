using System;
using System.Collections.Generic;
using System.Linq;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Systems.Impl
{
    public class GravityApplicationSystem : ILocomotionSystem
    {
        private readonly IList<Tuple<IGravityComponent, VelocityComponent, ILocomotionStateComponent>> _filter;

        public void OnUpdate(float frameTime)
        {
            foreach (var (gravityComponent, velocityComponent, stateComponent) in _filter)
            {
                var targetVelocity = velocityComponent.TargetVelocity;
                if (stateComponent.Grounded)
                {
                    targetVelocity.y = gravityComponent.GravityForce.y;
                }
                else
                {
                    targetVelocity += gravityComponent.GravityForce;
                }
                
                velocityComponent.TargetVelocity = targetVelocity;
            }
        }

        public void Add(IGravityComponent gravity, VelocityComponent velocity, ILocomotionStateComponent state)
        {
            if (gravity == null)
            {
                throw new NullReferenceException("Gravity component is null!");
            }

            if (_filter.Any(x => x.Item1 == gravity && x.Item2 == velocity && x.Item3 == state))
            {
                throw new ArgumentException("Component already registered!");
            }

            _filter.Add(
                new Tuple<IGravityComponent, VelocityComponent, ILocomotionStateComponent>(gravity, velocity, state));
        }

        public GravityApplicationSystem()
        {
            _filter = new List<Tuple<IGravityComponent, VelocityComponent, ILocomotionStateComponent>>();
        }

        public GravityApplicationSystem(IList<Tuple<IGravityComponent, VelocityComponent, ILocomotionStateComponent>> filter)
        {
            if (filter == null || filter.Count == 0)
            {
                throw new ArgumentException("Map is null or empty!");
            }

            _filter = filter;
        }
    }
}