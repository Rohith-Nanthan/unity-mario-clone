using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Core.Interfaces
{
    public interface IInventory
    {
        public int PreviousScore { get; }
        public int CurrentScore { get; }

        public event Action<int, int> OnScoreChange;

        public int AddScore(int scoreToAdd);
    }
}
