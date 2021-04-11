using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCoin : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(90 * Time.deltaTime, 0, 0, Space.Self);
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        if (transform.position.y < -25f)
        {
            transform.position = new Vector3(Random.Range(-10f, 3300f), 40f, 0f);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCounter.scoreCounter += 3;
            // should destroy the coin
            Destroy(gameObject);
        }
    }
}
