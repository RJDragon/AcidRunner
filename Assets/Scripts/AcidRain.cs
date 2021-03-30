using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidRain : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _causeDamageRate = 2f;
    private float _canCauseDamage = -1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -25f)
        {
            transform.position = new Vector3(Random.Range(-10f, 150f), 15f, 0f);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        // if the object we collide with is the player
        if (other.CompareTag("Player") && Time.time > _canCauseDamage)
        {
            _canCauseDamage = Time.time + _causeDamageRate;
            other.GetComponent<Player>().Damage();
            Destroy(this.gameObject);
        }

        /*//if the other one is the vaccine
        else if (other.CompareTag("Vaccine"))
        {   
            Debug.LogWarning("hitting corona with vaccine");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }*/
    }
}