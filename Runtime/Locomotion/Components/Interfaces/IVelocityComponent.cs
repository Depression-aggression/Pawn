using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Components.Interfaces
{
    public interface IVelocityComponent
    {
        float FrameTime { get; }
        
        Vector3 TargetVelocity { get; }
        
        Vector3 CurrentVelocity { get; }
    }
}