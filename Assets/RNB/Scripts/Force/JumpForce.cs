using RNB.Core;
using RNB.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Force
{
    public class JumpForce : MonoBehaviour, IForce
    {
        [SerializeField] private bool _autoEnableJumpAtStart;

        [SerializeField,Min(0)] private float _startingJumpForceAlongY = 20f;
        [SerializeField,Min(0)] private float _deAccleratingDueToGravity = 9.8f;

        #region IForce
        public float CurrentJumpForceAlongY { get; private set; }

        public Vector2 CurrentJumpForce
        {
            get
            {
                PreviousForce = LastCalculatedForce;
                LastCalculatedForce = new Vector2(0f, CurrentJumpForceAlongY);
                return LastCalculatedForce;
            }
        }

        public Vector2 PreviousForce { get;private set; }
        public Vector2 LastCalculatedForce { get; private set; }
        public Vector2 CurrentForce => CurrentJumpForce;
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
            CurrentJumpForceAlongY -= _deAccleratingDueToGravity * Time.deltaTime;
        }

        public void EnableJump()
        {
            CurrentJumpForceAlongY = _startingJumpForceAlongY;
            enabled = true;
        }

        public void DisableJump()
        {
            CurrentJumpForceAlongY = 0f;
            enabled = false;
        }
    }
}
