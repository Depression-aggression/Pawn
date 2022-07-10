using Depra.Pawn.Runtime.Locomotion.Extensions.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Extensions.Abstract
{
    public abstract class LocomotionPhysicsExtension : MonoBehaviour, ILocomotionPhysicsExtension
    {
        public abstract void OnUpdatePhysics();
    }
}