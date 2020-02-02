using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGenerator : MonoBehaviour
{
    public EnergyBar energyBar;
    public DamagedComponent machine;
    public float maxEnergy;
    public float chargeRate;

    public float gravity
    {
        get
        {
            return energyBar.currentEnergy / energyBar.maxEnergy;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        energyBar.maxEnergy = maxEnergy;
        energyBar.currentEnergy = maxEnergy;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        
        var time = Time.deltaTime;
        if (machine.healthBar.currentHealth < machine.healthBar.maxHealth / 2.0f && machine.repairPersonnel == 0)
        {
            energyBar.currentEnergy -= time * chargeRate;
        }
        if (machine.healthBar.currentHealth >= machine.healthBar.maxHealth / 2.0f || machine.repairPersonnel > 0)
        {
            energyBar.currentEnergy += time * chargeRate;
        }
    }
}
