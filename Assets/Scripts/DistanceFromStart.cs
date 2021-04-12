using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceFromStart : MonoBehaviour
{
    // creating a reference variable for the distance
    [SerializeField] private Transform _checkpoint;
    // init. textmeshpro text
    [SerializeField] private TextMeshProUGUI _textPro;

    //variable storing the distance between reference object and player
    public float distance;

    void Update()
    {
        // variable storing the distance between reference object and player
        distance = transform.position.x - _checkpoint.transform.position.x;

        // displays the distance with a string. format says how many digits after comma
        _textPro.text = "Distance: " + distance.ToString("F1") + " m";
        
        // initial text when player is in front of object
        if (distance <= 0)
        {
           // Start!
            _textPro.text = "Start!";
        }
    }
}
