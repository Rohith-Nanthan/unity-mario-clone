using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Core.Interfaces
{
    /// <summary>
    /// Holds a non-normalized Vector2 that represents the force at which
    /// a body can move.
    /// <br/>Author: rohith.nanthan
    /// </summary>
    public interface IForce
    {
        public Vector2 PreviousForce { get; }
        public Vector2 LastCalculatedForce { get; }
        public Vector2 CurrentForce { get; }

        public Vector2 DeltaForce => LastCalculatedForce - PreviousForce;

        public event Action<Vector2,Vector2> OnForceChange;
    }
}
