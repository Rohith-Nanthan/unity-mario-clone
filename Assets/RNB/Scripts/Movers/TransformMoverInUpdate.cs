using RNB.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Movers
{
    /// <summary>
    /// Moves the <see cref="_transformToMove"/> based on the <see cref="_force"/>
    /// <br/>Author: rohith.nanthan
    /// </summary>
    public class TransformMoverInUpdate : MonoBehaviour
    {
        [SerializeField] private Transform _transformToMove;

        private IForce _force;
        [SerializeField] private MonoBehaviour _forceComponent;

        private void Awake()
        {
            _force = _forceComponent as IForce;
        }

        private void Update()
        {
            _transformToMove.position += (Vector3)_force.Force * Time.deltaTime;
        }
    }
}
