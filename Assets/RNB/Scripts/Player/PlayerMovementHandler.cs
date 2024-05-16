using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player
{
    public class PlayerMovementHandler : MonoBehaviour
    {
        [SerializeField] private PlayerInputReader _inputReader;
        [SerializeField] private float _force;
        [SerializeField] private Transform _targetToMove;

        private void Update()
        {
            Vector3 force = _inputReader.MovementInput * _force;
            _targetToMove.position += force * Time.deltaTime;
        }
    }
}
