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
    private float _timePassed;
    private float _whenToPay = 1f;
    public float baseSpeed;
    
    //immunity variables
    public bool startImmune;
    public float immuneTime;
    public int vaccineHitBool;
    
    //crazy pills variables
    public bool startCrazy;
    public float crazyTime;
    public bool crazyHit;

    private bool _doWePay = true;
    
    //antihealth as a variable to measure the health to later subtract it
    public int antihealth = 0;

    private float _timeAnimation;
    

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        
        // immunity things:
        vaccineHitBool = 0;
        immuneTime = 0;
        startImmune = false;
        // crazy things:
        startCrazy = false;
        crazyHit = false;
        crazyTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Speed();
        GroundCheck();
        Gravity();
        PlayerMovement();
        fellDown();
        Immune();
        Crazy();
        if (Time.time - _timeAnimation > 0.1f)
        {
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isDamage", false);
        }
    }
    
    // different base speed (resulting in a different overall pace)
    // to avoid getting hit or collect items
    void Speed()
    {
        /*if (_groundCheck &&Input.GetButton("Fire1"))
        {
            
            _baseSpeed = 0.2f;
            _jumpHeight = 1.6f;

            // _timePassed = Time.time;


            // testing costs when influencing speed
            //InvokeRepeating("paceCostsCoins", 0.5f, Time.deltaTime * 1f);

        }
        /*else if (_groundCheck && Input.GetButton("Fire2"))
        {
            _baseSpeed = 1.3f;
            _jumpHeight = 2.2f;
        }*/
        /*else if (_groundCheck && Input.GetButton("Fire3"))
        {
            _baseSpeed = 1.65f;
            _jumpHeight = 3.5f;
            
            //_timePassed = Time.time;
        }
        else
        {
            _baseSpeed = 1f;
        }*/

        // paycheck when paceinfluence hold for 1sec
        /*if (Input.GetButton("Fire1") || Input.GetButton("Fire3"))
        {
            _timePassed = Time.time;
        }
        if (Input.GetButton("Fire1") || Input.GetButton("Fire3"))
        {
            if (Time.time - _timePassed > _whenToPay)
            {
                CoinCounter.scoreCounter -= 3;
                _timePassed = Time.time;
            }
        }*/
        
        // if crazyPill taken then go crazy
        if (crazyHit)
        {
            baseSpeed = 2.5f;
            _jumpHeight = 4.5f;
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isCrazy", true);
        }
        // otherwise behave normally
        // slow with at least 3 coins
        else
        {
            if (CoinCounter.scoreCounter > 2 && Input.GetButton("Fire1"))
        {

            baseSpeed = 0.2f;
            _jumpHeight = 1.6f;
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isSlow", true);
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isSprint", false);
            // holding one sec already? pay every second of hold
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
            baseSpeed = 1.65f;
            _jumpHeight = 3.5f;
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isSprint", true);
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isSlow", false);
            // holding one sec already? pay every second of hold
            if (Time.time - _timePassed > _whenToPay)
            {
                _doWePay = true;
            }
            // payment open every time you press (by making the variable true when stoping to press, allowing the payment by new press)
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
            //_timePassed = Time.time;
        }
            
            // base speed and jump
            else
            {
                baseSpeed = 1f;
                _jumpHeight = 2f;
                GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isSlow", false);
                GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isSprint", false);
            }
        {
            
        }
        }
        // when we have at least 3 coins and press 1
        
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
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isJump", true);

            _yValue += Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        }

        if (!_groundCheck)
        {
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isJump", false);
        }
        // Move the player forward
        //_characterController.Move(new Vector3(horizontalInput * runSpeed, 0, 0) * Time.deltaTime);
        _characterController.Move(new Vector3(baseSpeed * _pace, _yValue, 0) * Time.deltaTime);

        
    }

    void fellDown()
    {
        // Player dies when falling down
        if (transform.position.y < -30f)
        {
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isFalling", true);
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
        GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isDamage", true);
        _timeAnimation = Time.time;
        
        if (health == 0)
        {
            //Invoke("resetHealth", 1f);
            FindObjectOfType<GameManager>().EndGame();
            //_spawnManager.GetComponent <SpawnManager>().onPlayerDeath();
            //Destroy(this.gameObject);
            //FindObjectOfType<GameManager>().EndGame();
            GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isDead", true);
        }
    }
    

    // immunity comes here:
    void Immune()
    {
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