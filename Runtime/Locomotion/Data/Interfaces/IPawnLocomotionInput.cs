using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Data.Interfaces
{
    public interface IPawnLocomotionInput
    {
        Vector3 RawDirection { get; set; }
        
        Vector3 TransformedDirection { get; set; }
    }
}