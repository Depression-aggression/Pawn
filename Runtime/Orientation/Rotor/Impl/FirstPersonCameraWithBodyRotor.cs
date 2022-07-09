using Depra.Pawn.Runtime.Orientation.Configuration.Abstract;
using Depra.Pawn.Runtime.Orientation.Configuration.Interfaces;
using Depra.Pawn.Runtime.Orientation.Rotor.Abstract;
using Depra.Pawn.Runtime.Orientation.Targets.Abstract;
using Depra.Pawn.Runtime.Orientation.Targets.Impl;
using UnityEngine;
using UnityEngine.Assertions;

namespace Depra.Pawn.Runtime.Orientation.Rotor.Impl
{
    public class FirstPersonCameraWithBodyRotor : SoloPawnRotor
    {
        [SerializeField] private Transform _bodyOrigin;
        [SerializeField] private Transform _cameraOrigin;
        [SerializeField] private RotorConfigurationScriptable _configuration;
        
        protected override IOrientationLayerConfiguration Configuration => _configuration;

        private void Awake()
        {
            Assert.IsNotNull(_bodyOrigin);
            Assert.IsNotNull(_cameraOrigin);
            Assert.IsNotNull(_configuration);
            
            Setup();
        }

        public override void UpdateLate()
        {
            OnUpdate(Time.deltaTime);
        }

        protected override OrientationOrigin SetupOrigin()
        {
            var localPositionProvider = new TransformLocalPositionProvider(_cameraOrigin);
            var localRotationProvider = new TransformLocalRotationProvider(_cameraOrigin);
            var rotationProvider = new TransformRotationProvider(_bodyOrigin);
            var origin = new CameraWithBodyOrigin(localPositionProvider, localRotationProvider, rotationProvider);

            return origin;
        }
    }
}