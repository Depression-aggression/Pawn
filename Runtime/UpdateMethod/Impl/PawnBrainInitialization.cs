using Depra.Pawn.Runtime.UpdateMethod.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.UpdateMethod.Impl
{
    public abstract class PawnBrainInitialization : MonoBehaviour
    {
        internal void InitializeBrain(PawnBrainBase brain)
        {
            brain.Initialize(GetBehaviors());
        }

        protected abstract UpdatablePawnBehavior[] GetBehaviors();
    }
}