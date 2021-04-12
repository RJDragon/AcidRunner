using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    
    

    private void OnTriggerEnter(Collider other)
    {
        // when player hits medikit aka vaccine
        if (other.CompareTag("Player"))
        {
            // init. time variable with time of collision
            GameObject.Find("Player").GetComponent<Player>().immuneTime = Time.time;
            // say the player script that the player hit the vaccine
            GameObject.Find("Player").GetComponent<Player>().startImmune = true;
            
            // health +1
            other.GetComponent<Player>().health += 1;
            other.GetComponent<Player>().antihealth -= 1;
            LivesCounter.livesCounter += 1;
            
            
            // destroy the vaccine
            Destroy(gameObject);
        }
    }
}
