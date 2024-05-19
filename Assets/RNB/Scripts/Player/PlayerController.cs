using RNB.Player.StateSwitcher;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerStateSwitcher _stateSwitcher;
        [SerializeField] private PlayerGroundStateSwitcher _groundStateSwitcher;
        [SerializeField] private PlayerAirStateSwitcher _airStateSwitcher;

        [SerializeField] private PlayerMovementForce _movementForce;

        private void Start()
        {
            _stateSwitcher.Init();
            _groundStateSwitcher.Init();
            _airStateSwitcher.Init();

            _movementForce.Init();
        }


    }
}
