using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Core.Interfaces
{
    public interface IHealth
    {
        public int Health { get; }

        public int MaxHealth { get; }

        public int IncreaseHealth(int healtToAdd);
        public int DecreaseHealth(int healtToRemove);

        /// <summary>
        /// Invoked when health inreases or decreases
        /// <br/> Param 1 - Previous Health
        /// <br/> Param 2 - Current Health
        /// </summary>
        public event Action<int, int> OnHealthChanged;
    }
}
