﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalFailureInducer : MonoBehaviour
{
    public int fireRate = 1;
    public float waitTime = 1.0f;

    public LayoutManager layoutManager;

    private float timer = 0.0f;
    private DamagedComponent[] components;
    // Start is called before the first frame update
    void Start()
    {
        components = layoutManager.GetMachines();
        Debug.Log("MachineCount: " + components.Length);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            // Remove the recorded 2 seconds.
            timer -= waitTime;

            if (Random.Range(0, 100) < fireRate)
            {
                // Target a machine
                int machineIndex = Random.Range(0, components.Length);
                if (machineIndex > 0)
                {
                    var machine = components[machineIndex];
                    machine.healthBar.currentHealth -= machine.healthBar.maxHealth * 0.2f;
                    Debug.Log("Machine " + machine.name + " had an electrical failure.");
                }
            }
        }
    }
}