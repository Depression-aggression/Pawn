using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Calculation.Types.Terrestrial.Jumping.Abstract
{
    public abstract class JumpType
    {
        public abstract bool Jumping { get; }

        protected float JumpForce { get; }

        public abstract Vector3 Jump(Vector3 velocity);

        protected JumpType(float force)
        {
            JumpForce = force;
        }
    }
}