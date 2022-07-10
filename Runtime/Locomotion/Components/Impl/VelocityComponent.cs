using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Components.Impl
{
    public class VelocityComponent : IVelocityComponent
    {
        public float FrameTime { get; set; }
        
        public Vector3 TargetVelocity { get; set; }
        
        public Vector3 CurrentVelocity { get; set; }
    }
}