using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RNB.Utils;
namespace RNB.Core
{
    /// <summary>
    /// Initizlizes the FSM at Awake and exposes all the APIs of FSM
    /// <br/>Author: rohith.nanthan
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FSM_SwitcherBase<T> : MonoBehaviour where T : Enum
    {
        [SerializeField] private T _initialState;

#if UNITY_EDITOR
        [field: SerializeField, ReadOnlyInInspector]
#endif
        public FSM<T> Fsm { get; private set; }

        private void Awake()
        {
            Fsm = new FSM<T>(_initialState);
        }
    }
}
