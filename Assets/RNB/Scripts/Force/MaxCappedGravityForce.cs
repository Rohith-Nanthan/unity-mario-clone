using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Force
{
    /// <summary>
    /// Same as <see cref="InfiniteGravityForce"/> but insted of increasing indefinitely, it
    /// has a max cap.
    /// <br/>Author: rohith.nanthan
    /// </summary>
    public class MaxCappedGravityForce : InfiniteGravityForce
    {
        [SerializeField] private float _maxCapForGravityForceAlongY;

        protected override void FixedUpdate()
        {
            if (CurrentGravityForceAlongY >= _maxCapForGravityForceAlongY)
            {
                return;
            }

            base.FixedUpdate();
        }
    }
}
