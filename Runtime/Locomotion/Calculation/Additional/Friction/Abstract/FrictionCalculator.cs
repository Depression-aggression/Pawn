using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Friction.Abstract
{
    /// <summary>
    /// Handles both ground friction and water friction.
    /// </summary>
    public abstract class FrictionCalculator
    {
        private readonly float _friction;
        private readonly float _frameTime;

        protected float Friction => _friction * _frameTime;

        /// <summary>
        /// Applies friction to the character, called in both the air and on the ground.
        /// </summary>
        /// <param name="previousVelocity"></param>
        /// <param name="isGrounded"></param>
        public abstract Vector3 CalculateFriction(Vector3 previousVelocity, bool isGrounded);

        protected FrictionCalculator(float frictionConstant, float frameTime)
        {
            _friction = frictionConstant;
            _frameTime = frameTime;
        }
    }
}