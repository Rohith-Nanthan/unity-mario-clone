using RNB.Core;
using RNB.Core.Interfaces;
using RNB.Force;
using RNB.Player.Force;
using RNB.Player.StateSwitcher;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player
{
    /// <summary>
    /// Author: rohith.nanthan
    /// </summary>
    public class PlayerMovementForce : MonoBehaviour, IForce
    {
        #region IForce
        public Vector2 CurrentForce
        {
            get
            {
                PreviousForce = LastCalculatedForce;
                LastCalculatedForce= _currentActiveForce.CurrentForce;

                return LastCalculatedForce;
            }
        }

        public Vector2 PreviousForce { get; private set; }
        public Vector2 LastCalculatedForce { get; private set; }
        #endregion

        [SerializeField] private PlayerStateSwitcher _playerStateSwitcher;

        [SerializeField] private PlayerGroundMovementForce _groundMovementForce;
        [SerializeField] private MaxCappedGravityForce _gravityForce;
        [SerializeField] private JumpForce _jumpForce;

        private IForce _currentActiveForce;

        #region Unity Life Cycle Events
        private void OnEnable()
        {
            _playerStateSwitcher.Fsm.OnStateSwitch += OnPlayrStateChange;
        }

        private void Start()
        {
            SelectForceBasedOnCurrentPlayerState(_playerStateSwitcher.Fsm.CurrentState);
        }

        private void OnDisable()
        {
            _playerStateSwitcher.Fsm.OnStateSwitch -= OnPlayrStateChange;
        }
        #endregion

        private void OnPlayrStateChange(PlayerStates previousState, PlayerStates currentState)
        {
            SelectForceBasedOnCurrentPlayerState(currentState);
        }

        private void SelectForceBasedOnCurrentPlayerState(PlayerStates currentState)
        {
            switch(currentState)
            {
                case PlayerStates.OnGround:
                    _jumpForce.DisableJump();
                    _currentActiveForce = _groundMovementForce;
                    break;

                case PlayerStates.InAir:
                    _jumpForce.EnableJump();
                    _currentActiveForce = _jumpForce;
                    break;
            }
        }
    }
}
