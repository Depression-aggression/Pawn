using System;
using Depra.Pawn.Runtime.Orientation.Modifications.HeadTilt.Impl;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadTilt.Abstract
{
    [Serializable]
    public abstract class HeadTiltBase
    {
        protected HeadTiltSettings Settings { get; private set; }

        public abstract Quaternion CalculateTiltRotation(Quaternion previousLocalRotation, LastTwoDirections directions, float frameTime);

        protected HeadTiltBase(HeadTiltSettings settings)
        {
            Settings = settings;
        }
    }
}