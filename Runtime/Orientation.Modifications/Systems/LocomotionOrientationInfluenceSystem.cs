using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Interfaces;
using Depra.Pawn.Runtime.Orientation.Systems.Interfaces;
using Depra.Pawn.Runtime.ReadInput.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Systems
{
    public class LocomotionOrientationInfluenceSystem : IOrientationSystem
    {
        private readonly IDictionary<ILocomotionInputReader, IOrientationModification[]> _modificationsMap;

        public void OnUpdate(float timeStep)
        {
            if (_modificationsMap.Count == 0)
            {
                return;
            }

            foreach (var (inputReader, modifications) in _modificationsMap)
            {
                ProcessInputReader(inputReader, modifications);
            }
        }

        public LocomotionOrientationInfluenceSystem(IDictionary<ILocomotionInputReader, IOrientationModification[]>
            modificationsMap)
        {
            if (modificationsMap == null || modificationsMap.Count == 0)
            {
                throw new NullReferenceException("Modifications map is null of empty!");
            }
            
            _modificationsMap = modificationsMap;
        }

        public LocomotionOrientationInfluenceSystem(ILocomotionInputReader locomotionInputReader,
            IOrientationModification[] modifications)
        {
            if (locomotionInputReader == null)
            {
                throw new NullReferenceException("Input reader is null!");
            }

            if (modifications == null || modifications.Length == 0)
            {
                throw new ArgumentException("Modifications collection is null or empty!");
            }
            
            _modificationsMap = new Dictionary<ILocomotionInputReader, IOrientationModification[]>();
            _modificationsMap.Add(locomotionInputReader, modifications);
        }

        private static void ProcessInputReader(ILocomotionInputReader inputReader,
            IOrientationModification[] modifications)
        {
            var horizontalDirection = inputReader.Horizontal();
            var verticalDirection = inputReader.Vertical();
            var motionDirection = new Vector2(horizontalDirection, verticalDirection);

            foreach (var modification in modifications)
            {
                modification.SetDirection(motionDirection);
            }
        }
    }
}