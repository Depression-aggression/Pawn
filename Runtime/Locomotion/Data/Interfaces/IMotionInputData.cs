using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Data.Interfaces
{
    public interface IMotionInputData
    {
        Vector3 Velocity { get; set; }

        Vector3 RawDirection { get; set; }
        
        Vector3 TransformedDirection { get; set; }
    }
}