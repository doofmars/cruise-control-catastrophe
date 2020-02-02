using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    bool sprinting = false;
    public HealthBar sprintbar;
    public float sprintBarDecay = 1f;
    public float sprintingSpeedBonusFactor = 1.5f;

    public float runSpeed = 4.0f;
    private float _currentspeed = 0.0f;
    public float acceleration = 1.1f;
    public float startSpeed = 0.09f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        sprinting = Input.GetKey(KeyCode.Space) && sprintbar.currentHealth*10>sprintbar.maxHealth;
           horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
           vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        
        
    }

    void FixedUpdate()
    {
        rotatePlayer();


        if (sprinting)
            sprintbar.currentHealth = sprintbar.currentHealth - sprintBarDecay;

        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        if (horizontal != 0 || vertical != 0)
        {
            if (_currentspeed >= (runSpeed))
                _currentspeed = runSpeed;
            else
            {
                if (_currentspeed == 0.0f)
                    _currentspeed = startSpeed;
                else
                    _currentspeed *= acceleration;
            }
                
        }
        
        if (horizontal == 0 && vertical == 0) // Player stopped
        {
            if (_currentspeed > 0.1f)
                _currentspeed *= 0.2f;
            else
                _currentspeed = 0.0f;
            body.velocity *= _currentspeed;
        } 
        else
        {
            if (sprinting)
            {
                body.velocity = new Vector2(horizontal * _currentspeed * sprintingSpeedBonusFactor, vertical * _currentspeed * sprintingSpeedBonusFactor);
            }
            else
            {
                body.velocity = new Vector2(horizontal * _currentspeed, vertical * _currentspeed);
            }
        }
    }

    private void rotatePlayer()
    {
        var left = -1;
        var right = 1;
        var down = -1;
        var up = 1;
        if (horizontal == right && vertical == up)
        {
            body.SetRotation(135);
        } 
        else 
        if (horizontal == left && vertical == up)
        {
            body.SetRotation(225);
        }
        else 
        if (horizontal == right && vertical == down)
        {
            body.SetRotation(45);
        }
        else
        if (horizontal == left && vertical == down)
        {
            body.SetRotation(315);
        }
        else
        if (vertical == up)
        {
            body.SetRotation(180);
        }
        else
        if (vertical == down)
        {
            body.SetRotation(0);
        }
        else
        if (horizontal == right)
        {
            body.SetRotation(90);
        }
        else
        if (horizontal == left)
        {
            body.SetRotation(270);
        }
    }
}
