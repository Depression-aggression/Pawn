using System;
using Depra.Pawn.Runtime.Common;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Impl.Smoothing;
using Depra.Pawn.Runtime.Orientation.Modifications.Types.Interfaces;
using Depra.Pawn.Runtime.ReadInput.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.ReadInput.Processors
{
    [CreateAssetMenu(fileName = "Smoothed Look Input",
        menuName = Constants.FrameworkPath + Constants.ModulePath + "Input/Smoothed Look", order = 51)]
    public class SmoothedOrientationInputReader : OrientationInputReader
    {
        [SerializeField] private float _sensitivity;
        [SerializeField] private OrientationInputReader _inputReader;

        private IDegreeAxisModification _smoothing;

        public override float Yaw => _smoothing.ModifyInputAxis(_inputReader.Yaw, Time.deltaTime);

        public override float Pitch => _smoothing.ModifyInputAxis(_inputReader.Pitch, Time.deltaTime);

        private void OnEnable()
        {
            _smoothing = new DegreeAxisSmoothing(_sensitivity);
        }

        public override bool IsZoomPressed()
        {
            throw new NotImplementedException();
        }
    }
}