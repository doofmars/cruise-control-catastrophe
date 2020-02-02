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

    public float runSpeed = 20.0f;

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
        if (sprinting)
            sprintbar.currentHealth = sprintbar.currentHealth - sprintBarDecay;

        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        if (sprinting)
        {
            body.velocity = new Vector2(horizontal * runSpeed * sprintingSpeedBonusFactor, vertical * runSpeed * sprintingSpeedBonusFactor);
        }
        else
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }
}
