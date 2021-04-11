using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceFromStart : MonoBehaviour
{
    [SerializeField] private Transform _checkpoint;
    //[SerializeField] private Text _distanceText;
    [SerializeField] private TextMeshProUGUI _textPro;

    public float distance;

    void Update()
    {
        distance = transform.position.x - _checkpoint.transform.position.x;

        //_distanceText.text = "Distance: " + distance.ToString("F1") + " meters";

        _textPro.text = "Distance: " + distance.ToString("F1") + " m";
        
        if (distance <= 0)
        {
           // _distanceText.text = "Start!";
            _textPro.text = "Start!";
        }
    }
}
