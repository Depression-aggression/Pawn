namespace Depra.Pawn.Runtime.StateMachine.Interfaces
{
    public interface IPawnStateTransition
    {
        IPawnState NextState { get; }

        bool ShouldTransition();
    }
}