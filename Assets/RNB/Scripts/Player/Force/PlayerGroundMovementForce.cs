using RNB.Core;
using RNB.Core.Interfaces;
using RNB.Player.StateSwitcher;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player.Force
{
    public class PlayerGroundMovementForce : MonoBehaviour, IForce
    {
        #region IForce
        public Vector2 CurrentForce
        {
            get
            {
                float horizontalMovementdirection = _inputReader.MovementInput.x;
                float horizontalMovementSpeed = horizontalMovementdirection * _movementSpeedOnGround;

                PreviousForce = LastCalculatedForce;
                LastCalculatedForce = new Vector2(horizontalMovementSpeed, 0f);
                return LastCalculatedForce;
            }
        }

        public Vector2 PreviousForce { get; private set; }
        public Vector2 LastCalculatedForce { get; private set; }
        #endregion

        [SerializeField] private PlayerInputReader _inputReader;
        [SerializeField] private PlayerGroundStateSwitcher _playerGroundStateSwitcher;

        [SerializeField] private float _movementSpeedOnGround;
    }
}
