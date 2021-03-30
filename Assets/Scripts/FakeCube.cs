using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // if the object we collide with is the player
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<Player>().Damage();
            Destroy(this.gameObject);
        }
    }
}
