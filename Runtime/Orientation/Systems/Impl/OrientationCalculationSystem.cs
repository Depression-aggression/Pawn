using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Orientation.Components.Impl;
using Depra.Pawn.Runtime.Orientation.Structs;
using Depra.Pawn.Runtime.Orientation.Systems.Interfaces;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;

namespace Depra.Pawn.Runtime.Orientation.Systems.Impl
{
    public class OrientationCalculationSystem : IOrientationSystem
    {
        private readonly IDictionary<OrientationInputComponent, IList<OrientationComponent>> _componentsMap;

        public void OnUpdate(float timeStep)
        {
            foreach (var (input, components) in _componentsMap)
            {
                CalculateRotationForComponents(input, components);
            }
        }

        public void AddComponent(OrientationInputComponent inputComponent, OrientationComponent rotationComponent)
        {
            if (inputComponent == null)
            {
                throw new NullReferenceException("Input component is null!");
            }

            if (rotationComponent == null)
            {
                throw new NullReferenceException("Rotation components is null!");
            }

            if (_componentsMap.ContainsKey(inputComponent))
            {
                if (_componentsMap[inputComponent].Contains(rotationComponent))
                {
                    throw new ArgumentException("Rotation component already registered!");
                }

                _componentsMap[inputComponent].Add(rotationComponent);
            }


            _componentsMap.Add(inputComponent, new List<OrientationComponent>() { rotationComponent });
        }

        public OrientationCalculationSystem()
        {
            _componentsMap = new Dictionary<OrientationInputComponent, IList<OrientationComponent>>();
        }

        public OrientationCalculationSystem(
            IDictionary<OrientationInputComponent, IList<OrientationComponent>> componentsMap)
        {
            if (componentsMap == null || componentsMap.Count == 0)
            {
                throw new ArgumentException("Components map is null or empty!");
            }

            _componentsMap = componentsMap;
        }

        private static void CalculateRotationForComponents(OrientationInputComponent input,
            IList<OrientationComponent> components)
        {
            for (var i = 0; i < components.Count; i++)
            {
                var biaxialRotation = CalculateRotationForType(input, components[i].OrientationType);
                components[i].TargetLocalRotation = biaxialRotation;
            }
        }

        private static BiaxialRotation CalculateRotationForType(OrientationInputComponent input,
            OrientationType orientationType)
        {
            var horizontalRotation = orientationType.CalculateHorizontalRotation(input.YawInput);
            var verticalRotation = orientationType.CalculateVerticalRotation(input.PitchInput);
            var biaxialRotation = new BiaxialRotation(horizontalRotation, verticalRotation);

            return biaxialRotation;
        }
    }
}