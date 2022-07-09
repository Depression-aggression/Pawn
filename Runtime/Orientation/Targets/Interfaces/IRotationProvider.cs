using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Targets.Interfaces
{
    public interface IRotationProvider
    {
        Quaternion Rotation { get; set; }
    }
}