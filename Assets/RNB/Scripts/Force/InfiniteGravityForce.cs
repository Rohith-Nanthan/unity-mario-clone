using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Force
{
    /// <summary>
    /// It holds a force value that will keep increasing indefinitely in Fixed Update at
    /// the rate of <see cref="_acclerationDueToGravity"/>. Use <see cref="CurrentGravityForce"/>
    /// to read the gravity force.
    /// <br/>Author: rohith.nanthan
    /// </summary>
    public class InfiniteGravityForce : MonoBehaviour
    {
        [SerializeField] private float _startingGravityForceAlongY;
        [SerializeField] private float _acclerationDueToGravity;

        public float CurrentGravityForceAlongY { get; private set; }
        public Vector2 CurrentGravityForce => new Vector2(0f, -CurrentGravityForceAlongY);

        private void Awake()
        {
            CurrentGravityForceAlongY = _startingGravityForceAlongY;
        }

        private void FixedUpdate()
        {
            CurrentGravityForceAlongY += _acclerationDueToGravity * Time.deltaTime;
        }
    }
}
