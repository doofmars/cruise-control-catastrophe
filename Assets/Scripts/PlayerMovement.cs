using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    public GravityGenerator gravityGenerator;

    float horizontal;
    float vertical;
    bool sprinting = false;
    public HealthBar sprintbar;
    public float sprintBarDecay = 1f;
    public float sprintingSpeedBonusFactor = 1.5f;

    public float runSpeed = 4.0f;
    private Vector3 currentSpeed = new Vector3(0f, 0f);
    public float maxAcceleration = 4f;
    public float airResistance = 0.1f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        sprinting = Input.GetKey(KeyCode.Space) && sprintbar.currentHealth*10>sprintbar.maxHealth;
        horizontal = Input.GetAxis("Horizontal"); // -1 is left
        vertical = Input.GetAxis("Vertical"); // -1 is down
        
        
    }

    void FixedUpdate()
    {
        rotatePlayer();
        if (sprinting)
        {
            runSpeed *= sprintingSpeedBonusFactor;
        }
        var time = Time.deltaTime;

        float gripFactor = gravityGenerator.gravity + 2f * airResistance;

        var targetV = new Vector3(horizontal * runSpeed, vertical * runSpeed);
        var diffV = targetV - currentSpeed;
        float playerAccelerationX, playerAccelerationY;
        if (Sign(diffV.x) * Sign(currentSpeed.x) < 0)
        {
            playerAccelerationX = Mathf.Min(gripFactor * maxAcceleration, Mathf.Abs(currentSpeed.x) / time) * Sign(diffV.x);
        } else
        {
            playerAccelerationX = gripFactor * maxAcceleration * Sign(diffV.x);
        }
        if (Sign(diffV.y) * Sign(currentSpeed.y) < 0)
        {
            playerAccelerationY = Mathf.Min(gripFactor * maxAcceleration, Mathf.Abs(currentSpeed.y) / time) * Sign(diffV.y);
        } else
        {
            playerAccelerationY = gripFactor * maxAcceleration * Sign(diffV.y);
        }
        var acceleration = new Vector3(
            playerAccelerationX - airResistance * currentSpeed.x / runSpeed,
            playerAccelerationY - airResistance * currentSpeed.y / runSpeed
        );
        if (acceleration.magnitude > maxAcceleration)
        {
            acceleration *= maxAcceleration / acceleration.magnitude;
        }

        currentSpeed += acceleration * time;
        body.velocity = currentSpeed;

        if (sprinting && currentSpeed.magnitude > 0f)
        {
            sprintbar.currentHealth = sprintbar.currentHealth - sprintBarDecay;
        }
        if (sprinting)
        {
            runSpeed /= sprintingSpeedBonusFactor;
        }
    }

    private float Sign(float value)
    {
        if (Mathf.Abs(value) < 0.01)
        {
            return 0f;
        } else
        {
            return Mathf.Sign(value);
        }
    }

    private void rotatePlayer()
    {
        if (Sign(currentSpeed.x) > 0 && Sign(currentSpeed.y) > 0)
        {
            body.SetRotation(135);
        } 
        else 
        if (Sign(currentSpeed.x) < 0 && Sign(currentSpeed.y) > 0)
        {
            body.SetRotation(225);
        }
        else 
        if (Sign(currentSpeed.x) > 0 && Sign(currentSpeed.y) < 0)
        {
            body.SetRotation(45);
        }
        else
        if (Sign(currentSpeed.x) < 0 && Sign(currentSpeed.y) < 0)
        {
            body.SetRotation(315);
        }
        else
        if (Sign(currentSpeed.y) > 0)
        {
            body.SetRotation(180);
        }
        else
        if (Sign(currentSpeed.y) < 0)
        {
            body.SetRotation(0);
        }
        else
        if (Sign(currentSpeed.x) > 0)
        {
            body.SetRotation(90);
        }
        else
        if (Sign(currentSpeed.x) < 0)
        {
            body.SetRotation(270);
        }
    }
}
