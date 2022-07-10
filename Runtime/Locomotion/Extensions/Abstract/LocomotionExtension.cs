using Depra.Pawn.Runtime.Locomotion.Extensions.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.Locomotion.Extensions.Abstract
{
    public abstract class LocomotionExtension : MonoBehaviour, ILocomotionExtension
    {
        public abstract void OnUpdate();
    }
}