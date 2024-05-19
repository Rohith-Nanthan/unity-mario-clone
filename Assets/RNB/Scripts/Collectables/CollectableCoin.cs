using RNB.Core.Interfaces;
using RNB.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Collectables
{
    public class CollectableCoin : MonoBehaviour, ICollectable
    {
        [SerializeField] private GameObject _objectToDestroyOnCollection;
        [SerializeField] private int _scoreToAdd;

        public event Action OnCollectionSucceeded;
        public event Action OnCollectionFailed;

#if UNITY_EDITOR
        [SerializeField, ReadOnlyInInspector] private GameObject _lastEnteredObject;
        [SerializeField, ReadOnlyInInspector] private GameObject _lastFetchedInventory;
#endif

        private void OnTriggerEnter2D(Collider2D collider)
        {
#if UNITY_EDITOR
            _lastEnteredObject = collider.gameObject;
#endif
            IInventory inventory = collider.GetComponent<IInventory>();
            if (inventory!=null)
            {
#if UNITY_EDITOR
                _lastFetchedInventory = collider.gameObject;
#endif
                Collect(inventory);
            }
        }

        public void Collect(IInventory inventory)
        {
            inventory.AddScore(_scoreToAdd);
            Destroy(_objectToDestroyOnCollection);
            OnCollectionSucceeded?.Invoke();
        }
    }
}
