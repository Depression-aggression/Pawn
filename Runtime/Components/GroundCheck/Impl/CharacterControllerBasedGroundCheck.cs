using Depra.Pawn.Runtime.Components.GroundCheck.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Components.GroundCheck.Impl
{
    public class CharacterControllerBasedGroundCheck : GroundChecker
    {
        [SerializeField] private CharacterController _controller;

        private void Update()
        {
            Check();
        }

        public override void Check()
        {
            WasGroundedLastFrame = IsGrounded;
            IsGrounded = _controller.isGrounded;
        }
    }
}