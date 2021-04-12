using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoCrazyPill : MonoBehaviour
{
    
    void Update()
    {
        // lets the pill rotate
        transform.Rotate(90 * Time.deltaTime, 0, 0);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // if player hits the pill
        if (other.CompareTag("Player"))
        {
            // time variable gets the actual game time as a value (to later compare it with new actual time and seeing if the difference is higher than..)
            GameObject.Find("Player").GetComponent<Player>().crazyTime = Time.time;
            // sets bool in player script true for the crazy methods
            GameObject.Find("Player").GetComponent<Player>().startCrazy = true;
            
            //give one extra health
            other.GetComponent<Player>().health += 1;
            // antihealth variable for beeing able to reset the health properly in the endgame
            other.GetComponent<Player>().antihealth -= 1;
            // displays extra health
            LivesCounter.livesCounter += 1;
            
            
            // destroy the vaccine
            Destroy(gameObject);
        }
    }
}
