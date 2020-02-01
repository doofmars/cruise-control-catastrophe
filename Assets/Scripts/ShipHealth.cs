using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    private GameObject[] rooms;
    private int _roomsOnFire;
    private GameObject _shipHealth;


    // Start is called before the first frame update
    void Start()
    {
        rooms = GameObject.FindGameObjectsWithTag("Room");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            if ((rooms[i].GetComponent("Room") as Room).isOnFire) {
                _roomsOnFire++;
            }
        }

    }
}
