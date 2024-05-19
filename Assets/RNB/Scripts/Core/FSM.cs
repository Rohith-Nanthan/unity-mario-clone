using System;
using UnityEngine;

namespace RNB.Core
{
#if UNITY_EDITOR
    [Serializable]
#endif
    public class FSM<T> where T : Enum
    {
#if UNITY_EDITOR
        [field: SerializeField]
#endif
        public T CurrentState { get; private set; }

#if UNITY_EDITOR
        [field: SerializeField]
#endif
        public T PreviousState { get; private set; }

        private bool _isInitialized;

        /// <summary>
        /// Invoked when there is a successful state change
        /// <br/>Param 1 - Previous State
        /// <br/>Param 2 - Current State
        /// </summary>
        public event Action<T, T> OnStateSwitch;

        public void SwitchState(T newState)
        {
            if(!_isInitialized)
            {
                Debug.LogError("Not initalized yet");
                return;
            }

            if (newState.Equals(CurrentState))
            {
                Debug.LogWarning($"Cannot switch to same state: {newState}");
                return;
            }

            PreviousState = CurrentState;
            CurrentState = newState;

            Debug.Log($"Switching state: {PreviousState}, {CurrentState}");
            OnStateSwitch?.Invoke(PreviousState, CurrentState);
        }

        public void SetInitialState(T initialState)
        {
            PreviousState = CurrentState = initialState;
            _isInitialized = true;
            Debug.Log($"Setting initial state: {initialState}");
        }
    }
}
