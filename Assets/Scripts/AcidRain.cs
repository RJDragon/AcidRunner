using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidRain : MonoBehaviour
{
    //variables to play with in the inspector. also this way we have different paced rains
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _causeDamageRate = 2f;
    private float _canCauseDamage = -1f;
    
    // variable public, as there are methods relying on the fact if the player was hit by the rain
    public bool vaccineHit;
    
    // Start is called before the first frame update
    void Start()
    {
        // default: player is not hit by rain
        vaccineHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        // let it rain: rain just moves down
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        // the amount of rain is set in the scene; but we did not want to hardcore its position. therefore when it went down,
        // it starts randomly globally over the map
        if (transform.position.y < -25f)
        {
            transform.position = new Vector3(Random.Range(-10f, 3300f), 40f, 0f);
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        // if the object we collide with is the player
        if (other.CompareTag("Player") && Time.time > _canCauseDamage)
        {
            _canCauseDamage = Time.time + _causeDamageRate;

            // when the player is vaccinated
            if (GameObject.Find("Player").GetComponent<Player>().vaccineHitBool==1)
            {
                vaccineHit = true;
            }
            // just apply damage if the player is not vaccinated
            if (vaccineHit == false)
            {
                
                other.GetComponent<Player>().Damage();
            }
            // destroy the rain after it hit the player
            Destroy(this.gameObject);
        }

        
        
    }

   
}