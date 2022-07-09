using Depra.Pawn.Runtime.Common;
using Depra.Pawn.Runtime.Orientation.Configuration.Interfaces;
using Depra.Pawn.Runtime.Orientation.Structs;
using Depra.Pawn.Runtime.Orientation.Types.Abstract;
using Depra.Pawn.Runtime.Orientation.Types.Impl;
using UnityEngine;

namespace Depra.Pawn.Runtime.Orientation.Configuration.Impl
{
    [CreateAssetMenu(fileName = "Raw Orientation Type",
        menuName = Constants.FrameworkPath + Constants.ModulePath + "Orientation/Types/Raw", order = 51)]
    internal class RawOrientationTypeConfiguration : ScriptableObject, IOrientationTypeConfiguration
    {
        [SerializeField] private DegreeAxis _yawAxis = new(0f, 0f, false);
        [SerializeField] private DegreeAxis _pithAxis = new(-89f, 89f, true);
        
        public OrientationType ConfigureOrientationType(float initialYaw, float initialPitch)
        {
            _yawAxis.Current = initialYaw;
            _pithAxis.Current = initialPitch;

            var orientation = new RawOrientation(_yawAxis, _pithAxis);

            return orientation;
        }
    }
}