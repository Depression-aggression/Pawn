using Depra.Pawn.Runtime.Modifications.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Interfaces
{
    public interface IOrientationModification : IPawnModification
    {
        void SetDirection(Vector2 motionDirection);

        void ClearDirection();
    }
}