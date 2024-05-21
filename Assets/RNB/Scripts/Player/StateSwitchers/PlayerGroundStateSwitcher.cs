using RNB.Core;
using RNB.Core.Interfaces;
using RNB.Player.Force;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player.StateSwitcher
{
    public enum PlayerGroundStates
    {
        NotInGround,
        Idle,
        Moving
    }

    public class PlayerGroundStateSwitcher : FSM_SwitcherBase<PlayerGroundStates>
    {
        [SerializeField] private PlayerStateSwitcher _playerStateSwitcher;
        [SerializeField] private PlayerHorizontalInputBasedMovementForce _groundMovementForce;

        #region Unity Life Cycle Events
        private void OnEnable()
        {
            _playerStateSwitcher.Fsm.OnStateSwitch += OnPlayerStateSwitch;
            _groundMovementForce.OnForceChange += OnGroundForceChanged;
        }

        private void OnDisable()
        {
            _playerStateSwitcher.Fsm.OnStateSwitch -= OnPlayerStateSwitch;
            _groundMovementForce.OnForceChange -= OnGroundForceChanged;
        }
        #endregion

        private void OnPlayerStateSwitch(PlayerStates previousState, PlayerStates currentState)
        {
            if (currentState != PlayerStates.OnGround)
            {
                Fsm.SwitchState(PlayerGroundStates.NotInGround);
            }
            else
            {
                SetGroundStateBasedOnMovementForce(_groundMovementForce.LastCalculatedForce);
            }
        }

        private void OnGroundForceChanged(Vector2 previousForce, Vector2 currentForce)
        {
            SetGroundStateBasedOnMovementForce(currentForce);
        }

        private void SetGroundStateBasedOnMovementForce(Vector2 movementForce)
        {
            if (movementForce == Vector2.zero)
            {
                Fsm.SwitchState(PlayerGroundStates.Idle);
            }
            else
            {
                Fsm.SwitchState(PlayerGroundStates.Moving);
            }
        }

        #region IInitializable
        public override void Init()
        {
            if(_playerStateSwitcher.Fsm.CurrentState !=PlayerStates.OnGround)
            {
                Fsm.SetInitialState(PlayerGroundStates.NotInGround);
            }
            else
            {
                Fsm.SetInitialState(PlayerGroundStates.Idle);
            }
        }
        #endregion
    }
}
