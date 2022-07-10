using Depra.Pawn.Runtime.Extensions.CeilingCheck.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Extensions.CeilingCheck.Impl
{
    public class BasicCeilingCheck : CeilingChecker
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _standingHeight;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _mask;

        public override bool CanStand { get; protected set; }

        public override void CheckCeil()
        {
            var ceilDirection = transform.up;
            var projectedFloorPoint = ceilDirection * (-1 * _characterController.height) / 2;
            var projectedCapsuleHeight = projectedFloorPoint + (ceilDirection * _standingHeight);

            CanStand = Physics.CheckCapsule(projectedFloorPoint, projectedCapsuleHeight, _radius, _mask,
                QueryTriggerInteraction.Ignore);
        }

        private void Update()
        {
            CheckCeil();
        }
    }
}