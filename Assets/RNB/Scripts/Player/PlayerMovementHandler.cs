using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Player
{
    public class PlayerMovementHandler : MonoBehaviour
    {
        [SerializeField] private Vector2 _directionToMove;
        [SerializeField] private float _force;
        [SerializeField] private Transform _targetToMove;

        private void Update()
        {
            Vector3 force = _directionToMove.normalized * _force;
            _targetToMove.position += force * Time.deltaTime;
        }
    }
}
