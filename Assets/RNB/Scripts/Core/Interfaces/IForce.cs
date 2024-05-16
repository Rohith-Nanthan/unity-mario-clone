using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Core
{
    /// <summary>
    /// Holds a non-normalized Vector2 that represents the force at which
    /// a body can move.
    /// <br/>Author: rohith.nanthan
    /// </summary>
    public interface IForce
    {
        public Vector2 Force { get; }
    }
}
