using Depra.Pawn.Runtime.UpdateMethod.Abstract;
using UnityEngine;

namespace Depra.Pawn.Runtime.UpdateMethod.Impl
{
    public class OptimizedPawnBrainInitialization : PawnBrainInitialization
    {
        [SerializeField] private UpdatablePawnBehavior[] _behaviors;

        protected override UpdatablePawnBehavior[] GetBehaviors() => _behaviors;
    }
}