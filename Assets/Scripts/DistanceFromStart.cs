using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceFromStart : MonoBehaviour
{
    [SerializeField] private Transform _checkpoint;
    [SerializeField] private Text _distanceText;

    public float distance;

    void Update()
    {
        distance = transform.position.x - _checkpoint.transform.position.x;

        _distanceText.text = "Distance: " + distance.ToString("F1") + " meters";

        if (distance <= 0)
        {
            _distanceText.text = "Start!";
        }
    }
}
