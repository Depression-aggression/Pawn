using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Types.Impl
{
    // TODO: Finalize
    
    /// <summary>
    /// Rotates a this transform to align it towards the target transform's position
    /// </summary>
    public class GravityOrientation : OrientationType
    {
        private readonly Transform _planet;
        private readonly Transform _origin;

        private Vector3 Direction => (_origin.position - _planet.position).normalized;

        public override Quaternion CalculateHorizontalRotation(float yaw)
        {
            var horizontalRotation = Quaternion.FromToRotation(_origin.up, Direction) * _origin.rotation;
            return horizontalRotation;
        }

        public override Quaternion CalculateVerticalRotation(float pitch)
        {
            throw new System.NotImplementedException();
        }

        public GravityOrientation(Transform planet, Transform origin)
        {
            _planet = planet;
            _origin = origin;
        }
    }
}