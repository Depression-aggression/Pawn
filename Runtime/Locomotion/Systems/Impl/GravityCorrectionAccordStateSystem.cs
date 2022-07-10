using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Systems.Impl
{
    public class GravityCorrectionSystem : ILocomotionSystem
    {
        private readonly IDictionary<GravityComponent, ILocomotionStateComponent> _stateComponentsMap;

        public void OnUpdate(float frameTime)
        {
            foreach (var (gravityComponent, stateComponent) in _stateComponentsMap)
            {
                if (stateComponent.Grounded)
                {
                    gravityComponent.GravityForce = Vector3.zero;
                }
                else
                {
                    gravityComponent.GravityForce *= frameTime;
                }
            }
        }
        
        public void AddComponent(GravityComponent gravityComponent, ILocomotionStateComponent stateComponent)
        {
            if (gravityComponent == null)
            {
                throw new NullReferenceException("Gravity component is null!");
            }

            if (_stateComponentsMap.ContainsKey(gravityComponent))
            {
                throw new ArgumentException("Component already registered!");
            }

            _stateComponentsMap[gravityComponent] =
                stateComponent ?? throw new NullReferenceException("State component is null!");
        }

        public GravityCorrectionSystem()
        {
            _stateComponentsMap = new Dictionary<GravityComponent, ILocomotionStateComponent>();
        }

        public GravityCorrectionSystem(IDictionary<GravityComponent, ILocomotionStateComponent> stateComponentsMap)
        {
            if (stateComponentsMap == null || stateComponentsMap.Count == 0)
            {
                throw new ArgumentException("Map is null or empty!");
            }

            _stateComponentsMap = stateComponentsMap;
        }
    }
}