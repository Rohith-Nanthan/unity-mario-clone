using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Core.Interfaces
{
    /// <summary>
    /// It holds a normalized Vector2 which represents the direction
    /// <br/>Note: Script that implements this interface must return only normalized Vector2.
    /// Scripts that uses them will not normalize the vector
    /// <br/>Author: rohith.nanthan
    /// </summary>
    public interface IDirection
    {
        public Vector2 Direction { get; }
    }
}
