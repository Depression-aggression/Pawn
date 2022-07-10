using Depra.Pawn.Runtime.Extensions.GroundCheck.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Extensions.GroundCheck.Impl
{
    public class CharacterControllerBasedGroundCheck : GroundChecker
    {
        [SerializeField] private CharacterController _controller;

        private void Update()
        {
            Check();
        }

        protected override void Check()
        {
            WasGroundedLastFrame = IsGrounded;
            IsGrounded = _controller.isGrounded;
        }
    }
}