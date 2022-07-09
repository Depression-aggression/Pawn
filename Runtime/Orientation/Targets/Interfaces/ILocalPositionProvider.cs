using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Targets.Interfaces
{
    public interface ILocalPositionProvider
    {
        Vector3 LocalPosition { get; set; }
    }
}