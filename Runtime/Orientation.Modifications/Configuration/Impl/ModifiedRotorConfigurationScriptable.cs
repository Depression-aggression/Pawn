using System.Linq;
using Depra.Pawn.Runtime.Common;
using Depra.Pawn.Runtime.Orientation.Configuration.Abstract;
using Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Abstract;
using Depra.Pawn.Runtime.Orientation.Modifications.Systems;
using Depra.Pawn.Runtime.Orientation.Rotor.Interfaces;
using Depra.Pawn.Runtime.Orientation.Targets.Interfaces;
using Depra.Pawn.Runtime.ReadInput.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Modifications.Configuration.Impl
{
    [CreateAssetMenu(fileName = "Modified Rotor Configuration",
        menuName = Constants.FrameworkPath + Constants.ModulePath + "Orientation/Rotor/Modified", order = 51)]
    public class ModifiedRotorConfigurationScriptable : RotorConfigurationScriptable
    {
        [SerializeField] private RotorConfigurationScriptable _rawConfiguration;
        [SerializeField] private OrientationModificationConfigurationScriptable _modificationConfig;
        [SerializeField] private LocomotionInputReader _locomotionInputReader;

        public override void ConfigureLayer(IOrientationLayer layer, float initialYaw, float initialPitch)
        {
            _rawConfiguration.ConfigureLayer(layer, initialYaw, initialPitch);

            var allModifications = _modificationConfig.GetAllModifications().ToArray();
            var locomotionOrientationInfluenceSystem =
                new LocomotionOrientationInfluenceSystem(_locomotionInputReader, allModifications);

            var rotationProviders = layer.Origins.ToArray<ILocalRotationProvider>();
            var rotationModifications = _modificationConfig.GetRotationModifications();
            var orientationModificationSystem =
                new OrientationOriginRotationModificationSystem(rotationProviders, rotationModifications);

            var originPositionProviders = layer.Origins.ToArray<ILocalPositionProvider>();
            var positionModifications = _modificationConfig.GetPositionModifications();
            var orientationOriginPositionModificationSystem =
                new OrientationOriginPositionModificationSystem(originPositionProviders, positionModifications);

            layer.AddSystem(locomotionOrientationInfluenceSystem);
            layer.AddSystem(orientationModificationSystem);
            layer.AddSystem(orientationOriginPositionModificationSystem);
        }
    }
}