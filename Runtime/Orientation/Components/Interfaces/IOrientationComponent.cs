using Depra.Pawn.Runtime.Orientation.Structs;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Components.Interfaces
{
    public interface IOrientationComponent
    {
        OrientationType OrientationType { get; }
        
        Quaternion CurrentLocalRotation { get; }
        
        BiaxialRotation TargetLocalRotation { get; }
    }
}