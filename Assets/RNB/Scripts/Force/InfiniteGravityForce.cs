using RNB.Core;
using RNB.Core.Interfaces;
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
    public class InfiniteGravityForce : MonoBehaviour, IForce
    {
        [SerializeField] private bool _autoEnableGravityAtStart;

        [SerializeField, Min(0)] private float _startingGravityForceAlongY = 5f;
        [SerializeField, Min(0)] private float _acclerationDueToGravity = 9.8f;

        #region IForce
        public float CurrentGravityForceAlongY { get; private set; }
        public Vector2 CurrentGravityForce
        {
            get
            {
                PreviousForce = LastCalculatedForce;
                LastCalculatedForce = new Vector2(0f, -CurrentGravityForceAlongY);
                return LastCalculatedForce;
            }
        }

        public Vector2 PreviousForce { get; private set; }
        public Vector2 LastCalculatedForce { get; private set; }
        public Vector2 CurrentForce => CurrentGravityForce;
        #endregion

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

        [ContextMenu("Enable Gravity")]
        public void EnableGravity()
        {
            CurrentGravityForceAlongY = _startingGravityForceAlongY;
            enabled = true;
        }

        [ContextMenu("Disable Gravity")]
        public void DisableGravity()
        {
            CurrentGravityForceAlongY = 0f;
            enabled = false;
        }
    }
}
