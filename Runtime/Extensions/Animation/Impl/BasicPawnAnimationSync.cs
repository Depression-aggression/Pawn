using Depra.Pawn.Runtime.Extensions.Animation.Abstract;
using Depra.Pawn.Runtime.Extensions.GroundCheck.Abstract;
using Depra.Pawn.Runtime.Locomotion.Targets.Abstract;
using Depra.Pawn.Runtime.ReadInput.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Extensions.Animation.Impl
{
    public class BasicPawnAnimationSync : PawnAnimationSync
    {
        [SerializeField] private Animator _animator;

        [SerializeField] private GroundChecker _groundCheck;
        [SerializeField] private LocomotionInputReader _inputReader;
        [SerializeField] private VelocityReceiver _velocityReceiver;

        [SerializeField] private float _smoothSpeed;
        public float _smoothValue;
        public float _test;

        private int _forwardHash;
        private int _jumpHash;
        private int _groundHash;

        private void Awake()
        {
            AssignIDs();
        }

        private void AssignIDs()
        {
            _forwardHash = Animator.StringToHash("Forward");
            _jumpHash = Animator.StringToHash("IsJumping");
            _groundHash = Animator.StringToHash("IsGrounded");
        }

        protected override void UpdateAnimations()
        {
            _animator.SetBool(_groundHash, _groundCheck.IsGrounded);
            _animator.SetBool(_jumpHash, _inputReader.IsJumpPressed());

            //if (_velocityReceiver.CurrentVelocity > 0)
            //{
            //_test = _movement.CurrentSpeed / _movement.TargetSpeed;
            //}
            //else
            {
                _test = 0;
            }

            _smoothValue = Mathf.MoveTowards(_smoothValue, _test, _smoothSpeed * Time.deltaTime);
            _animator.SetFloat(_forwardHash, _smoothValue);
        }
    }
}