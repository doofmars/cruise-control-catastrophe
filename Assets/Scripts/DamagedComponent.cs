using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedComponent : MonoBehaviour
{
    [SerializeField] public HealthBar healthBar;
    public float maxHealth = 100f;
    public float repairRate = 20f;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxHealth = maxHealth;
        healthBar.currentHealth = 20f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateFixed()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!healthBar.IsFull()) { 
            float timer = Time.deltaTime;
            healthBar.currentHealth += timer * repairRate;
        }
    }
}
