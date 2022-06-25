using System;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadBobbing.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.HeadBobbing.Impl
{
    [Serializable]
    public class BasicHeadBob : HeadBob
    {
        private float _headBobTimer;
        private float _defaultPositionY;

        public BasicHeadBob(HeadBobSettings settings, float defaultPositionY) : base(settings)
        {
            _defaultPositionY = defaultPositionY;
        }

        public override Vector3 CalculateBobbing(Vector3 previousLocalPosition, Vector2 motionDirection, float frameTime)
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
        
        private Vector3 IncreaseBobbing(Vector3 headPosition)
        {
            headPosition = new Vector3(
                headPosition.x,
                _defaultPositionY + Mathf.Sin(_headBobTimer) * Settings.Amount,
                headPosition.z);

            return headPosition;
        }

        private Vector3 DecreaseBobbing(Vector3 headPosition, float frameTime)
        {
            headPosition = new Vector3(
                headPosition.x,
                Mathf.Lerp(headPosition.y, _defaultPositionY, Settings.Speed * frameTime),
                headPosition.z);

            return headPosition;
        }
    }
}