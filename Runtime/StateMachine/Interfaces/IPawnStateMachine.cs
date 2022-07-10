using JetBrains.Annotations;

namespace Depra.Pawn.Runtime.StateMachine.Interfaces
{
    [PublicAPI]
    public interface IPawnStateMachine
    {
        void Tick();

        void ChangeState(IPawnState state);

        bool NeedTransition(out IPawnState nextState);

        void AddTransition(IPawnState from, IPawnState to, IPawnStateTransition transition);

        void AddAnyTransition(IPawnState to, IPawnStateTransition transition);
    }
}