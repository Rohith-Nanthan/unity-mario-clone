using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RNB.Utils;
using RNB.Core.Interfaces;

namespace RNB.Core
{
    /// <summary>
    /// It holds a FSM and initializes it to default state.
    /// <br/>Author: rohith.nanthan
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FSM_SwitcherBase<T> : MonoBehaviour, IInitializable where T : Enum
    {
        [SerializeField] private T _defaultInitialState;

#if UNITY_EDITOR
        [field: SerializeField, ReadOnlyInInspector]
#endif
        public FSM<T> Fsm { get; private set; } = new FSM<T>();

        public virtual void Init()
        {
            Fsm.SetInitialState(_defaultInitialState);
        }

    }
}
