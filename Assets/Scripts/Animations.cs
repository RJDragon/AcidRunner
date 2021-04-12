using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class for animations via animator
public class Animations : MonoBehaviour
{
    // animator variable
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
