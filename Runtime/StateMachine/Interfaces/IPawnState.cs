namespace Depra.Pawn.Runtime.StateMachine.Interfaces
{
    public interface IPawnState
    {
        void Tick();
        
        void Enter();
        
        void Exit();
    }
}