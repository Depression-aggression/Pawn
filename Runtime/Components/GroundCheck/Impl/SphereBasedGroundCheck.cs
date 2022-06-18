using Depra.Pawn.Runtime.Components.GroundCheck.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Components.GroundCheck.Impl
{
    public class SphereBasedGroundCheck : GroundChecker
    {
        [SerializeField] private Transform _origin;

        [Tooltip("Offset for the ground spherecast. Will need tweaking based on character collider.")] [SerializeField]
        private Vector3 _sphereCastOffset;

        [Tooltip("Size of ground spherecast. Will need tweaking based on character collider.")] [SerializeField]
        private float _checkRadius;

        [SerializeField] private LayerMask _layerMask;

        private void Update()
        {
            Check();
        }

        public override void Check()
        {
            WasGroundedLastFrame = IsGrounded;
            IsGrounded = Physics.CheckSphere(_origin.position + _sphereCastOffset, _checkRadius, _layerMask,
                QueryTriggerInteraction.Ignore);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = IsGrounded ? Color.red : Color.green;
            Gizmos.DrawSphere(_origin.position + _sphereCastOffset, _checkRadius);
        }
    }
}