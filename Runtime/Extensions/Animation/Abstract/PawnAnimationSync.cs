using UnityEngine;

namespace Depra.Pawn.Runtime.Extensions.Animation.Abstract
{
    public abstract class PawnAnimationSync : MonoBehaviour
    {
        protected void Update()
        {
            UpdateAnimations();
        }
        
        protected abstract void UpdateAnimations();
    }
}