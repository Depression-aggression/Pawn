using UnityEngine;

namespace Depra.Pawn.Runtime.Components.GroundCheck.Abstract
{
    public abstract class GroundChecker : MonoBehaviour
    {
        public bool IsGrounded { get; protected set; }
        
        public bool WasGroundedLastFrame { get; protected set; }

        public abstract void Check();
    }
}