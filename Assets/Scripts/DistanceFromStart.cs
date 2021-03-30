using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceFromStart : MonoBehaviour
{
    [SerializeField] private Transform _checkpoint;
    [SerializeField] private Text _distanceText;

    private float _distance;

    void Update()
    {
        _distance = transform.position.x - _checkpoint.transform.position.x;

        _distanceText.text = "Distance: " + _distance.ToString("F1") + " meters";

        if (_distance <= 0)
        {
            _distanceText.text = "Start!";
        }
    }
}
