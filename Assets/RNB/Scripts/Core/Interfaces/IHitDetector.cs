using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Core.Interfaces
{
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
