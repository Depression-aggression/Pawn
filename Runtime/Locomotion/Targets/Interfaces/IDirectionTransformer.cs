using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Targets.Interfaces
{
    public interface IDirectionTransformer
    {
        Vector3 WorldToLocalDirection(Vector3 direction);
    }
}