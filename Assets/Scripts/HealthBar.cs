using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;
    private Vector3 vector3 = new Vector3(1f, 1f);

    public bool hideWhenFull = true;
    private bool visible = true;

    public float maxHealth = 100f;
    public float startingHealth = 100f;
    private float _currentHealth = 0f;
    public float currentHealth
    {
        get { return _currentHealth; }
        set
        {
            if (value < 0f)
            {
                value = 0f;
            }
            if (value < maxHealth)
            {
                _currentHealth = value;
                visible = true;
            }
            else
            {
                _currentHealth = maxHealth;
                visible = false || !hideWhenFull;
            }
            vector3.x = _currentHealth / maxHealth;
            bar.localScale = vector3;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = startingHealth;
    }

    private void Update()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = visible;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = visible;
        transform.GetChild(2).GetChild(0).GetComponent<SpriteRenderer>().enabled = visible;
    }

    public bool IsFull()
    {
        return currentHealth >= maxHealth;
    }
}
