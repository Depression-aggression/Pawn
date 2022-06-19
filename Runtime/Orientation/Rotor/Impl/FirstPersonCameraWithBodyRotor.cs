using Depra.Pawn.Runtime.Orientation.Rotor.Abstract;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using Depra.Pawn.Runtime.ReadInput.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Rotor.Impl
{
    public class FirstPersonCameraWithBodyRotor : PawnRotor
    {
        [SerializeField] private Transform _bodyOrigin;
        [SerializeField] private Transform _cameraOrigin;
        [SerializeField] private RotorInputReader _inputReader;
        [SerializeField] private RotorConfigurator _configurator;

        public override Vector3 CameraPosition => _cameraOrigin.position;
        protected override OrientationType Orientation { get; set; }

        private void Awake()
        {
            var initialCameraRotation = _cameraOrigin.localRotation;
            Orientation = _configurator.SetupOrientation(initialCameraRotation.x, initialCameraRotation.y);
        }

        public override void UpdateLate()
        {
            var horizontalRotation = Orientation.CalculateHorizontalRotation(_inputReader.Yaw);
            var verticalRotation = Orientation.CalculateVerticalRotation(_inputReader.Pitch);
            
            UpdateBodyRotation(horizontalRotation);
            UpdateCameraRotation(verticalRotation);
        }

        protected override void ApplyCameraRotation()
        {
            _cameraOrigin.localRotation = CameraRotation;
        }

        private void UpdateBodyRotation(Quaternion bodyRotation)
        {
            _bodyOrigin.rotation = bodyRotation;
        }
    }
}