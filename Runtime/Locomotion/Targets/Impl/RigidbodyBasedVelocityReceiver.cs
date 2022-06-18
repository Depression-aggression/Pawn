using Depra.Pawn.Runtime.Locomotion.Targets.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Targets.Impl
{
    internal class RigidbodyBasedVelocityReceiver : VelocityReceiver
    {
        [SerializeField] private Rigidbody _rigidbody;

        public override void SetVelocity(Vector3 newVelocity) => _rigidbody.velocity = newVelocity;

        public override void AddVelocity(Vector3 additionalVelocity) => _rigidbody.velocity += additionalVelocity;

        private void Reset()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}