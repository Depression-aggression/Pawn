using Depra.Pawn.Runtime.Orientation.Components.Interfaces;
using Depra.Pawn.Runtime.Orientation.Structs;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Components.Impl
{
    public class OrientationComponent : IOrientationComponent
    {
        public OrientationType OrientationType { get; }
        
        public Quaternion CurrentLocalRotation { get; internal set; }
        
        public BiaxialRotation TargetLocalRotation { get; internal set; }
        
        public OrientationComponent(OrientationType type)
        {
            OrientationType = type;
        }
    }
}