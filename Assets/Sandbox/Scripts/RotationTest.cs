using RNB.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    [SerializeField] private Transform _directionFrom;
    [SerializeField] private Transform _directionTo;

    [SerializeField] private Transform _transformToRotate;

    [SerializeField, ReadOnlyInInspector]
    private Vector2 _direction;

    private void Update()
    {
        _direction = (_directionTo.position - _directionFrom.position).normalized;
        float rotationOnZ = _direction.GetRotationAngleOnZ();
        _transformToRotate.rotation = Quaternion.Euler(0, 0, rotationOnZ);
    }
}
