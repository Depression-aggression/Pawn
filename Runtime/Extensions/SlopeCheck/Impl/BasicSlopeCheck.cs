using Depra.Pawn.Runtime.Extensions.GroundCheck.Abstract;
using Depra.Pawn.Runtime.Extensions.SlopeCheck.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Extensions.SlopeCheck.Impl
{
    public class BasicSlopeCheck : SlopeChecker
    {
        [SerializeField] private float _maxSlopeAngle = 45f;
        [SerializeField] private Vector3 _rayOffset = new(0,-.72f,0);
        [SerializeField] private float _rayLength = 1f;
        [SerializeField] private GroundChecker _groundCheck;

        public override float Angle { get; protected set; }
        
        public override bool IsSlopeSteep { get; protected set; }
        
        public override RaycastHit SlopeHit => _hit;

        private RaycastHit _hit;
        
        private void Update()
        {
            Check();        
        }

        protected override void Check()
        {
            if (_groundCheck.IsGrounded == false)
            {
                return;
            }

            var raycast = new Ray(transform.position + _rayOffset, Vector3.down);

            if (Physics.Raycast(raycast, out _hit,  _rayLength))
            {
                //var slopeForward = Vector3.Cross(_hit.normal, -transform.right);
                //var slopeRight = Vector3.Cross(_hit.normal, slopeForward);
                
                Angle = Vector3.Angle(Vector3.up, _hit.normal);
                IsSlopeSteep = Angle > _maxSlopeAngle;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = IsSlopeSteep ? Color.red : Color.green;
            Gizmos.DrawRay(transform.position + _rayOffset, Vector3.down * _rayLength);
        }
    }
}