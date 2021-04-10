using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    
    /*private void Start()
    {
        _startImmune = false;
    }*/

    /*void Update()
    {
        transform.Rotate(90 * Time.deltaTime, 0, 0);
        /*if (Time.time - _immuneTime > 7f)
        {
            _startImmune = false;
        }
        if (_startImmune)
        {
            vaccineHitbool = 1;
        }*/
        
    //}*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<Player>().immuneTime = Time.time;
            GameObject.Find("Player").GetComponent<Player>().startImmune = true;
            
            other.GetComponent<Player>().health += 1;
            other.GetComponent<Player>().antihealth -= 1;
            LivesCounter.livesCounter += 1;
            
            
            // destroy the vaccine
            Destroy(gameObject);
        }
    }
}
