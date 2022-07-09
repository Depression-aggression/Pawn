using System;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadBobbing.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadBobbing.Impl
{
    [Serializable]
    public class BasicHeadBob : HeadBob
    {
        private float _headBobTimer;

        public override Vector3 CalculateBobbing(Vector3 previousLocalPosition, Vector2 motionDirection,
            float frameTime)
        {
            if (Mathf.Abs(motionDirection.x) > 0.1f || Mathf.Abs(motionDirection.y) > 0.1f)
            {
                _headBobTimer += Settings.Speed * frameTime;
                var localPosition = IncreaseBobbing(previousLocalPosition);

                return localPosition;
            }
            else
            {
                _headBobTimer = 0f;
                var localPosition = DecreaseBobbing(previousLocalPosition, frameTime);

                return localPosition;
            }
        }
        
        public BasicHeadBob(HeadBobSettings settings) : base(settings)
        {
        }

        private Vector3 IncreaseBobbing(Vector3 headPosition)
        {
            headPosition = new Vector3(
                headPosition.x,
                Settings.DefaultHeight + Mathf.Sin(_headBobTimer) * Settings.Amount,
                headPosition.z);

            return headPosition;
        }

        private Vector3 DecreaseBobbing(Vector3 headPosition, float frameTime)
        {
            headPosition = new Vector3(
                headPosition.x,
                Mathf.Lerp(headPosition.y, Settings.DefaultHeight, Settings.Speed * frameTime),
                headPosition.z);

            return headPosition;
        }
    }
}