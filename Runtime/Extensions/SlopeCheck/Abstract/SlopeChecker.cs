using UnityEngine;

namespace Depra.Pawn.Runtime.Extensions.SlopeCheck.Abstract
{
    public abstract class SlopeChecker : MonoBehaviour
    {
        public abstract float Angle { get; protected set; }
        
        public abstract bool IsSlopeSteep { get; protected set; }
        
        public abstract RaycastHit SlopeHit { get; }

        protected abstract void Check();
    }
}