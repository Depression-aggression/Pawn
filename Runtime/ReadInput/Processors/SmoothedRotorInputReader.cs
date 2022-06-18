using System;
using Depra.Pawn.Runtime.Modules.ReadInput.Abstract;
using Depra.Pawn.Runtime.Orientation.Modifications.Interfaces;
using Depra.Pawn.Runtime.Orientation.Modifications.Smoothing;
using UnityEngine;

namespace Depra.Pawn.Runtime.Modules.ReadInput.Processors
{
    [CreateAssetMenu(fileName = "Smoothed Look Input", menuName = "Depra/Character/Input/Smoothed Look", order = 51)]
    public class SmoothedRotorInputReader : RotorInputReader
    {
        [SerializeField] private float _sensitivity;
        [SerializeField] private RotorInputReader _inputReader;

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