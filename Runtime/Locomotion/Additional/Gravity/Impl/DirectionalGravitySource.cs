using Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Impl
{
    public class DirectionalGravitySource : IGravitySource
    {
        private readonly float _gravityStrength;
        private readonly Vector3 _gravityDirection;

        public Vector3 GetGravity(IGravityComponent gravityComponent)
        {
            var gravityForce = _gravityStrength * gravityComponent.GravityMultiplier * _gravityDirection;
            return gravityForce;
        }

        public DirectionalGravitySource(float strength, Vector3 gravityDirection)
        {
            _gravityStrength = strength;
            _gravityDirection = gravityDirection;
        }
    }
}