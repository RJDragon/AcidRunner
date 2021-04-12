using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
        {
            // if the player hits the end object
            if (other.CompareTag("Player"))
            {
                // change bool value of animation for dancing 0 (dancing without stopping)
                GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isFinish", true);
                // destroy it
                Destroy(gameObject);
            }
        }
}
