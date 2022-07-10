using Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Impl
{
    public class CustomGravityCalculator : IGravitySource
    {
        private readonly float _gravityStrength;
        private readonly Vector3 _gravityDirection;

        public Vector3 GetGravity(IGravityComponent gravityComponent)
        {
            var upAxis = GetUpAxis(gravityComponent.Position);
            var gravityForce = _gravityStrength * upAxis;

            return gravityForce;
        }

        private Vector3 GetUpAxis(Vector3 position)
        {
            var up = position.normalized;
            return _gravityDirection.y < 0f ? up : -up;
        }

        public CustomGravityCalculator(float strength, Vector3 direction)
        {
            _gravityStrength = strength;
            _gravityDirection = direction;
        }
    }
}