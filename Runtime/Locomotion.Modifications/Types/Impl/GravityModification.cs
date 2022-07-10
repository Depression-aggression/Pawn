using Depra.Pawn.Runtime.Locomotion.Additional.Gravity.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Components.Interfaces;
using Depra.Pawn.Runtime.Locomotion.Modifications.Types.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Modifications.Types.Impl
{
    public class GravityModification : IVelocityModification
    {
        private readonly IGravitySource _gravitySource;
        private readonly IGravityComponent _gravityComponent;
        
        public Vector3 Modify(Vector3 velocity)
        {
            var gravityForce = _gravitySource.GetGravity(_gravityComponent);
            var velocityWithGravity = velocity + gravityForce;

            return velocityWithGravity;
        }

        public GravityModification(IGravitySource gravitySource, IGravityComponent gravityComponent)
        {
            _gravitySource = gravitySource;
            _gravityComponent = gravityComponent;
        }
    }
}