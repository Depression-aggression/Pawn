using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Targets.Interfaces
{
    public interface IVelocityReceiver
    {
        void SetRelativeVelocity(Vector3 newVelocity);
    }
}