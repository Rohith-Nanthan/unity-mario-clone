using RNB.Core.Interfaces;
using RNB.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Collectables
{
    /// <summary>
    /// Author: rohith.nanthan
    /// </summary>
    public class CollectableCoin : MonoBehaviour, ICollectable
    {
        [SerializeField] private GameObject _objectToDestroyOnCollection;
        [SerializeField] private int _scoreToAdd;

        public event Action OnCollectionSucceeded;
        public event Action OnCollectionFailed;

        public void Collect(IInventory inventory)
        {
            inventory.AddScore(_scoreToAdd);
            OnCollectionSucceeded?.Invoke();
            Destroy(_objectToDestroyOnCollection);
        }
    }
}
