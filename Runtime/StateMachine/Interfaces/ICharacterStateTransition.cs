namespace Depra.Pawn.Runtime.StateMachine.Interfaces
{
    public interface ICharacterStateTransition
    {
        IPawnState NextState { get; }

        bool ShouldTransition();
    }
}