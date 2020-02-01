using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedComponent : MonoBehaviour
{
    [SerializeField] public HealthBar healthBar;
    public float currentHealth = 20f;

    public float maxHealth = 100f;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetValue(currentHealth / maxHealth);
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
        if (currentHealth < maxHealth) { 
            float timer = Time.deltaTime;
            currentHealth += timer * 20f;
            healthBar.SetValue(currentHealth / maxHealth);
        }
    }
}
