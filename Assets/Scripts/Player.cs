using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Serialization;



public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _pace = 5f;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] public int health = 3;
    
    private float _gravity = -50f;
    private CharacterController _characterController;
    private float _yValue;
    private bool _groundCheck;
    private float _baseSpeed;

    //antihealth as a variable to measure the health to later subtract it
    public int antihealth = 0;
    

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed();
        GroundCheck();
        Gravity();
        PlayerMovement();
        fellDown();
        
    }
    
    // different base speed (resulting in a different overall pace)
    // to avoid getting hit or collect items
    void Speed()
    {
        if (_groundCheck && Input.GetButton("Fire1"))
        {
            _baseSpeed = 0.2f;
            _jumpHeight = 1.8f;
        }
        else if (_groundCheck && Input.GetButton("Fire2"))
        {
            _baseSpeed = 1.3f;
            _jumpHeight = 2.2f;
        }
        else if (_groundCheck && Input.GetButton("Fire3"))
        {
            _baseSpeed = 1.65f;
            _jumpHeight = 3f;
        }
        else
        {
            _baseSpeed = 1f;
        }
        
    }

    void GroundCheck()
    {
        _groundCheck = Physics.CheckSphere(transform.position, 0.1f, _ground, QueryTriggerInteraction.Ignore);
    }

    void Gravity()
    {
        if (_groundCheck)
        {
            _yValue = 0;
        }
        else
        {
            _yValue += _gravity * Time.deltaTime;
        }
        
        /*
        if (_groundCheck && velocity.y < 0)
        {
            velocity.y = 0;
        }
        else
        {
           velocity.y += _gravity * Time.deltaTime;
        }*/
    }

    void PlayerMovement()
    {
        // Let the player jump
        if (_groundCheck && Input.GetButtonDown("Jump"))
        {

            _yValue += Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        }

        // Move the player forward
        //_characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);
        _characterController.Move(new Vector3(_baseSpeed * _pace, _yValue, 0) * Time.deltaTime);

        
    }

    void fellDown()
    {
        // Player dies when falling down
        if (transform.position.y < -30f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    public void Damage()
    {
        // antihealth as a counter to reset health when dead
        antihealth += 1;
        health -= 1;
        LivesCounter.livesCounter -= 1;
        //_colorChannel -= 0.5f;
        //_mpb.SetColor("_Color", new Color(_colorChannel, 0, _colorChannel, 1f));
        //this.GetComponent<Renderer>().SetPropertyBlock(_mpb);

        if (health == 0)
        {
            //Invoke("resetHealth", 1f);
            FindObjectOfType<GameManager>().EndGame();
            //_spawnManager.GetComponent <SpawnManager>().onPlayerDeath();
            //Destroy(this.gameObject);
            //FindObjectOfType<GameManager>().EndGame();
        }
    }

    //void resetHealth()
    //{
      //  health = 3;
    //}

}