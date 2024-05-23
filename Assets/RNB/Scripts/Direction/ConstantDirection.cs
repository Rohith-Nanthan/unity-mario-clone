using RNB.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Direction
{
    /// <summary>
    /// Holds a Vector2 direction that never changes at run-time
    /// <br/>Author: rohith.nanthan
    /// </summary>
    public class ConstantDirection : MonoBehaviour, IDirection
    {
        [field:SerializeField] public Vector2 Direction{ get; private set; }
    }
}
