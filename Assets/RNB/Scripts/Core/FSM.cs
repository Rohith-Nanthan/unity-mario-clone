using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Core
{
    public class FSM<T> where T : Enum
    {
        public T CurrentState { get; private set; }
        public T PreviousState { get; private set; }

        /// <summary>
        /// Invoked when there is a successful state change
        /// <br/>Param 1 - Previous State
        /// <br/>Param 2 - Current State
        /// </summary>
        public event Action<T, T> OnStateSwitch;

        public FSM(T initialState)
        {
            PreviousState = CurrentState = initialState;
        }

        public void SwitchState(T newState)
        {
            if (newState.Equals(CurrentState))
            {
                return;
            }

            PreviousState = CurrentState;
            CurrentState = newState;

            OnStateSwitch?.Invoke(PreviousState, CurrentState);
        }
    }
}
