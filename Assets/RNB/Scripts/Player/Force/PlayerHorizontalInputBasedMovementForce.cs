using RNB.Core;
using RNB.Core.Interfaces;
using RNB.Player.StateSwitcher;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player.Force
{
    public class PlayerHorizontalInputBasedMovementForce : MonoBehaviour, IForce
    {
        #region IForce
        public Vector2 CurrentForce
        {
            get
            {
                float horizontalMovementdirection = _inputReader.MovementInput.x;
                float horizontalMovementSpeed = horizontalMovementdirection * _movementSpeedOnHorizontalInputDirection;

                PreviousForce = LastCalculatedForce;
                LastCalculatedForce = new Vector2(horizontalMovementSpeed, 0f);
                
                OnForceChange?.Invoke(PreviousForce, LastCalculatedForce);
                
                return LastCalculatedForce;
            }
        }

        public Vector2 PreviousForce { get; private set; }
        public Vector2 LastCalculatedForce { get; private set; }

        public event Action<Vector2, Vector2> OnForceChange;
        #endregion

        [SerializeField] private PlayerInputReader _inputReader;
        [SerializeField] private float _movementSpeedOnHorizontalInputDirection = 5f;

        public void UpdateMovementSpeed(float newSpeed) => _movementSpeedOnHorizontalInputDirection = newSpeed;
    }
}
