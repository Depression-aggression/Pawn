using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.StateMachine.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.StateMachine.Impl
{
    public class PawnStateMachine : IPawnStateMachine
    {
        private readonly Dictionary<Type, List<IPawnStateTransition>> _transitions;
        private readonly List<IPawnStateTransition> _anyTransitions;
        
        private List<IPawnStateTransition> _currentTransitions;
        private IPawnState _currentState;
        
        private static readonly List<IPawnStateTransition> EmptyTransitions = new();

        public void Tick()
        {
            if (NeedTransition(out var nextState))
            {
                ChangeState(nextState);
            }

            _currentState?.Tick();
        }

        public void ChangeState(IPawnState state)
        {
            if (state == _currentState)
            {
                return;
            }

            _currentState?.Exit();

            _currentState = state;

            _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions);
            _currentTransitions ??= EmptyTransitions;

            _currentState?.Enter();
        }

        public bool NeedTransition(out IPawnState nextState)
        {
            foreach (var transition in _anyTransitions)
            {
                if (transition.ShouldTransition())
                {
                    nextState = transition.NextState;
                    return true;
                }
            }

            foreach (var transition in _currentTransitions)
            {
                if (transition.ShouldTransition())
                {
                    nextState = transition.NextState;
                    return true;
                }
            }

            nextState = null;
            return false;
        }

        public void AddTransition(IPawnState from, IPawnState to, IPawnStateTransition transition)
        {
            var sourceStateType = from.GetType();

            if (_transitions.TryGetValue(sourceStateType, out var transitions) == false)
            {
                transitions = new List<IPawnStateTransition>();
                _transitions[sourceStateType] = transitions;
            }

            transitions.Add(transition);
        }

        public void AddAnyTransition(IPawnState to, IPawnStateTransition transition)
        {
            _anyTransitions.Add(transition);
        }

        public PawnStateMachine()
        {
            _transitions = new Dictionary<Type, List<IPawnStateTransition>>();
            _currentTransitions = new List<IPawnStateTransition>();
            _anyTransitions = new List<IPawnStateTransition>();
        }
    }
}