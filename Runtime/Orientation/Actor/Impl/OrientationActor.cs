using Depra.Pawn.Runtime.Orientation.Structs;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Actor.Impl
{
    public class OrientationComponent
    {
        public OrientationType OrientationType { get; }
        
        public BiaxialRotation TargetLocalRotation { get; internal set; }
        
        public Quaternion CurrentLocalRotation { get; set; }

        public OrientationComponent(OrientationType type)
        {
            OrientationType = type;
        }
    }
}