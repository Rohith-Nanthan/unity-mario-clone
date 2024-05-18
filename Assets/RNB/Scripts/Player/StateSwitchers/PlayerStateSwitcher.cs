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
        
    public class PlayerStateSwitcher : FSM_SwitcherBase<PlayerStates>, IInitializable
    {
        [SerializeField] private PlayerInputReader _inputReader;

        private IHitDetector _groundHitDetector;
        [SerializeField] private MonoBehaviour _groundHitDetectorComponent;

        protected override void Awake()
        {
            _groundHitDetector = _groundHitDetectorComponent as IHitDetector;
            base.Awake();
        }

        private void OnEnable()
        {
            _groundHitDetector.OnHitStatusChange += SetPlayerStateBasedOnGroundHit;
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

        #region IInitializable
        public void Init()
        {
            SetPlayerStateBasedOnGroundHit(_groundHitDetector.IsHit);
        }
        #endregion
    }
}
