using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Targets.Interfaces
{
    public interface ILocalRotationProvider
    {
        Quaternion LocalRotation { get; set; }
    }
}