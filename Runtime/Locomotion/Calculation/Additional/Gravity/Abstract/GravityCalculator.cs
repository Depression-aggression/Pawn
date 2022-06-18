using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Gravity.Abstract
{
    public abstract class GravityCalculator
    {
        protected float Gravity { get; }
        
        public abstract Vector3 ApplyGravity(Vector3 previousVelocity);

        public abstract Vector3 SetGroundedGravity(Vector3 previousVelocity);
        
        protected GravityCalculator(float gravityConstant)
        {
            Gravity = gravityConstant;
        }
    }
}