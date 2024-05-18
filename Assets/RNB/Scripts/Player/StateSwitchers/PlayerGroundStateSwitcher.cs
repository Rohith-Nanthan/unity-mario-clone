using RNB.Core;
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

        private void OnEnable()
        {
            _playerStateSwitcher.Fsm.OnStateSwitch += OnPlayerStateSwitch;
        }

        private void OnPlayerStateSwitch(PlayerStates previousState, PlayerStates currentState)
        {
            if(currentState!=PlayerStates.OnGround)
            {
                Fsm.SwitchState(PlayerGroundStates.NotInGround);
            }
        }

    }
}
