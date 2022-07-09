using Depra.Pawn.Runtime.Orientation.Structs;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Actor.Interfaces
{
    public interface IOrientationActor
    {
        OrientationType Type { get; }
        
        BiaxialRotation TargetLocalRotation { get; }
        
        Quaternion CurrentLocalRotation { get; set; }
    }
}