using Depra.Pawn.Runtime.UpdateMethod.Abstract;

namespace Depra.Pawn.Runtime.UpdateMethod.Impl
{
    public class EasyPawnBrainInitialization : PawnBrainInitialization
    {
        protected override UpdatablePawnBehavior[] GetBehaviors() =>
            gameObject.GetComponentsInChildren<UpdatablePawnBehavior>();
    }
}