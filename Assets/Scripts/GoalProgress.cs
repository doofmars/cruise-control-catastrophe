﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalProgress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("Stay bridge");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter bridge");
    }
}
