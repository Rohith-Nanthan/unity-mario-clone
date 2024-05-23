using RNB.Core;
using RNB.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Force
{
    /// <summary>
    /// This holds a force that behaves like a jump arc where you start jumping with a intital upward force and
    /// it slowly decreases until reaching the apex point where the velocity is momentarily zero and then you start falling
    /// down with increasing downward force.
    /// <br/>You can start jumping by calling <see cref="EnableJump"/> and stop jumping by calling <see cref="DisableJump"/>
    /// <br/>Note: This only gives you force along Y
    /// <br/>Author: rohith.nanthan
    /// </summary>
    public class JumpForce : MonoBehaviour, IForce
    {
        [SerializeField] private bool _autoEnableJumpAtStart;

        [SerializeField,Min(0)] private float _startingJumpSpeed = 20f;
        [SerializeField,Min(0)] private float _deAccleratingDueToGravity = 9.8f;

        #region IForce
        public float CurrentJumpSpeed { get; private set; }

        public Vector2 CurrentJumpForce
        {
            get
            {
                PreviousForce = LastCalculatedForce;
                LastCalculatedForce = new Vector2(0f, CurrentJumpSpeed);

                OnForceChange?.Invoke(PreviousForce, LastCalculatedForce);
                return LastCalculatedForce;
            }
        }

        public Vector2 PreviousForce { get;private set; }
        public Vector2 LastCalculatedForce { get; private set; }
        public Vector2 CurrentForce => CurrentJumpForce;

        public event Action<Vector2,Vector2> OnForceChange;
        #endregion

        private void Awake()
        {
            if(_autoEnableJumpAtStart)
            {
                EnableJump();
            }
            else
            {
                DisableJump();
            }
        }

        private void FixedUpdate()
        {
            CurrentJumpSpeed -= _deAccleratingDueToGravity * Time.deltaTime;
        }

        public void EnableJump()
        {
            CurrentJumpSpeed = _startingJumpSpeed;
            enabled = true;
        }

        public void DisableJump()
        {
            CurrentJumpSpeed = 0f;
            enabled = false;
        }

        public void UpdateStartingJumpSpeed(float newJumpSpeed) => _startingJumpSpeed = newJumpSpeed;
        public void UpdateJumpDeAccleration(float newDeAccleration) => _deAccleratingDueToGravity = newDeAccleration;
    }
}
