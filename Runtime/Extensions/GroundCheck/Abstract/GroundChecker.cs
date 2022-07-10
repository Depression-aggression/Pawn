using Depra.Pawn.Runtime.Locomotion.Extensions.Abstract;

namespace Depra.Pawn.Runtime.Extensions.GroundCheck.Abstract
{
    public abstract class GroundChecker : LocomotionExtension
    {
        public bool IsGrounded { get; protected set; }
        
        public bool WasGroundedLastFrame { get; protected set; }

        public override void OnUpdate()
        {
            Check();
        }
        
        protected abstract void Check();
    }
}