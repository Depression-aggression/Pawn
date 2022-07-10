using Depra.Pawn.Runtime.Modifications.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Types.Interfaces
{
    public interface IVelocityModification : IPawnModification
    {
        Vector3 Modify(Vector3 velocity);
    }
}