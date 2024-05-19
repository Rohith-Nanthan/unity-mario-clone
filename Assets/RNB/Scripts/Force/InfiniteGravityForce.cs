using RNB.Core;
using RNB.Core.Interfaces;
using System;
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

        [SerializeField, Min(0)] private float _startingGravitySpeed = 5f;
        [SerializeField, Min(0)] private float _acclerationDueToGravity = 9.8f;

        #region IForce
        public float CurrentGravitySpeed { get; private set; }
        public Vector2 CurrentGravityForce
        {
            get
            {
                PreviousForce = LastCalculatedForce;
                LastCalculatedForce = new Vector2(0f, -CurrentGravitySpeed);

                OnForceChange?.Invoke(PreviousForce, LastCalculatedForce);

                return LastCalculatedForce;
            }
        }

        public Vector2 PreviousForce { get; private set; }
        public Vector2 LastCalculatedForce { get; private set; }
        public Vector2 CurrentForce => CurrentGravityForce;

        public event Action<Vector2, Vector2> OnForceChange;
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
            CurrentGravitySpeed += _acclerationDueToGravity * Time.deltaTime;
        }

        [ContextMenu("Enable Gravity")]
        public void EnableGravity()
        {
            CurrentGravitySpeed = _startingGravitySpeed;
            enabled = true;
        }

        [ContextMenu("Disable Gravity")]
        public void DisableGravity()
        {
            CurrentGravitySpeed = 0f;
            enabled = false;
        }

        public void UpdateStartingGravitySpeed(float newSpeed) => _startingGravitySpeed = newSpeed;
        public void UpdateAcclerationDueToGravity(float newGravityAccleration) => _acclerationDueToGravity = newGravityAccleration;
    }
}
