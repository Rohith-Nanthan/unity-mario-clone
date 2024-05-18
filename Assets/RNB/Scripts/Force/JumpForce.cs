using RNB.Core;
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
        public float CurrentJumpForceAlongY { get;private set; }
        public Vector2 CurrentJumpForce => new Vector2(0f, CurrentJumpForceAlongY);
        public Vector2 Force => CurrentJumpForce;
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
