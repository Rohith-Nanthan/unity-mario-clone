using RNB.Player.StateSwitcher;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerControlScriptableObject _controlConfig;

        [SerializeField] private PlayerStateSwitcher _stateSwitcher;
        [SerializeField] private PlayerGroundStateSwitcher _groundStateSwitcher;
        [SerializeField] private PlayerAirStateSwitcher _airStateSwitcher;

        [SerializeField] private PlayerMovementForce _movementForce;

        private void Awake()
        {
            _movementForce.GroundHorizontalMovementForce.UpdateMovementSpeed(_controlConfig._MovementSpeedInGround);
            _movementForce.AirHorizontalMovementForce.UpdateMovementSpeed(_controlConfig._MovementSpeedInGround);

            _movementForce.GravityForce.UpdateStartingGravitySpeed(_controlConfig._InitialFallingDownSpeed);
            _movementForce.GravityForce.UpdateAcclerationDueToGravity(_controlConfig._FallingDownAccleration);
            _movementForce.GravityForce.UpdateMaxCapForGravitySpeed(_controlConfig._MaxFallingDownSpeed);

            _movementForce.JumpForce.UpdateStartingJumpSpeed(_controlConfig._InitialJumpSpeed);
            _movementForce.JumpForce.UpdateJumpDeAccleration(_controlConfig._JumpSpeedDeaccleration);
        }

        private void Start()
        {
            _stateSwitcher.Init();
            _groundStateSwitcher.Init();
            _airStateSwitcher.Init();

            _movementForce.Init();
        }


    }
}
