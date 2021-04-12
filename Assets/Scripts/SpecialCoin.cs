using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCoin : MonoBehaviour
{
    // how fast should the coin fly down
    [SerializeField] 
    private float _speed = 5f;
    
    
    void Update()
    {
        // moves coin down
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        
        // coins are prespawned out of sight on the left of the map in the scene. if they are low enough, they spawn randomly and globally in the sky
        if (transform.position.y < -25f)
        {
            transform.position = new Vector3(Random.Range(-10f, 3300f), 40f, 0f);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // if hit by player
        if (other.CompareTag("Player"))
        {
            // give +3 coins
            CoinCounter.scoreCounter += 3;
            // destroy the coin
            Destroy(gameObject);
        }
    }
}
