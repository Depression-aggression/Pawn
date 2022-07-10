using System;
using System.Collections.Generic;
using System.Linq;
using Depra.Pawn.Runtime.StateMachine.Interfaces;

namespace Depra.Pawn.Runtime.StateMachine.Impl
{
    public class PawnStateTransition : IPawnStateTransition
    {
        private readonly Func<bool>[] _conditions;

        public IPawnState NextState { get; }

        public bool ShouldTransition() => _conditions.All(condition => condition());

        public PawnStateTransition(IPawnState nextState, params Func<bool>[] conditions)
        {
            NextState = nextState;
            _conditions = conditions;
        }

        public PawnStateTransition(IPawnState nextState,
            IReadOnlyList<IPawnStateTransitionCondition> conditions)
        {
            NextState = nextState;

            _conditions = new Func<bool>[conditions.Count];
            for (var i = 0; i < conditions.Count; i++)
            {
                _conditions[i] = conditions[i].IsMet;
            }
        }
    }
}