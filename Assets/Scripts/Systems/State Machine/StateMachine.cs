using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dynamic
{
    public class StateMachine
    {
        private readonly List<State> states;
        private State currentState;

        public StateMachine()
        {
            states = new List<State>();
        }

        public void AddState(State state)
        {
            if (!states.Contains(state))
            {
                states.Add(state);
                state.Init(this);
            }
            if (currentState == null)
                currentState = state;
        }

        public void RemoveState(State state)
        {
            if (states.Contains(state))
                states.Remove(state);
        }

        public void Tick() => currentState?.OnUpdate();


        public void SwitchState<T>() where T : State
        {
            currentState?.OnExit();

            currentState = states.Find(s => s.GetType() == typeof(T));

            currentState?.OnEnter();
        }
    }
}