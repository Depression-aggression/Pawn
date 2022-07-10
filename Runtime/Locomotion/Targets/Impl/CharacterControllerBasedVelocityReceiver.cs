using Depra.Pawn.Runtime.Locomotion.Targets.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Targets.Impl
{
    internal class CharacterControllerBasedVelocityReceiver : VelocityReceiver
    {
        [SerializeField] private CharacterController _controller;

        public override void SetRelativeVelocity(Vector3 newVelocity)
        {
            Debug.Log(newVelocity);
            var motion = newVelocity * Time.fixedDeltaTime;
            _controller.Move(motion);
        }
        
        private void Reset()
        {
            _controller = GetComponent<CharacterController>();
        }
    }
}