using RNB.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Direction
{
    public class ConstantDirection : MonoBehaviour, IDirection
    {
        [field:SerializeField] public Vector2 Direction{ get; private set; }
    }
}
