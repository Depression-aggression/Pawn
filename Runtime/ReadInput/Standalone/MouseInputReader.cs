using System;
using Depra.Pawn.Runtime.Common;
using Depra.Pawn.Runtime.ReadInput.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.ReadInput.Standalone
{
    [CreateAssetMenu(fileName = "Mouse Input", menuName = Constants.FrameworkPath + Constants.ModulePath + "Input/Mouse", order = 51)]
    public class MouseInputReader : OrientationInputReader
    {
        [SerializeField] private string _yawAxisName = "Mouse X";
        [SerializeField] private string _pitchAxisName = "Mouse Y";
        
        public override float Yaw => Input.GetAxis(_yawAxisName);
        
        public override float Pitch => Input.GetAxis(_pitchAxisName);
        
        public override bool IsZoomPressed()
        {
            throw new NotImplementedException();
        }
    }
}