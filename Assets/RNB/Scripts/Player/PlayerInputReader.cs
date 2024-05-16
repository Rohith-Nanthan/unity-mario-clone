using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RNB.Player
{
    public class PlayerInputReader : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;

        public Vector2 MovementInput { get;private set; }
        public event Action<Vector2> OnMoveButtonPressed;
        public event Action<Vector2> OnMoveButtonReleased;

        #region Unity Life Cycle Events
        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
        }

        private void OnEnable()
        {
            _playerInputActions.Land.Enable();
            SubscribeForInputCallbacks();
        }

        private void OnDisable()
        {
            _playerInputActions.Land.Disable();
            UnSubscribeForInputCallbacks();
        }
        #endregion

        private void SubscribeForInputCallbacks()
        {
            _playerInputActions.Land.Move.performed += OnMoveInputPerformed;
            _playerInputActions.Land.Move.canceled += OnMoveInputCanceled;
        }

        private void UnSubscribeForInputCallbacks()
        {
            _playerInputActions.Land.Move.performed -= OnMoveInputPerformed;
            _playerInputActions.Land.Move.canceled -= OnMoveInputCanceled;
        }

        private void OnMoveInputPerformed (InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
            OnMoveButtonPressed?.Invoke (MovementInput);
        }

        private void OnMoveInputCanceled(InputAction.CallbackContext context)
        {
            MovementInput = Vector2.zero;
            OnMoveButtonReleased?.Invoke(MovementInput);
        }
    }
}
