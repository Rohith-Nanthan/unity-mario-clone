using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Core.Interfaces
{
    public interface ICollectable
    {
        public void Collect(IInventory inventory);

        public event Action OnCollectionSucceeded;
        public event Action OnCollectionFailed;
    }
}
