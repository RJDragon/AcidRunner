using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCube : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // if the object we collide with is the player
        if (other.CompareTag("Player"))
        {
            // destroy the object
            Destroy(this.gameObject);
        }
    }
}
