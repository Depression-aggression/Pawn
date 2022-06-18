using Depra.Pawn.Runtime.StateMachine.Interfaces;

namespace Depra.Pawn.Runtime.StateMachine.States.Abstract
{
    public abstract class PawnState : IPawnState
    {
        public abstract void Tick();

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }
    }
}