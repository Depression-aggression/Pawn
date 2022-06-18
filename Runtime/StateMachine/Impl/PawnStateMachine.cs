using System;
using System.Collections.Generic;
using Depra.Pawn.Runtime.StateMachine.Interfaces;
using UnityEngine;

namespace Depra.Pawn.Runtime.StateMachine.Impl
{
    public class PawnStateMachine : IPawnStateMachine
    {
        private IPawnState _currentState;

        private readonly Dictionary<Type, List<CharacterStateTransition>> _transitions = new();
        private List<CharacterStateTransition> _currentTransitions = new();
        private readonly List<CharacterStateTransition> _anyTransitions = new();
        
        private static readonly List<CharacterStateTransition> EmptyTransitions = new();

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

        public void AddTransition(IPawnState from, IPawnState to, CharacterStateTransition transition)
        {
            var sourceStateType = from.GetType();

            if (_transitions.TryGetValue(sourceStateType, out var transitions) == false)
            {
                transitions = new List<CharacterStateTransition>();
                _transitions[sourceStateType] = transitions;
            }

            transitions.Add(transition);
        }

        public void AddAnyTransition(IPawnState to, CharacterStateTransition transition)
        {
            _anyTransitions.Add(transition);
        }
    }
}