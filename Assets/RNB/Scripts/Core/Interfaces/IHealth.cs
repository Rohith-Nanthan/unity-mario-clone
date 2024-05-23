using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Core.Interfaces
{
    /// <summary>
    /// Author: rohith.nanthan
    /// </summary>
    public interface IHealth
    {
        public int PreviousHealth { get; }
        public int CurrentHealth { get; }

        public int MaxHealth { get; }

        public int IncreaseHealth(int healthToAdd);
        public int DecreaseHealth(int healthToRemove);

        /// <summary>
        /// Invoked when health inreases or decreases
        /// <br/> Param 1 - Previous Health
        /// <br/> Param 2 - Current Health
        /// </summary>
        public event Action<int, int> OnHealthChanged;
    }
}
