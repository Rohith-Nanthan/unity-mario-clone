using RNB.Core.Interfaces;
using RNB.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Core
{
    /// <summary>
    /// Author: rohith.nanthan
    /// </summary>
    public abstract class HealthScriptableBase : ScriptableObject, IHealth, IInitializable
    {
        [field: SerializeField] public int MaxHealth { get; private set; }

#if UNITY_EDITOR
        [field: SerializeField, ReadOnlyInInspector]
#endif
        public int PreviousHealth { get; private set; }

#if UNITY_EDITOR
        [SerializeField, ReadOnlyInInspector]
#endif
        private int _currentHealth;
        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                if (_currentHealth == value)
                {
                    return;
                }

                PreviousHealth = CurrentHealth;
                _currentHealth = value;

                OnHealthChanged?.Invoke(PreviousHealth, CurrentHealth);
            }
        }

        public event Action<int, int> OnHealthChanged;

        public int DecreaseHealth(int healtToRemove)
        {
            int newHealth = CurrentHealth - healtToRemove;
            if (newHealth < 0)
            {
                newHealth = 0;
            }

            CurrentHealth = newHealth;
            return CurrentHealth;
        }

        public int IncreaseHealth(int healtToAdd)
        {
            int newHealth = CurrentHealth + healtToAdd;
            if (newHealth > MaxHealth)
            {
                newHealth = MaxHealth;
            }

            CurrentHealth = newHealth;
            return CurrentHealth;
        }

        #region IInitializable
        public void Init()
        {
            PreviousHealth = _currentHealth = MaxHealth;
        }
        #endregion
    }
}
