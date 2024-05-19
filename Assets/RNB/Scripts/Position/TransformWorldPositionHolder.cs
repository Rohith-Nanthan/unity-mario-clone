using RNB.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Position
{
    public class TransformWorldPositionHolder : MonoBehaviour, IPosition
    {
        [SerializeField] private Transform _transformToFetchWorldPosition;

        #region IPosition
        public Vector2 Position => _transformToFetchWorldPosition.position;
        #endregion
    }
}
