using Depra.Pawn.Runtime.Locomotion.Targets.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Targets.Abstract
{
    internal abstract class VelocityReceiver : MonoBehaviour, IVelocityReceiver
    {
        public abstract void SetRelativeVelocity(Vector3 newVelocity);
    }
}