using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNB.Utils
{
    public static class Vector2Extensions
    {
        public static float GetRotationAngleOnZ(this Vector2 v)
        {
            return Vector2.SignedAngle(Vector2.up,v);
        }
    }
}
