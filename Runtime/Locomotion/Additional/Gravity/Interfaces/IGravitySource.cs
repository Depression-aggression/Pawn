using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Interfaces
{
    public interface IGravitySource
    {
        Vector3 GetGravity(IGravityComponent gravityComponent);
    }
}