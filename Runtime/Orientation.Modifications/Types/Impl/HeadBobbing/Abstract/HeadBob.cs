using System;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadBobbing.Impl;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadBobbing.Abstract
{
    [Serializable]
    public abstract class HeadBob
    {
        protected HeadBobSettings Settings { get; private set; }

        public abstract Vector3 CalculateBobbing(Vector3 previousLocalPosition, Vector2 motionDirection, float frameTime);

        protected HeadBob(HeadBobSettings settings)
        {
            Settings = settings;
        }
    }
}