using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    // init. variable for rotation speed
    [SerializeField] private float _rotateSpeed = 2f;
    
    void Update()
    {
        // rotates over x axis: means just works with cubes(ground) on y = 0.
        transform.Rotate(90 * Time.deltaTime * _rotateSpeed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if player hits spikeball
        if (other.CompareTag("Player"))
        {
            // go to damage function
            other.GetComponent<Player>().Damage();
        }
    }
}
