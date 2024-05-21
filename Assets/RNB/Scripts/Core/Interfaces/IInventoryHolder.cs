using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Core.Interfaces
{
    //TODO: Name better to suit both Health and Inventory holding
    public interface IInventoryHolder
    {
        public IHealth Health { get; }

        public IInventory Inventory { get; }
    }
}
