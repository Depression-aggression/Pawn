using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Additional.Friction.Abstract
{
    /// <summary>
    /// Handles both ground friction and water friction.
    /// </summary>
    public abstract class FrictionCalculator
    {
        private readonly float _frictionConstant;

        /// <summary>
        /// Applies friction to the character, called in both the air and on the ground.
        /// </summary>
        public abstract Vector3 CalculateFriction(Vector3 previousVelocity, bool isGrounded, float frameTime);

        protected float FrictionByFrameTime(float frameTime) => _frictionConstant * frameTime;
        
        protected FrictionCalculator(float frictionConstant)
        {
            _frictionConstant = frictionConstant;
        }
    }
}