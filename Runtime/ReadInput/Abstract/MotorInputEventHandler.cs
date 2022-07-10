using System;
using UnityEngine;

namespace Depra.Pawn.Runtime.ReadInput.Abstract
{
    public abstract class MotorInputEventHandler : MonoBehaviour
    {
        /// <summary>
        /// Fired when the jump input is pressed - i.e. on key down.
        /// </summary>
        public event Action JumpPressed;

        /// <summary>
        /// Fired when the sprint input is started.
        /// </summary>
        public event Action SprintStarted;

        /// <summary>
        /// Fired when the sprint input is disengaged.
        /// </summary>
        public event Action SprintEnded;
    }
}