using Depra.Pawn.Runtime.StateMachine.Impl;
using JetBrains.Annotations;

namespace Depra.Pawn.Runtime.StateMachine.Interfaces
{
    [PublicAPI]
    public interface IPawnStateMachine
    {
        void Tick();

        void ChangeState(IPawnState state);

        bool NeedTransition(out IPawnState nextState);

        void AddTransition(IPawnState from, IPawnState to, CharacterStateTransition transition);

        void AddAnyTransition(IPawnState to, CharacterStateTransition transition);
    }
}