using RNB.Core;
using RNB.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Detection
{
    /// <summary>
    /// Casts a ray from <see cref="_startingPosition"/> in the direction of <see cref="_raycastDirection"/>
    /// to a fixed distance.
    /// <br/>Author: rohith.nanthan
    /// </summary>
    public class Raycaster : MonoBehaviour, IHitDetector
    {
        private IDirection _raycastDirection;
        [SerializeField] private MonoBehaviour _raycastDirectionComponent;

        private IPosition _startingPosition;
        [SerializeField] private MonoBehaviour _startingPositionComponent;

        [SerializeField] private float _raycastDistance;
        [SerializeField] private LayerMask _layerMask;

        #region IHitDetector
        public RaycastHit2D LastHitInfo { get; private set; }

        private bool _isHit = false;
        public bool IsHit
        {
            get => _isHit;

            set
            {
                if (_isHit == value)
                {
                    return;
                }

                _isHit = value;
                OnHitStatusChange?.Invoke(value);
            }
        }

        public event Action<bool> OnHitStatusChange;
        #endregion

        private void Awake()
        {
            _raycastDirection = _raycastDirectionComponent as IDirection;
            _startingPosition = _startingPositionComponent as IPosition;
        }

        private void FixedUpdate()
        {
            LastHitInfo = Physics2D.Raycast(origin: _startingPosition.Position, 
                direction: _raycastDirection.Direction, 
                distance: _raycastDistance, 
                layerMask: _layerMask);

            IsHit = LastHitInfo.collider != null;
        }
    }
}
