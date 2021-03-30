using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnPlayer : MonoBehaviour
{

    [SerializeField] 
    private Transform target = null;

    private Vector3 _rosenkohl;
    
    
    void Start()
    {
        //(idee: creating a position depending on the player- but why?)
         _rosenkohl = transform.position - target.position;
    }
    // Late Update is called after Update, this allows for an execution order
    // google says following cameras should always be started in late update
    // Update is called once per frame
    void LateUpdate()
    {
        //making it dependent on the position of the target (player); Lerp makes it smoother
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(target.position.x, target.position.y, target.position.z) + _rosenkohl, Time.deltaTime * 3);
              
    }
}