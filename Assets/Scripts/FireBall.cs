using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    [SerializeField] private float _rotateSpeed = 2f;
    // Update is called once per frame
    void Update()
    {
        //when on parent rotates against x axis; means just works with cubes(ground) on y = 0.
        transform.Rotate(90 * Time.deltaTime * _rotateSpeed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Damage();
        }
    }
}
