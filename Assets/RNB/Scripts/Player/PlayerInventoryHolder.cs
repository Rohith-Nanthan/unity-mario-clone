using RNB.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player
{
    public class PlayerInventoryHolder : MonoBehaviour, IInventoryHolder
    {
        public IHealth Health { get; private set; }
        public IInventory Inventory { get; private set; }
        
        [SerializeField] private PlayerHealthScriptable _playerHealth;
        [SerializeField] private PlayerInventoryScriptable _playerInventory;

        private void Awake()
        {
            Health = _playerHealth as IHealth;
            Inventory = _playerInventory as IInventory;
        }
    }
}
