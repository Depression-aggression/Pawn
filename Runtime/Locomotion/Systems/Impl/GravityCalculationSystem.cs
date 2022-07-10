using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Systems.Interfaces;
using JetBrains.Annotations;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Systems.Impl
{
    public class GravityCalculationSystem : ILocomotionSystem
    {
        private readonly IDictionary<GravityComponent, IGravitySource[]> _gravitySourcesMap;

        public void OnUpdate(float frameTime)
        {
            foreach (var (component, sources) in _gravitySourcesMap)
            {
                var targetGravityForce = CalculateGravityForComponent(component, sources);
                component.GravityForce = targetGravityForce;
            }
        }

        public void AddComponent(GravityComponent component, [NotNull] params IGravitySource[] gravitySources)
        {
            if (component == null)
            {
                throw new NullReferenceException("Component is null!");
            }

            if (gravitySources == null || gravitySources.Length == 0)
            {
                throw new NullReferenceException("Sources is null or empty!");
            }

            if (_gravitySourcesMap.ContainsKey(component))
            {
                throw new ArgumentException("Component already registered!");
            }

            _gravitySourcesMap.Add(component, gravitySources);
        }

        public GravityCalculationSystem()
        {
            _gravitySourcesMap = new Dictionary<GravityComponent, IGravitySource[]>();
        }

        public GravityCalculationSystem(IDictionary<GravityComponent, IGravitySource[]> gravitySources)
        {
            if (gravitySources == null || gravitySources.Count == 0)
            {
                throw new ArgumentException("Gravity sources is null or empty!");
            }

            _gravitySourcesMap = gravitySources;
        }

        private static Vector3 CalculateGravityForComponent(IGravityComponent component, IGravitySource[] sources)
        {
            var gravity = Vector3.zero;
            for (var i = 0; i < sources.Length; i++)
            {
                gravity += sources[i].GetGravity(component);
            }

            return gravity;
        }
    }
}