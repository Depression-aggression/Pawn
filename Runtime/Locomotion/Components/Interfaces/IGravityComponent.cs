using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Components.Interfaces
{
    public interface IGravityComponent
    {
        float Mass { get; }
        
        float GravityMultiplier { get; }

        Vector3 Position { get; }
        
        Vector3 GravityForce { get; }
    }
}