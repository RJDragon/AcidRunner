using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //coins rotate
        transform.Rotate(90 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the player hits a coin
        if (other.CompareTag("Player"))
        {
            // increases amount of coins by one
            CoinCounter.scoreCounter += 1;
            // destroy the coin
            Destroy(gameObject);
        }
    }
}
