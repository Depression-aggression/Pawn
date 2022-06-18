using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Gravity.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Gravity.Impl
{
    public class BasicGravityCalculator : GravityCalculator
    {
        private readonly float _timeStep;
        
        public override Vector3 ApplyGravity(Vector3 previousVelocity)
        {
            previousVelocity.y -= Gravity * _timeStep;
            return previousVelocity;
        }

        public override Vector3 SetGroundedGravity(Vector3 previousVelocity)
        {
            previousVelocity.y = -Gravity;
            return previousVelocity;
        }

        public BasicGravityCalculator(float gravityConstant, float timeStep) : base(gravityConstant)
        {
            _timeStep = timeStep;
        }
    }
}