using RNB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player
{
    public enum PlayerStates
    {
        OnGround,
        Jumping
    }
        
    public class PlayerStateSwitcher : FSM_SwitcherBase<PlayerStates>
    {
        [SerializeField] private PlayerInputReader _inputReader;

        private void OnEnable()
        {
            _inputReader.OnJumpPressed += SwitchToJumpState;
        }

        private void OnDisable()
        {
            _inputReader.OnJumpPressed -= SwitchToJumpState;
        }

        private void SwitchToJumpState()
        {
            Fsm.SwitchState(PlayerStates.Jumping);
        }
    }
}
