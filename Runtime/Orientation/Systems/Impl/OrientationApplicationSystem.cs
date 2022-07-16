using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Orientation.Components.Impl;
using Depra.Pawn.Runtime.Orientation.Structs;
using Depra.Pawn.Runtime.Orientation.Systems.Interfaces;
using Depra.Pawn.Runtime.Orientation.Targets.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Systems.Impl
{
    public class OrientationApplicationSystem : IOrientationSystem
    {
        private readonly IDictionary<OrientationComponent, OrientationOrigin[]> _orientationOriginsMap;

        public void OnUpdate(float timeStep)
        {
            foreach (var (orientationComponent, receivers) in _orientationOriginsMap)
            {
                var targetRotation = orientationComponent.TargetLocalRotation;
                var currentRotation = ApplyOrientationToReceivers(receivers, targetRotation);
                orientationComponent.CurrentLocalRotation = currentRotation;
            }
        }

        public void AddComponent(OrientationComponent component, OrientationOrigin[] receivers)
        {
            if (component == null)
            {
                throw new NullReferenceException("Component is null!");
            }

            if (receivers == null || receivers.Length == 0)
            {
                throw new NullReferenceException("Receivers is null or empty!");
            }

            if (_orientationOriginsMap.ContainsKey(component))
            {
                throw new ArgumentException("Component already registered!");
            }

            _orientationOriginsMap.Add(component, receivers);
        }

        public OrientationApplicationSystem()
        {
            _orientationOriginsMap = new Dictionary<OrientationComponent, OrientationOrigin[]>();
        }

        public OrientationApplicationSystem(IDictionary<OrientationComponent, OrientationOrigin[]> receiversMap)
        {
            if (receiversMap == null || receiversMap.Count == 0)
            {
                throw new ArgumentException("Rotation receivers dictionary is null or empty!");
            }

            _orientationOriginsMap = receiversMap;
        }

        private static Quaternion ApplyOrientationToReceivers(IReadOnlyList<OrientationOrigin> receivers,
            BiaxialRotation rotation)
        {
            for (var i = 0; i < receivers.Count; i++)
            {
                receivers[i].SetLocalRotation(rotation.HorizontalRotation, rotation.VerticalRotation);
            }

            return receivers[^1].LocalRotation;
        }
    }
}