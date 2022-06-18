using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Motor.Interfaces
{
    internal interface IDirectionTransformer
    {
        Vector3 TransformDirection(Vector3 direction);
    }
}