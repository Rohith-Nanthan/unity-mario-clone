using RNB.Core;
using RNB.Core.Interfaces;
using RNB.Player.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player.StateSwitcher
{
    public enum PlayerAirstates
    {
        NotInAir,
        FallingDown,
        Jumping
    }

    /// <summary>
    /// Author: rohith.nanthan
    /// </summary>
    public class PlayerAirStateSwitcher : FSM_SwitcherBase<PlayerAirstates>
    {
        [SerializeField] private PlayerStateSwitcher _playerStateSwitcher;
        [SerializeField] private PlayerInputReader _inputReader;

        #region Unity Life Cycle Events
        private void OnEnable()
        {
            _playerStateSwitcher.Fsm.OnStateSwitch += OnPlayerStateSwitch;
            _inputReader.OnJumpPressed += OnJumpPressed;
        }

        private void OnDisable()
        {
            _playerStateSwitcher.Fsm.OnStateSwitch -= OnPlayerStateSwitch;
            _inputReader.OnJumpPressed -= OnJumpPressed;
        }
        #endregion

        private void OnJumpPressed()
        {
            if (_playerStateSwitcher.Fsm.CurrentState == PlayerStates.OnGround)
            {
                Fsm.SwitchState(PlayerAirstates.Jumping);
                _playerStateSwitcher.Fsm.SwitchState(PlayerStates.InAir);
            }
        }

        private void OnPlayerStateSwitch(PlayerStates previousState, PlayerStates currentState)
        {
            if (currentState == PlayerStates.OnGround)
            {
                Fsm.SwitchState(PlayerAirstates.NotInAir);
            }
            else if (Fsm.CurrentState != PlayerAirstates.Jumping)
            {
                Fsm.SwitchState(PlayerAirstates.FallingDown);
            }
        }

        #region IInitializable
        public override void Init()
        {
            if (_playerStateSwitcher.Fsm.CurrentState != PlayerStates.InAir)
            {
                Fsm.SetInitialState(PlayerAirstates.NotInAir);
            }
            else
            {
                Fsm.SetInitialState(PlayerAirstates.FallingDown);
            }
        }
        #endregion
    }
}