using RNB.Core;
using RNB.Force;
using RNB.Player.Force;
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
        public Vector2 Force => _currentActiveForce.Force;
        #endregion

        [SerializeField] private PlayerStateSwitcher _stateSwitcher;

        [SerializeField] private PlayerGroundMovementForce _groundMovementForce;
        [SerializeField] private MaxCappedGravityForce _gravityForce;
        [SerializeField] private JumpForce _jumpForce;

        private IForce _currentActiveForce;

        #region Unity Life Cycle Events
        private void OnEnable()
        {
            _stateSwitcher.Fsm.OnStateSwitch += OnPlayrStateChange;
        }

        private void Start()
        {
            SelectForceBasedOnCurrentPlayerState(_stateSwitcher.Fsm.CurrentState);
        }

        private void OnDisable()
        {
            _stateSwitcher.Fsm.OnStateSwitch -= OnPlayrStateChange;
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

                case PlayerStates.Jumping:
                    _jumpForce.EnableJump();
                    _currentActiveForce = _jumpForce;
                    break;
            }
        }
    }
}
