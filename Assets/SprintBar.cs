using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintBar : MonoBehaviour
{

    public HealthBar sprintbar;
    public float recoveryRate = 1f;

    private void FixedUpdate()
    {
        sprintbar.currentHealth = sprintbar.currentHealth + recoveryRate;
    }
}
