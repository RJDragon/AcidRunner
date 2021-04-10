using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoCrazyPill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(90 * Time.deltaTime, 0, 0);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<Player>().crazyTime = Time.time;
            GameObject.Find("Player").GetComponent<Player>().startCrazy = true;
            
            //give one extra health
            other.GetComponent<Player>().health += 1;
            other.GetComponent<Player>().antihealth -= 1;
            LivesCounter.livesCounter += 1;
            
            
            // destroy the vaccine
            Destroy(gameObject);
        }
    }
}
