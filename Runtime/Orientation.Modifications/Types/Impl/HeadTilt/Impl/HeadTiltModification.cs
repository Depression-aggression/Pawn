using Depra.Pawn.Runtime.Orientation.Modifications.Types.Abstract;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadTilt.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadTilt.Impl
{
    public class HeadTiltModification : OrientationModification<Quaternion>
    {
        private readonly HeadTiltBase _headTilt;

        public override Quaternion Modify(Quaternion previousValue, float timeStep)
        {
            var directions = new LastTwoDirections(MotionDirection, PreviousMotionDirection);
            var tiltRotation = _headTilt.CalculateTiltRotation(previousValue, directions, timeStep);
            var resultRotation = previousValue * tiltRotation;
            
            return resultRotation;
        }

        public HeadTiltModification(HeadTiltBase headTilt)
        {
            _headTilt = headTilt;
        }
    }
}