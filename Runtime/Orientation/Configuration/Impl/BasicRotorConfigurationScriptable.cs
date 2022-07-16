using Depra.Pawn.Runtime.Common;
using Depra.Pawn.Runtime.Orientation.Components.Impl;
using Depra.Pawn.Runtime.Orientation.Configuration.Abstract;
using Depra.Pawn.Runtime.Orientation.Rotor.Interfaces;
using Depra.Pawn.Runtime.Orientation.Systems.Impl;
using Depra.Pawn.Runtime.ReadInput.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Configuration.Impl
{
    [CreateAssetMenu(fileName = "Rotor Configuration",
        menuName = Constants.FrameworkPath + Constants.ModulePath + "Orientation/Rotor/Basic", order = 51)]
    public class BasicRotorConfigurationScriptable : RotorConfigurationScriptable
    {
        [SerializeField] private OrientationInputReader _inputReader;
        [SerializeField] private OrientationTypeConfigurationScriptable _typeConfiguration;

        public override void ConfigureLayer(IOrientationLayer layer, float initialYaw, float initialPitch)
        {
            var orientationType = _typeConfiguration.ConfigureOrientationType(initialYaw, initialPitch);
            var orientationComponent = new OrientationComponent(orientationType);
            var inputComponent = new OrientationInputComponent();

            var inputSystem = new OrientationInputSystem();
            inputSystem.AddComponent(_inputReader, inputComponent);
            
            var calculationSystem = new OrientationCalculationSystem();
            calculationSystem.AddComponent(inputComponent, orientationComponent);
            
            var applicationSystem = new OrientationApplicationSystem();
            applicationSystem.AddComponent(orientationComponent, layer.Origins);

            layer.AddSystem(inputSystem);
            layer.AddSystem(calculationSystem);
            layer.AddSystem(applicationSystem);
        }
    }
}