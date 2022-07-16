using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Extensions.GroundCheck.Abstract;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Systems.Impl
{
    public class GroundCheckSystem : ILocomotionSystem
    {
        private readonly IDictionary<LocomotionStateComponent, GroundChecker> _filter;

        public void OnUpdate(float frameTime)
        {
            foreach (var (stateComponent, groundChecker) in _filter)
            {
                stateComponent.Grounded = groundChecker.IsGrounded;
            }
        }
        
        public void AddComponent(LocomotionStateComponent stateComponent, GroundChecker groundChecker)
        {
            if (stateComponent == null)
            {
                throw new NullReferenceException("State component is null!");
            }

            if (groundChecker == null)
            {
                throw new NullReferenceException("Ground checker is null!");
            }
            
            if (_filter.ContainsKey(stateComponent))
            {
                throw new ArgumentException("Component already registered!");
            }

            _filter[stateComponent] = groundChecker;
        }

        public GroundCheckSystem()
        {
            _filter = new Dictionary<LocomotionStateComponent, GroundChecker>();
        }

        public GroundCheckSystem(IDictionary<LocomotionStateComponent, GroundChecker> filter)
        {
            if (filter == null || filter.Count == 0)
            {
                throw new ArgumentException("Map is null or empty!");
            }

            _filter = filter;
        }
    }
}