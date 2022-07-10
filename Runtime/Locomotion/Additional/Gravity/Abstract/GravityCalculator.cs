using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Abstract
{
    public abstract class GravityCalculator
    {
        protected float GravityStrength { get; }
        
        public abstract Vector3 CalculateGravity(IGravityComponent gravityComponent);

        public abstract Vector3 CalculateGroundedGravity(IGravityComponent gravityComponent);
        
        protected GravityCalculator(float strength)
        {
            GravityStrength = strength;
        }
    }
}