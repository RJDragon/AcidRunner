using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isFinish", true);
                Destroy(gameObject);
            }
        }
}
