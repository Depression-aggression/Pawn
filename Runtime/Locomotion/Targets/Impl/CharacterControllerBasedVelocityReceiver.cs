using Depra.Pawn.Runtime.Locomotion.Targets.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Targets.Impl
{
    internal class CharacterControllerBasedVelocityReceiver : VelocityReceiver
    {
        [SerializeField] private CharacterController _controller;

        public override void SetRelativeVelocity(Vector3 newVelocity)
        {
            var motion = newVelocity * Time.fixedDeltaTime;
            _controller.Move(motion);
        }

        public override void AddVelocity(Vector3 additionalVelocity)
        {
            var velocity = _controller.velocity + additionalVelocity;
            var motion = velocity * Time.fixedDeltaTime;

            _controller.Move(motion);
        }

        private void Reset()
        {
            _controller = GetComponent<CharacterController>();
        }
    }
}