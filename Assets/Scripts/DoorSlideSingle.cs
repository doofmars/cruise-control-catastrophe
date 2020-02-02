﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlideSingle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        GameObject go = collision.gameObject;
        if (go.CompareTag("Player"))
        {
            DoorSlide ds = GetComponentInParent<DoorSlide>();

            ds.setOpenDoor();
        }
    }
}
