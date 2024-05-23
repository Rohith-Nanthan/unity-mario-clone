using RNB.Core.Interfaces;
using RNB.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Platforms
{
    /// <summary>
    /// It damages any object that enters into the trigger with <see cref="IInventoryHolder"/>
    /// <br/>Author: rohith.nanthan
    /// </summary>
    public class EnteringObjectDamager : MonoBehaviour
    {
        [SerializeField] private int _damageAmount;

#if UNITY_EDITOR
        [SerializeField, ReadOnlyInInspector] private GameObject _lastEnteredObject;
        [SerializeField, ReadOnlyInInspector] private GameObject _lastFetchedInventory;
#endif

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
                IHealth health = inventoryHolder.Health;
                if (health == null)
                {
                    Debug.LogError("Health not found in inventory holder");
                    return;
                }
                health.DecreaseHealth(_damageAmount);
            }
        }
    }
}
