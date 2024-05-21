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
    public abstract class InventoryScriptableBase : ScriptableObject, IInventory
    {
#if UNITY_EDITOR
        [field: SerializeField, ReadOnlyInInspector]
#endif
        public int PreviousScore { get; private set; }

#if UNITY_EDITOR
        [SerializeField, ReadOnlyInInspector]
#endif
        private int _currentScore;
        public int CurrentScore
        {
            get => _currentScore;

            set
            {
                if (_currentScore == value)
                {
                    return;
                }

                PreviousScore = CurrentScore;
                _currentScore = value;

                OnScoreChange?.Invoke(PreviousScore, CurrentScore);
            }
        }

        public event Action<int, int> OnScoreChange;

        public int AddScore(int scoreToAdd)
        {
            CurrentScore += scoreToAdd;
            return CurrentScore;
        }
    }
}
