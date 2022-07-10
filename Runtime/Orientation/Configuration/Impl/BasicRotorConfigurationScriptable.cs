using Depra.Pawn.Runtime.Common;
using Depra.Pawn.Runtime.Orientation.Actor.Impl;
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
        [SerializeField] private RawOrientationTypeConfiguration _typeConfiguration;
        [SerializeField] private OrientationInputReader _inputReader;
        
        public override void ConfigureLayer(IOrientationLayer layer, float initialYaw, float initialPitch)
        {
            var orientationType = _typeConfiguration.ConfigureOrientationType(initialYaw, initialPitch);
            var orientationComponent = new OrientationComponent(orientationType);

            var calculationSystem = new OrientationCalculationSystem(orientationComponent, _inputReader);
            var applicationSystem = new OrientationApplicationSystem();
            applicationSystem.AddComponent(orientationComponent, layer.Origins);
            
            layer.AddSystem(calculationSystem);
            layer.AddSystem(applicationSystem);
        }
    }
}