using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Types.Terrestrial.Jumping.Abstract
{
    public abstract class GroundJumpType
    {
        public abstract bool Jumping { get; }

        protected float JumpForce { get; }

        public abstract Vector3 Jump(Vector3 velocity);

        protected GroundJumpType(float force)
        {
            JumpForce = force;
        }
    }
}