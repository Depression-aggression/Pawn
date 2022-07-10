using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Types.Abstract
{
    public abstract class LocomotionType
    {
        public abstract Vector3 CalculateVelocity(IVelocityComponent context);

        internal abstract bool AvailableFor(ILocomotionStateComponent state);
    }
}