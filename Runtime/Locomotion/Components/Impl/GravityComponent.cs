using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Components.Impl
{
    public class GravityComponent : IGravityComponent
    {
        public float Mass { get; set; }
        
        public float GravityMultiplier { get; }
        
        public Vector3 Position { get; set; }
        
        public Vector3 GravityForce { get; set; }

        public GravityComponent(float gravityMultiplier = 1f)
        {
            GravityMultiplier = gravityMultiplier;
        }
    }
}