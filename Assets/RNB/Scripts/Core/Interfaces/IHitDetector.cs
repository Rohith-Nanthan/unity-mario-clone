using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Core.Interfaces
{
    /// <summary>
    /// Holds the hit info from the last detection and the status of hit
    /// <br/>Eg: We can have a separate raycaster script that will raycast and store the hitinfo.
    /// <br/>Author: rohith.nanthan
    /// </summary>
    public interface IHitDetector
    {
        public RaycastHit2D LastHitInfo { get; }

        public bool IsHit { get; }

        /// <summary>
        /// Invoked when the hit status change
        /// <br/>Param 1 - Is Hit
        /// </summary>
        public event Action<bool> OnHitStatusChange;
    }
}
