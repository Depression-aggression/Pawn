using Depra.Pawn.Runtime.Orientation.Structs;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Types.Impl
{
    public class RawOrientation : OrientationType
    {
        private DegreeAxis _yaw;
        private DegreeAxis _pitch;

        public override Quaternion CalculateHorizontalRotation(float yaw)
        {
            _yaw.Current += yaw;
            var horizontalRotation = Quaternion.AngleAxis(_yaw.Current, Vector3.up);

            return horizontalRotation;
        }

        public override Quaternion CalculateVerticalRotation(float pitch)
        {
            _pitch.Current -= pitch;
            var verticalRotation = Quaternion.AngleAxis(_pitch.Current, Vector3.right);

            return verticalRotation;
        }

        public RawOrientation(DegreeAxis yaw, DegreeAxis pitch)
        {
            _yaw = yaw;
            _pitch = pitch;
        }
    }
}