using Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Impl
{
    public class PlanetGravitySource : IGravitySource
    {
        private static readonly float G = 6.67f * Mathf.Pow(10, -11);

        internal GravityComponent Planet { get; }

        public Vector3 GetGravity(IGravityComponent gravityComponent)
        {
            var objectPosition = gravityComponent.Position;
            var planetPosition = Planet.Position;

            var distance = Vector3.Distance(planetPosition, objectPosition);
            var distanceSquared = distance * distance;

            var gravityForce = G * gravityComponent.Mass * Planet.Mass / distanceSquared;

            var heading = objectPosition - planetPosition;
            var forceWithDirection = gravityForce * (heading / heading.magnitude);

            return forceWithDirection;
        }

        private PlanetGravitySource(GravityComponent planet)
        {
            Planet = planet;
        }
    }
}