using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Orientation.Components.Impl;
using Depra.Pawn.Runtime.Orientation.Systems.Interfaces;
using Depra.Pawn.Runtime.ReadInput.Interfaces;

namespace Depra.Pawn.Runtime.Orientation.Systems.Impl
{
    public class OrientationInputSystem : IOrientationSystem
    {
        private readonly IDictionary<IOrientationInputReader, OrientationInputComponent> _componentsMap;
        
        public void OnUpdate(float timeStep)
        {
            foreach (var (inputReader, component) in _componentsMap)
            {
                ApplyOrientationInput(inputReader, component);
            }
        }
        
        public void AddComponent(IOrientationInputReader inputReader, OrientationInputComponent component)
        {
            if (inputReader == null)
            {
                throw new NullReferenceException("Input Reader is null!");
            }

            if (component == null)
            {
                throw new NullReferenceException("Components is null!");
            }

            if (_componentsMap.ContainsKey(inputReader))
            {
                throw new ArgumentException("Input reader already registered!");
            }
            
            _componentsMap.Add(inputReader, component);
        }

        public OrientationInputSystem()
        {
            _componentsMap = new Dictionary<IOrientationInputReader, OrientationInputComponent>();
        }

        public OrientationInputSystem(IDictionary<IOrientationInputReader, OrientationInputComponent> componentsMap)
        {
            if (componentsMap == null || componentsMap.Count == 0)
            {
                throw new ArgumentException("Orientation components dictionary is null or empty!");
            }

            _componentsMap = componentsMap;
        }

        private static void ApplyOrientationInput(IOrientationInputReader inputReader, OrientationInputComponent component)
        {
            component.YawInput = inputReader.Yaw;
            component.PitchInput = inputReader.Pitch;
        }
    }
}