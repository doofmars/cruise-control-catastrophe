using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedComponent : MonoBehaviour
{
    [SerializeField] public HealthBar healthBar;
    private SpriteRenderer spriteRenderer;
    private Room parent;
    public float maxHealth = 100f;
    public float repairRate = 20f;
    public float maxOperatingTemperature = 400f;
    private bool broken = false;
    public int repairPersonnel { get; private set; } = 0;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxHealth = maxHealth;
        parent = transform.GetComponentInParent<Room>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        var time = Time.deltaTime;
        if (parent.temperature > maxOperatingTemperature)
        {
            healthBar.currentHealth -= time * 0.05f * maxHealth;
        }
        if (healthBar.currentHealth <= 0f && !broken)
        {
            broken = true;
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Dot_02_broken");
        }
        if (!healthBar.IsFull() && !broken && repairPersonnel > 0)
        {
            healthBar.currentHealth += time * repairRate * repairPersonnel;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            repairPersonnel++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            repairPersonnel--;
        }
        if (repairPersonnel < 0)
        {
            Debug.Log("Repair Personnel less than 0!");
        }
    }
}
