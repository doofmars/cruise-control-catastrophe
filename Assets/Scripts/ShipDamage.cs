using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipDamage : MonoBehaviour
{
    private GameObject[] rooms;
    private int _roomsOnFire;
    private GameObject _shipHealth;
    public float firedamage;

    // Start is called before the first frame update
    void Start()
    {
        rooms = GameObject.FindGameObjectsWithTag("Room");
        _shipHealth = GameObject.FindGameObjectsWithTag("ShipHealth")[0];
    }

    // Update is called once per frame
    void Update()
    {
        _roomsOnFire = 0;
        for (int i = 0; i < rooms.Length; i++)
        {
            if ((rooms[i].GetComponent("Room") as Room).isOnFire) {
                _roomsOnFire++;
            }
        }

        (_shipHealth.transform.Find("ShipHealthBar").gameObject.GetComponent("DamagedComponent") as DamagedComponent).currentHealth += _roomsOnFire * firedamage /60;

        if ((_shipHealth.transform.Find("ShipHealthBar").gameObject.GetComponent("DamagedComponent") as DamagedComponent).currentHealth >= 100.0)
        {
            loseGame();
        }
    }

    private void loseGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
