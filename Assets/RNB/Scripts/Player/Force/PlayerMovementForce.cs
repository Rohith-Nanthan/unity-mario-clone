using RNB.Core;
using RNB.Core.Interfaces;
using RNB.Force;
using RNB.Player.Force;
using RNB.Player.StateSwitcher;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player
{
    /// <summary>
    /// Author: rohith.nanthan
    /// </summary>
    public class PlayerMovementForce : MonoBehaviour, IForce, IInitializable
    {
        #region IForce
        public Vector2 CurrentForce
        {
            get
            {
                PreviousForce = LastCalculatedForce;
                LastCalculatedForce= GetForceBasedOnStates();

                OnForceChange?.Invoke(PreviousForce, LastCalculatedForce);

                return LastCalculatedForce;
            }
        }

        public Vector2 PreviousForce { get; private set; }
        public Vector2 LastCalculatedForce { get; private set; }

        public event Action<Vector2, Vector2> OnForceChange;
        #endregion

        [SerializeField] private PlayerStateSwitcher _playerStateSwitcher;
        [SerializeField] private PlayerGroundStateSwitcher _playerGroundStateSwitcher;
        [SerializeField] private PlayerAirStateSwitcher _playerAirStateSwitcher;

        [SerializeField] private PlayerHorizontalInputBasedMovementForce _groundHorizontalMovementForce;

        [Header("Air")]
        [SerializeField] private PlayerHorizontalInputBasedMovementForce _airHorizontalMovementForce;
        [SerializeField] private MaxCappedGravityForce _gravityForce;
        [SerializeField] private JumpForce _jumpForce;

        private void OnEnable()
        {
            _playerAirStateSwitcher.Fsm.OnStateSwitch += ToggleForcesForAirStateChange; ;
        }

        private void OnDisable()
        {
            _playerAirStateSwitcher.Fsm.OnStateSwitch -= ToggleForcesForAirStateChange; ;
        }

        private void ToggleForcesForAirStateChange(PlayerAirstates previousState, PlayerAirstates currentState)
        {
            switch(currentState)
            {
                case PlayerAirstates.NotInAir:
                    switch (previousState)
                    {
                        case PlayerAirstates.Jumping:
                            _jumpForce.DisableJump();
                            break;

                        case PlayerAirstates.FallingDown:
                            _gravityForce.DisableGravity();
                            break;
                    }
                    break;

                case PlayerAirstates.Jumping:
                    _jumpForce.EnableJump();
                    break;

                case PlayerAirstates.FallingDown:
                    _gravityForce.EnableGravity();
                    break;
            }
        }

        private Vector2 GetForceBasedOnStates()
        {
            switch(_playerStateSwitcher.Fsm.CurrentState)
            {
                case PlayerStates.OnGround:
                    return _groundHorizontalMovementForce.CurrentForce;

                case PlayerStates.InAir:
                    Vector2 verticalForce = Vector2.zero;
                    switch(_playerAirStateSwitcher.Fsm.CurrentState)
                    {
                        case PlayerAirstates.FallingDown:
                            verticalForce= _gravityForce.CurrentForce;
                            break;

                        case PlayerAirstates.Jumping:
                            verticalForce= _jumpForce.CurrentForce;
                            break;
                    }

                    return _airHorizontalMovementForce.CurrentForce + verticalForce;
            }

            return Vector2.zero;
        }

        #region IInitializable
        public void Init()
        {
            ToggleForcesForAirStateChange(previousState: _playerAirStateSwitcher.Fsm.PreviousState,
                currentState: _playerAirStateSwitcher.Fsm.CurrentState);
        }
        #endregion
    }
}
