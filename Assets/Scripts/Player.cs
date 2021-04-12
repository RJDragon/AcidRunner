using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Serialization;



public class Player : MonoBehaviour
{
    // variable to give objects the property ground
    [SerializeField] private LayerMask _ground;
    // player pace variable
    [SerializeField] private float _pace = 5f;
    // default jump height
    [SerializeField] private float _jumpHeight = 2f;
    // starting health points
    [SerializeField] public int health = 3;
    
    // gravity variables
    private float _gravity = -50f;
    private CharacterController _characterController;
    private float _yValue;
    private bool _groundCheck;
    
    // variable storing the time on that moment
    private float _timePassed;
    // variable storing the time when its time to pay
    private float _whenToPay = 1f;
    // base speed
    public float baseSpeed;
    
    //immunity variables
    // variable to declare immunity status for other methods
    public bool startImmune;
    // when hit by medikit, vaccine script gives time of collusion
    public float immuneTime;
    // to distinguish and to have a better overview between the other immune bools, we compared here with 1 and 0
    public int vaccineHitBool;
    
    //crazy pills variables
    // variable to declare crazy status for other methods
    public bool startCrazy;
    // when hit by crazy pill, crazypill script gives time of collusion
    public float crazyTime;
    // other bool variable for crazycheck
    public bool crazyHit;

    // bool to later make sure that payment is not every frame, but rather a declared time (here one sec)
    private bool _doWePay = true;
    
    //antihealth as a variable to measure the health to later subtract it
    public int antihealth = 0;

    // time variable for the damage animations which is actually just a dancing animations cut down to 0.1 seconds
    private float _timeAnimation;
    

    void Start()
    {
        // init. charactercontroller which will later move the player
        _characterController = GetComponent<CharacterController>();
        
        // immunity things intialization:
        vaccineHitBool = 0;
        immuneTime = 0;
        startImmune = false;
        // crazy things:
        startCrazy = false;
        crazyHit = false;
        crazyTime = 0f;
    }

    
    void Update()
    {
        Speed();
        GroundCheck();
        Gravity();
        PlayerMovement();
        fellDown();
        Immune();
        Crazy();
        // makes sure that the animation of dancing goes for just 0.1 seconds to imply a damage reaction of the player character
        if (Time.time - _timeAnimation > 0.1f)
        {
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isDamage", false);
        }
    }
    
    // different base speed (resulting in a different overall pace)
    // to avoid getting hit or collect items
    void Speed()
    {

        // if crazyPill taken then go crazy
        if (crazyHit)
        {
            // way faster
            baseSpeed = 2.5f;
            // way higher
            _jumpHeight = 4.5f;
            // its own crazyrunning animation
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isCrazy", true);
        }
        // otherwise behave normally (not crazy)
        // slow with at least 3 coins
        else
        {
            if (CoinCounter.scoreCounter > 2 && Input.GetButton("Fire1"))
        {
            // way slower
            baseSpeed = 0.2f;
            // little jump
            _jumpHeight = 1.6f;
            // init. creeping animation for slow running
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isSlow", true);
            // make sure player does not sprint anymore in the animation
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isSprint", false);
            // holding one sec already? pay every second of hold!
            if (Time.time - _timePassed > _whenToPay)
            {
                _doWePay = true;
            }

            // payment open every time you press (by making the variable true when stopping to press, allowing the payment by new press)
            if (Input.GetButtonUp("Fire1"))
            {
                _doWePay = true;
            }
            
            // influencing the speed costs 3 coins; starts the time counter here and makes sure it does not happen every frame with false
            if (_doWePay == true)
            {
                _timePassed = Time.time;
                CoinCounter.scoreCounter -= 3;
                _doWePay = false;
                
            }
            
        }
        // when we have at least 3 coins and press 3, fast
        else if (CoinCounter.scoreCounter > 2 && Input.GetButton("Fire3"))
        {
            // way faster, but not crazy
            baseSpeed = 1.65f;
            // way higher, but not crazy
            _jumpHeight = 3.5f;
            // own animation
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isSprint", true);
            // no creeping
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isSlow", false);
            // holding one sec already? pay every second of hold!
            if (Time.time - _timePassed > _whenToPay)
            {
                _doWePay = true;
            }
            // payment open every time you press (by making the variable true when stopping to press, allowing the payment by new press)
            if (Input.GetButtonUp("Fire1"))
            {
                _doWePay = true;
            }
            // influencing the speed costs 3 coins; starts the time counter here and makes sure it does not happen every frame with false
            if (_doWePay == true)
            {
                _timePassed = Time.time;
                CoinCounter.scoreCounter -= 3;
                _doWePay = false;
                
            }
            
        }
            
            // base speed and jump
            else
            {
                baseSpeed = 1f;
                _jumpHeight = 2f;
                // making sure the special animations stop
                GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isSlow", false);
                GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isSprint", false);
            }
        {
            
        }
        }
        
        
    }

    void GroundCheck()
    {
        // bool to check if on ground
        _groundCheck = Physics.CheckSphere(transform.position, 0.1f, _ground, QueryTriggerInteraction.Ignore);
    }

    void Gravity()
    {
        // if its on ground, stop the gravity by setting a factor to 0
        if (_groundCheck)
        {
            _yValue = 0;
        }
        // not on ground? gravity activated
        else
        {
            _yValue += _gravity * Time.deltaTime;
        }
    }

    void PlayerMovement()
    {
        // Let the player jump if on ground (no air jumps)
        if (_groundCheck && Input.GetButtonDown("Jump"))
        {
            // extra jumping animation
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isJump", true);

            // realistic "jumping speed"; value of influence on y axis of player
            _yValue += Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        }

        if (!_groundCheck)
        {
            // jumping animation has to stop right after
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isJump", false);
        }
        // Move the player, steady forward and depending on jump and falling, up and down
        _characterController.Move(new Vector3(baseSpeed * _pace, _yValue, 0) * Time.deltaTime);

        
    }

    void fellDown()
    {
        // Player dies when falling down
        if (transform.position.y < -30f)
        {
            // falling deadly animation
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isFalling", true);
            // calls endgame function to reset the game
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    public void Damage()
    {
        // antihealth as a counter to reset health when dead
        antihealth += 1;
        // lose one health
        health -= 1;
        LivesCounter.livesCounter -= 1;
        // "damage animation"
        GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isDamage", true);
        // time variable to compare if animations has to stop (here after 0.1 sec)
        _timeAnimation = Time.time;
        
        if (health == 0)
        {
            // when player has 0 health, call endgame function
            FindObjectOfType<GameManager>().EndGame();
           // death animation is here, because its death from losing health and not jumping down
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isDead", true);
        }
    }
    

    // immunity comes here:
    void Immune()
    {
        // stops immunity after 7 seconds
        if (Time.time - immuneTime > 7f)
        {
            startImmune = false;
            vaccineHitBool = 0;
        }
        if (startImmune)
        {
            vaccineHitBool = 1;
        }
    }

    void Crazy()
    {
        // stops craziness (and animation) after 7 seconds
        if (Time.time - crazyTime > 7f)
        {
            startCrazy = false;
            crazyHit = false;
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isCrazy", false);
        }
        if (startCrazy)
        {
            crazyHit = true;
        }
    }
}