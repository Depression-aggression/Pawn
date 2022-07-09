using System;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadTilt.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadTilt.Impl
{
    [Serializable]
    public class BasicHeadTilt : HeadTiltBase
    {
        public override Quaternion CalculateTiltRotation(Quaternion previousLocalRotation, LastTwoDirections directions,
            float frameTime)
        {
            var targetAngle = 0.0f;

            var tiltDirection = directions.Direction.x;
            var previousTiltDirection = directions.PreviousDirection.x;

            if (tiltDirection != 0f)
            {
                targetAngle = tiltDirection * Settings.MaxRotation;
            }
            
            var currentRate = Settings.Rate;
            if (previousTiltDirection != 0f)
            {
                if (tiltDirection > 0 && tiltDirection < previousTiltDirection ||
                    tiltDirection < 0 && tiltDirection > previousTiltDirection)
                {
                    currentRate = Settings.ReturnRate;
                }
            }

            var t = currentRate * frameTime;
            var tiltRotation = Quaternion.Lerp(previousLocalRotation, Quaternion.Euler(0, 0, targetAngle), t);
            tiltRotation.x = 0;
            tiltRotation.y = 0;
            
            return tiltRotation;
        }

        public BasicHeadTilt(HeadTiltSettings settings) : base(settings)
        {
        }
    }
}