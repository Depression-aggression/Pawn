using Depra.Pawn.Runtime.Orientation.Modifications.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadBobbing.Abstract
{
    public class HeadBobModification : OrientationModification<Vector3>
    {
        private readonly HeadBob _headBob;
        
        public override Vector3 Modify(Vector3 previousValue, float timeStep)
        {
            var modifiedPosition = _headBob.CalculateBobbing(previousValue, MotionDirection, timeStep);
            return modifiedPosition;
        }

        public HeadBobModification(HeadBob headBob)
        {
            _headBob = headBob;
        }
    }
}