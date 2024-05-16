using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Force
{
    /// <summary>
    /// It holds a force value that will keep increasing indefinitely in Fixed Update at
    /// the rate of <see cref="_acclerationDueToGravity"/>. Use <see cref="CurrentGravityForce"/>
    /// to read the gravity force.
    /// <br/>If you want to have a upper limit for gravity force, please use <see cref="MaxCappedGravityForce"/>
    /// <br/>Author: rohith.nanthan
    /// </summary>
    public class InfiniteGravityForce : MonoBehaviour
    {
        [SerializeField] private bool _autoEnableGravityAtStart;

        [SerializeField] private float _startingGravityForceAlongY;
        [SerializeField] private float _acclerationDueToGravity;

        public float CurrentGravityForceAlongY { get; private set; }
        public Vector2 CurrentGravityForce => new Vector2(0f, -CurrentGravityForceAlongY);

        private void Awake()
        {
            if(_autoEnableGravityAtStart)
            {
                EnableGravity();
            }
            else
            {
                DisableGravity();
            }
        }

        protected virtual void FixedUpdate()
        {
            CurrentGravityForceAlongY += _acclerationDueToGravity * Time.deltaTime;
        }

        public void EnableGravity()
        {
            CurrentGravityForceAlongY = _startingGravityForceAlongY;
            enabled = true;
        }

        public void DisableGravity()
        {
            CurrentGravityForceAlongY = 0f;
            enabled = false;
        }
    }
}
