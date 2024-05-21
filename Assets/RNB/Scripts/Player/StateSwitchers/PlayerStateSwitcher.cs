using RNB.Core;
using RNB.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace RNB.Player.StateSwitcher
{
    public enum PlayerStates
    {
        OnGround,
        InAir
    }
        
    public class PlayerStateSwitcher : FSM_SwitcherBase<PlayerStates>
    {
        [SerializeField] private PlayerInputReader _inputReader;

        private IHitDetector _groundHitDetector;
        [SerializeField] private MonoBehaviour _groundHitDetectorComponent;

        #region Unity Life cycle Events
        private void Awake()
        {
            _groundHitDetector = _groundHitDetectorComponent as IHitDetector;
        }

        private void OnEnable()
        {
            _groundHitDetector.OnHitStatusChange += SetPlayerStateBasedOnGroundHit;
        }

        private void OnDisable()
        {
            _groundHitDetector.OnHitStatusChange -= SetPlayerStateBasedOnGroundHit;
        }
        #endregion

        private void SetPlayerStateBasedOnGroundHit(bool isHit)
        {
            if(isHit)
            {
                Fsm.SwitchState(PlayerStates.OnGround);
            }
            else
            {
                Fsm.SwitchState(PlayerStates.InAir);
            }
        }

        #region IInitializable
        public override void Init()
        {
            if (_groundHitDetector.IsHit)
            {
                Fsm.SetInitialState(PlayerStates.OnGround);
            }
            else
            {
                Fsm.SetInitialState(PlayerStates.InAir);
            }
        }
        #endregion
    }
}
