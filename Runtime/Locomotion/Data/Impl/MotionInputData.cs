using System;
using Depra.Pawn.Runtime.Locomotion.Data.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Data.Impl
{
    [Serializable]
    public struct MotionInputData : IMotionInputData
    {
        [field: SerializeField] public Vector3 Velocity { get; set; }

        [field: SerializeField] public Vector3 RawDirection { get; set; }
        
        [field: SerializeField] public Vector3 TransformedDirection { get; set; }
        
        public MotionInputData(Vector3 velocity, Vector3 rawDirection, Vector3 transformedDirection, bool isGrounded)
        {
            Velocity = velocity;
            RawDirection = rawDirection;
            TransformedDirection = transformedDirection;
        }
        
        public MotionInputData(IMotionInputData data)
        {
            Velocity = data.Velocity;
            RawDirection = data.RawDirection;
            TransformedDirection = data.TransformedDirection;
        }
    }
}