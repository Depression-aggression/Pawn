using Depra.Pawn.Runtime.Locomotion.Targets.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Targets.Impl
{
    internal class TransformBasedVelocityReceiver : VelocityReceiver
    {
        public override void SetRelativeVelocity(Vector3 newVelocity)
        {
            var translation = newVelocity * Time.deltaTime;
            transform.Translate(translation);
        }
    }
}