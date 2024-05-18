using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sandbox
{
    public class ReadonlyPropertyTest : MonoBehaviour
    {
        [ReadOnlyInInspector]
        public float _speed = 10f;
    }
}
