using Depra.Pawn.Runtime.Orientation.Data;
using Depra.Pawn.Runtime.Orientation.Rotor.Abstract;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using Depra.Pawn.Runtime.Orientation.Types.Impl;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Rotor.Impl
{
    [CreateAssetMenu(fileName = "Rotor Configurator", menuName = "Depra/Character/Orientation/Raw", order = 51)]
    public class RawRotorConfiguration : RotorConfigurator
    {
        [SerializeField] private DegreeAxis _yawAxis = new(0f, 0f, false);
        [SerializeField] private DegreeAxis _pithAxis = new(-89f, 89f, true);

        public override OrientationType SetupOrientation(float initialYaw, float initialPitch)
        {
            _yawAxis.Current = initialYaw;
            _pithAxis.Current = initialPitch;
            
            var orientation = new RawOrientation(_yawAxis, _pithAxis);

            return orientation;
        }
    }
}