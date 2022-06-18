using Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Acceleration.Impl;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Additional.Acceleration.Abstract
{
    /// <summary>
    /// Handles user intended acceleration.
    /// </summary>
    public abstract class Accelerator
    {
        protected float FrameTime { get; }
        
        /// <summary>
        /// Calculates acceleration based on desired speed and direction.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract Vector3 Accelerate(AccelerationParams parameters);

        protected Accelerator(float frameTime)
        {
            FrameTime = frameTime;
        }
    }
}