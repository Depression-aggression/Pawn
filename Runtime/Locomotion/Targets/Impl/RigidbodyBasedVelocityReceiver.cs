using Depra.Pawn.Runtime.Locomotion.Targets.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Targets.Impl
{
    internal class RigidbodyBasedVelocityReceiver : VelocityReceiver
    {
        [SerializeField] private Rigidbody _rigidbody;

        public override void SetRelativeVelocity(Vector3 newVelocity)
        {
            _rigidbody.velocity = newVelocity;
            //_rigidbody.AddForce(newVelocity, ForceMode.VelocityChange);
        }
        
        private void Reset()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}