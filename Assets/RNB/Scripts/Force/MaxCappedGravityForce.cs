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
        [SerializeField] private float _maxCapForGravitySpeed = 30f;

        protected override void FixedUpdate()
        {
            if (CurrentGravitySpeed >= _maxCapForGravitySpeed)
            {
                return;
            }

            base.FixedUpdate();
        }

        public void UpdateMaxCapForGravitySpeed(float newMaxCap) => _maxCapForGravitySpeed = newMaxCap;
    }
}
