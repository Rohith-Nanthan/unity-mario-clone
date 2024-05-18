using RNB.Core;
using RNB.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
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

        private void Awake()
        {
            _groundHitDetector = _groundHitDetectorComponent as IHitDetector;
        }

        private void OnEnable()
        {
            _groundHitDetector.OnHitStatusChange += SetPlayerStateBasedOnGroundHit;
        }

        private void Start()
        {
            SetPlayerStateBasedOnGroundHit(_groundHitDetector.IsHit);
        }

        private void OnDisable()
        {
            _groundHitDetector.OnHitStatusChange -= SetPlayerStateBasedOnGroundHit;
        }
        
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
    }
}
