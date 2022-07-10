using Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Impl;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Types.Other
{
    public class OrbitalLocomotion : LocomotionType
    {
        public struct OrbitSettings
        {
            private const float DefaultFrequency = 0.001f;
            private static readonly Vector3 DefaultInitialVelocity = new(0f, 0.5f, 0f);

            public float Frequency { get; }

            public Vector3 InitialVelocity { get; }

            public OrbitSettings(float frequency, Vector3 initialVelocity)
            {
                Frequency = frequency;
                InitialVelocity = initialVelocity;
            }

            public static OrbitSettings Default = new(DefaultFrequency, DefaultInitialVelocity);
        }

        private readonly float _frequency;
        private readonly IGravityComponent _gravityComponent;
        private readonly PlanetGravitySource _gravitySource;

        private Vector3 _velocity;

        private IGravityComponent Planet => _gravitySource.Planet;

        public override Vector3 CalculateVelocity(IVelocityComponent context)
        {
            var originalPosition = Planet.Position;

            var acceleration = _gravitySource.GetGravity(_gravityComponent) / Planet.Mass;

            // d = vt + 0.5at^2
            var planetMotion = _velocity * _frequency + acceleration * (0.5f * _frequency * _frequency);
            _gravitySource.Planet.Position = Planet.Position + planetMotion;

            _velocity = (Planet.Position - originalPosition) / _frequency;

            return _velocity;
        }

        public OrbitalLocomotion(IGravityComponent gravityComponent, PlanetGravitySource gravitySource,
            OrbitSettings settings)
        {
            _gravityComponent = gravityComponent;
            _gravitySource = gravitySource;

            _frequency = settings.Frequency;
            _velocity = settings.InitialVelocity;
        }

        internal override bool AvailableFor(ILocomotionStateComponent state) => true;
    }
}