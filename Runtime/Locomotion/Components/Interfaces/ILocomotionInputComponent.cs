using Depra.Pawn.Runtime.Locomotion.Components.Impl;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Components.Interfaces
{
    public interface ILocomotionInputComponent
    {
        Vector3 RawDirection { get; }
        
        Vector3 TransformedDirection { get; }

        LocomotionInputFlags GetRawData();
    }
}