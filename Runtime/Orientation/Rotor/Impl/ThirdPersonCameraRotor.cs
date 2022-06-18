using System;
using Depra.Pawn.Runtime.Update.Abstract;
using Depra.Pawn.Runtime.Control.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Rotor.Impl
{
    public class ThirdPersonCameraRotor : UpdatablePawnComponent
    {
        [SerializeField] private Transform _cameraOrigin;
        [SerializeField] private Transform _cameraTarget;

        [Range(0f, 1f)] [SerializeField] private float _positionSmoothing = 0.02f;
        [Range(0f, 1f)] [SerializeField] private float _rotationSmoothing = 0.01f;

        public override event Action Updated;

        public override void Tick(float frameTime)
        {
            _cameraOrigin.position = Vector3.Lerp(_cameraOrigin.position, _cameraTarget.position, _positionSmoothing);
            _cameraOrigin.rotation = Quaternion.Lerp(_cameraOrigin.rotation, _cameraTarget.rotation, _rotationSmoothing);
        }
    }
}