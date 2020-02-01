using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedComponent : MonoBehaviour
{
    [SerializeField] public HealthBar healthBar;
    private SpriteRenderer spriteRenderer;
    public Sprite deadSprite;
    private Room parent;
    public float maxHealth = 100f;
    public float repairRate = 20f;
    public float maxOperatingTemperature = 400f;
    private bool broken = false;
    private int repairPersonnel = 0;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxHealth = maxHealth;
        parent = transform.GetComponentInParent<Room>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.temperature > maxOperatingTemperature)
        {
            var time = Time.deltaTime;
            healthBar.currentHealth -= time * 0.05f * maxHealth;
        }
        if (healthBar.currentHealth <= 0f && !broken)
        {
            broken = true;
            spriteRenderer.sprite = deadSprite;
            spriteRenderer.UpdateGIMaterials();
        }
        if (!healthBar.IsFull() && !broken && repairPersonnel > 0)
        {
            float timer = Time.deltaTime;
            healthBar.currentHealth += timer * repairRate * repairPersonnel;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        repairPersonnel++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        repairPersonnel--;
    }
}
