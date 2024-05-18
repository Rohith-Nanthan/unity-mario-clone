using RNB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player.Force
{
    public class PlayerGroundMovementForce : MonoBehaviour, IForce
    {
        public Vector2 Force
        {
            get
            {
                float horizontalMovementdirection = _inputReader.MovementInput.x;
                float horizontalMovementSpeed = horizontalMovementdirection * _movementSpeedOnGround;

                return new Vector2(horizontalMovementSpeed, 0f);
            }
        }

        [SerializeField] private PlayerInputReader _inputReader;
        [SerializeField] private float _movementSpeedOnGround;
    }
}
