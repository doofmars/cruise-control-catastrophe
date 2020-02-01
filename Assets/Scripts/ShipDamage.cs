﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipDamage : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] rooms;
    private int _roomsOnFire;
    private GameObject _shipHealthBar;
    public float firedamage;
    void Start()
    {
        _shipHealthBar = GameObject.FindGameObjectWithTag("ShipHealth");
        rooms = GameObject.FindGameObjectsWithTag("Room");
    }

    // Update is called once per frame
    void Update()
    {
        _roomsOnFire = 0;
        for (int i = 0; i < rooms.Length; i++)
        {
            if ((rooms[i].GetComponent("Room") as Room).isOnFire)
            {
                _roomsOnFire++;
            }
        }

        (_shipHealthBar.GetComponent("ShipDamageBar") as ShipDamageBar).currentDamage += _roomsOnFire * firedamage;
    }

}