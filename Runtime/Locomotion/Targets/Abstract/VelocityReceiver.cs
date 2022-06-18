using JetBrains.Annotations;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Targets.Abstract
{
    [PublicAPI]
    internal abstract class VelocityReceiver : MonoBehaviour
    {
        public abstract void SetVelocity(Vector3 newVelocity);

        public abstract void AddVelocity(Vector3 additionalVelocity);
    }
}