using Depra.Pawn.Runtime.UpdateMethod.Abstract;
using Depra.Pawn.Runtime.UpdateMethod.Interfaces;

namespace Depra.Pawn.Runtime.UpdateMethod.Impl
{
    public class PawnUpdateHandler : IPawnUpdateHandler
    {
        private readonly UpdatablePawnBehavior[] _updateQueue;

        public void UpdateManual()
        {
            foreach (var updatable in _updateQueue)
            {
                if (updatable == false || updatable.isActiveAndEnabled == false)
                {
                    continue;
                }
                
                updatable.UpdateManual();
            }
        }

        public void UpdateFixed()
        {
            foreach (var updatable in _updateQueue)
            {
                if (updatable == false || updatable.isActiveAndEnabled == false)
                {
                    continue;
                }
                
                updatable.UpdateFixed();
            }
        }

        public void UpdateLate()
        {
            foreach (var updatable in _updateQueue)
            {
                if (updatable == false || updatable.isActiveAndEnabled == false)
                {
                    continue;
                }
                
                updatable.UpdateLate();
            }
        }

        public PawnUpdateHandler(UpdatablePawnBehavior[] updateQueue)
        {
            _updateQueue = updateQueue;
        }
    }
}