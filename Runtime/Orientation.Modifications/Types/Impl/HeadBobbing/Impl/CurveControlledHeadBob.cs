// using Depra.CharacterControl.Runtime.Modules.HeadBob.Abstract;
// using UnityEngine;
//
// namespace Depra.CharacterControl.Runtime.Modules.HeadBob.Impl
// {
//     public class CurveControlledHeadBob : HeadBobBase
//     {
//         private readonly float _horizontalRange;
//         private readonly float _verticalRange;
//         private readonly float _ratio;
//
//         public AnimationCurve Curve = new(
//             new Keyframe(0f, 0f), new Keyframe(0.5f, 1f),
//             new Keyframe(1f, 0f), new Keyframe(1.5f, -1f),
//             new Keyframe(2f, 0f)); // sin curve for head bob
//
//         private float _cyclePositionX;
//         private float _cyclePositionY;
//         private float _baseInterval;
//         private Vector3 _originalCameraPosition;
//         private float _time;
//
//         public override void Apply()
//         {
//             UpdateBobbing();
//         }
//
//         public CurveControlledHeadBob(float horizontalRange = 0.33f, float verticalRange = 0.33f, float ratio = 1f)
//         {
//             _horizontalRange = horizontalRange;
//             _verticalRange = verticalRange;
//             _ratio = ratio;
//         }
//
//         protected override void UpdateBobbing()
//         {
//             var xPosition = Head.position.x + (Curve.Evaluate(_cyclePositionX) * _horizontalRange);
//             var yPos = Head.position.y + (Curve.Evaluate(_cyclePositionY) * _verticalRange);
//
//             _cyclePositionX += (speed * Time.deltaTime) / _baseInterval;
//             _cyclePositionY += ((speed * Time.deltaTime) / _baseInterval) * _ratio;
//
//             if (_cyclePositionX > _time)
//             {
//                 _cyclePositionX -= _time;
//             }
//
//             if (_cyclePositionY > _time)
//             {
//                 _cyclePositionY -= _time;
//             }
//
//             return new Vector3(xPosition, yPos, 0f);
//         }
//     }
// }