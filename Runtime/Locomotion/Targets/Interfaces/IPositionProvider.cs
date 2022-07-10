using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Targets.Interfaces
{
    public interface IPositionProvider
    {
        Vector3 Position { get; set; }
    }
}