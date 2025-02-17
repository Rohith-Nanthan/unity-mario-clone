using RNB.Core.Interfaces;
using RNB.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Collectables
{
    /// <summary>
    /// It adds the collectable to the inventory of the entering object.
    /// <br/>Eg: Used by coin to be collected when pllayer enters the trigger of coin
    /// <br/>Author: rohith.nanthan
    /// </summary>
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
            IInventoryHolder inventoryHolder = collider.GetComponent<IInventoryHolder>();
            if (inventoryHolder != null)
            {
#if UNITY_EDITOR
                _lastFetchedInventory = collider.gameObject;
#endif
                IInventory inventory = inventoryHolder.Inventory;
                if (inventory == null)
                {
                    Debug.LogError("Inventory not found in inventory holder");
                    return;
                }
                _collectable.Collect(inventory);
            }
        }
    }
}
