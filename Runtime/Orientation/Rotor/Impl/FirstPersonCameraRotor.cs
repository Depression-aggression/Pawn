using Depra.Pawn.Runtime.Modules.ReadInput.Abstract;
using Depra.Pawn.Runtime.Orientation.Rotor.Abstract;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Rotor.Impl
{
    /// <summary>
    /// A simple FPP (First Person Perspective) camera rotation script.
    /// Like those found in most FPS (First Person Shooter) games.
    /// </summary>
    public class FirstPersonCameraRotor : PawnRotor
    {
        [SerializeField] private Transform _cameraOrigin;
        [SerializeField] private RotorInputReader _inputReader;
        [SerializeField] private RotorConfigurator _configurator;

        public override Vector3 CameraPosition => _cameraOrigin.position;
        
        protected override OrientationType Orientation { get; set; }

        private void Awake()
        {
            var initialCameraRotation = _cameraOrigin.localRotation;
            Orientation =_configurator.SetupOrientation(initialCameraRotation.x, initialCameraRotation.y);
        }

        private void Update()
        {
            var verticalRotation = Orientation.CalculateVerticalRotation(_inputReader.Pitch);
            var horizontalRotation = Orientation.CalculateHorizontalRotation(_inputReader.Yaw);
            var rotation = horizontalRotation * verticalRotation;

            UpdateCameraRotation(rotation);
        }

        protected override void ApplyCameraRotation()
        {
            _cameraOrigin.localRotation = CameraRotation;
        }
    }
}