using RNB.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Position
{
    /// <summary>
    /// It holds the World position of the <see cref="_transformToFetchWorldPosition"/>
    /// Author: rohith.nanthan
    /// </summary>
    public class TransformWorldPositionHolder : MonoBehaviour, IPosition
    {
        [SerializeField] private Transform _transformToFetchWorldPosition;

        #region IPosition
        public Vector2 Position => _transformToFetchWorldPosition.position;
        #endregion
    }
}
