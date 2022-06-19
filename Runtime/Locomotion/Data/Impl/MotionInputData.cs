using System;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Data.Impl
{
    [Serializable]
    public struct MotionInputData : IPawnLocomotionInput
    {
        [field: SerializeField] public Vector3 RawDirection { get; set; }
        
        [field: SerializeField] public Vector3 TransformedDirection { get; set; }
        
        public MotionInputData(Vector3 rawDirection, Vector3 transformedDirection)
        {
            RawDirection = rawDirection;
            TransformedDirection = transformedDirection;
        }
        
        public MotionInputData(IPawnLocomotionInput data)
        {
            RawDirection = data.RawDirection;
            TransformedDirection = data.TransformedDirection;
        }
    }
}