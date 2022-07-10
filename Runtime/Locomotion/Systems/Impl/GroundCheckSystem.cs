using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Extensions.GroundCheck.Abstract;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;

namespace Depra.Pawn.Runtime.Locomotion.Systems.Impl
{
    public class GroundCheckSystem : ILocomotionSystem
    {
        private readonly IDictionary<LocomotionStateComponent, GroundChecker> _groundCheckMap;

        public void OnUpdate(float frameTime)
        {
            foreach (var (stateComponent, groundChecker) in _groundCheckMap)
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
            
            if (_groundCheckMap.ContainsKey(stateComponent))
            {
                throw new ArgumentException("Component already registered!");
            }

            _groundCheckMap[stateComponent] = groundChecker;
        }

        public GroundCheckSystem()
        {
            _groundCheckMap = new Dictionary<LocomotionStateComponent, GroundChecker>();
        }

        public GroundCheckSystem(IDictionary<LocomotionStateComponent, GroundChecker> groundCheckMap)
        {
            if (groundCheckMap == null || groundCheckMap.Count == 0)
            {
                throw new ArgumentException("Map is null or empty!");
            }

            _groundCheckMap = groundCheckMap;
        }
    }
}