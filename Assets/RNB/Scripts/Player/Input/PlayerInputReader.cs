using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RNB.Player.Input
{
    /// <summary>
    /// It reads input from <see cref="PlayerInputActions"/> and exposes API to use them in context
    /// Author: rohith.nanthan
    /// </summary>
    public class PlayerInputReader : MonoBehaviour
    {
        private PlayerInputActions _playerInputActions;

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

            _playerInputActions.Land.Jump.performed += OnJumpInputPerformed;
            _playerInputActions.Land.Jump.canceled += OnJumpInputCanceled;
        }

        private void UnSubscribeForInputCallbacks()
        {
            _playerInputActions.Land.Move.performed -= OnMoveInputPerformed;
            _playerInputActions.Land.Move.canceled -= OnMoveInputCanceled;

            _playerInputActions.Land.Jump.performed -= OnJumpInputPerformed;
            _playerInputActions.Land.Jump.canceled -= OnJumpInputCanceled;
        }

        #region Move
        public Vector2 MovementInput { get; private set; }
        public event Action<Vector2> OnMoveButtonPressed;
        public event Action<Vector2> OnMoveButtonReleased;

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
        #endregion

        #region Jump
        public event Action OnJumpPressed;
        public event Action OnJumpReleased;

        private void OnJumpInputPerformed(InputAction.CallbackContext context)
        {
            OnJumpPressed?.Invoke();
        }

        private void OnJumpInputCanceled(InputAction.CallbackContext context)
        {
            OnJumpReleased?.Invoke();
        }
        #endregion
    }
}
