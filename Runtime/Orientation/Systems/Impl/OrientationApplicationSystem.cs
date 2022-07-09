using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Orientation.Actor.Impl;
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
            foreach (var (actor, receivers) in _orientationOriginsMap)
            {
                var targetRotation = actor.TargetLocalRotation;
                var currentRotation = ApplyOrientationToReceivers(receivers, targetRotation);
                actor.CurrentLocalRotation = currentRotation;
            }
        }

        public void AddActor(OrientationComponent actor, OrientationOrigin[] receivers)
        {
            if (actor == null)
            {
                throw new NullReferenceException("Actor is null!");
            }

            if (receivers == null || receivers.Length == 0)
            {
                throw new NullReferenceException("Receivers is null or empty!");
            }

            if (_orientationOriginsMap.ContainsKey(actor))
            {
                throw new ArgumentException("Actor already registered!");
            }

            _orientationOriginsMap.Add(actor, receivers);
        }

        public OrientationApplicationSystem()
        {
            _orientationOriginsMap = new Dictionary<OrientationComponent, OrientationOrigin[]>();
        }

        public OrientationApplicationSystem(
            IDictionary<OrientationComponent, OrientationOrigin[]> rotationReceivers)
        {
            _orientationOriginsMap = rotationReceivers ?? throw new NullReferenceException();
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