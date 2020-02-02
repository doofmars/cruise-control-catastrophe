using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public HealthBar healthBar;
    public Room room;
    public float strength = 100f;
    public float extinguishingRate = 40f;
    public float restrengthenRate = 100f;
    private int extinguishingPersonnel = 0;

    public bool extinguished { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.currentHealth = 0f;
        healthBar.maxHealth = strength;
    }

    // Update is called once per frame
    void Update()
    {
        var time = Time.deltaTime;
        if (healthBar.currentHealth >= strength)
        {
            extinguished = true;
        }
        if (!extinguished && extinguishingPersonnel > 0)
        {
            healthBar.currentHealth += time * extinguishingRate * extinguishingPersonnel;
        }
        if (!extinguished && extinguishingPersonnel == 0)
        {
            healthBar.currentHealth -= time * restrengthenRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            extinguishingPersonnel++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            extinguishingPersonnel--;
        }
    }
}
