using System;
using Depra.Pawn.Runtime.Orientation.Configuration.Interfaces;
using Depra.Pawn.Runtime.Orientation.Rotor.Interfaces;
using Depra.Pawn.Runtime.Orientation.Systems.Interfaces;
using Depra.Pawn.Runtime.Orientation.Targets.Abstract;
using Depra.Pawn.Runtime.UpdateMethod.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Rotor.Abstract
{
    public abstract class PawnRotor : UpdatablePawnBehavior, IOrientationLayer
    {
        private IOrientationSystem[] _systems;

        public OrientationOrigin[] Origins { get; private set; }

        protected abstract IOrientationLayerConfiguration Configuration { get; }

        public void Setup()
        {
            Origins = SetupOrigins();
            
            var initialRotation = Origins[0].LocalRotation;
            var initialAngles = new Vector2(initialRotation.x, initialRotation.y);

            _systems = Array.Empty<IOrientationSystem>();
            Configuration.ConfigureLayer(this, initialAngles.x, initialAngles.y);
        }

        public void OnUpdate(float timeStep)
        {
            foreach (var system in _systems)
            {
                system.OnUpdate(timeStep);
            }
        }

        public void AddSystem(IOrientationSystem system)
        {
            Array.Resize(ref _systems, _systems.Length + 1);
            _systems[^1] = system;
        }

        protected abstract OrientationOrigin[] SetupOrigins();
    }
}