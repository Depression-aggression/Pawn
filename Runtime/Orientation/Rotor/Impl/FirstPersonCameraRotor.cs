using Depra.Pawn.Runtime.Orientation.Configuration.Abstract;
using Depra.Pawn.Runtime.Orientation.Configuration.Interfaces;
using Depra.Pawn.Runtime.Orientation.Rotor.Abstract;
using Depra.Pawn.Runtime.Orientation.Targets.Impl;
using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using Depra.Pawn.Runtime.ReadInput.Abstract;
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
        
        private ILocalRotationReceiver _localRotationReceiver;
        
        internal override Transform CameraOrigin => _cameraOrigin;
        internal override ILocalRotationReceiver Receiver => _localRotationReceiver;
        
        protected override IOrientationConfiguration Configuration => _configurator;

        private void Awake()
        {
            _localRotationReceiver = new CameraLocalRotationReceiver(_cameraOrigin);
            Init(_cameraOrigin.localRotation);
        }

        public override void UpdateLate()
        {
            HandleInput(_inputReader.Yaw, _inputReader.Pitch);
        }
    }
}