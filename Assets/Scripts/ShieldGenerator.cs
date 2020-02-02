using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGenerator : MonoBehaviour
{
    public EnergyBar energyBar;
    public DamagedComponent machine;
    public float maxEnergy;
    public float manualChargeRate;
    public float automaticChargeRate;

    // Start is called before the first frame update
    void Start()
    {
        energyBar.maxEnergy = maxEnergy;
        energyBar.currentEnergy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        var time = Time.deltaTime;
        if (machine.healthBar.IsFull() && machine.repairPersonnel > 0)
        {
            energyBar.currentEnergy += time * manualChargeRate * machine.repairPersonnel;
        }
        if (machine.healthBar.IsFull())
        {
            energyBar.currentEnergy += time * automaticChargeRate;
        }
    }

    public void DrainShield(float energyCost)
    {
        energyBar.currentEnergy -= energyCost;
    }
}
