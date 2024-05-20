using RNB.Core.Interfaces;
using RNB.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Collectables
{
    public class CollectablesConsumerForEnteringObject : MonoBehaviour
    {
        private ICollectable _collectable;
        [SerializeField] private MonoBehaviour _collectableComponent;

#if UNITY_EDITOR
        [SerializeField, ReadOnlyInInspector] private GameObject _lastEnteredObject;
        [SerializeField, ReadOnlyInInspector] private GameObject _lastFetchedInventory;
#endif

        private void Awake()
        {
            _collectable = _collectableComponent as ICollectable;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
#if UNITY_EDITOR
            _lastEnteredObject = collider.gameObject;
#endif
            IInventory inventory = collider.GetComponent<IInventory>();
            if (inventory != null)
            {
#if UNITY_EDITOR
                _lastFetchedInventory = collider.gameObject;
#endif
                _collectable.Collect(inventory);
            }
        }
    }
}
