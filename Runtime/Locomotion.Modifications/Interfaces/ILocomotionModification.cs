using Depra.Pawn.Runtime.Locomotion.Motor.Interfaces;
using Depra.Pawn.Runtime.Modifications.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Interfaces
{
    public interface ILocomotionModification : IPawnModification
    {
        Vector3 Modify(ILocomotionContext context);
    }
}