using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Core.Interfaces
{
    public interface IInventory
    {
        public IHealth Health { get; }

        public int Score { get; }

        public int AddScore(int scoreToAdd);
    }
}
