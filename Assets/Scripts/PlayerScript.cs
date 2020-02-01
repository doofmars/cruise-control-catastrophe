using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Room playerLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (playerLocation != null && playerLocation.isOnFire)
            {
                Debug.Log("Player has extingushed room");
                playerLocation.isOnFire = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Room room = other.gameObject.GetComponent("Room") as Room;
        if (room != null)
        {
            // Room entered
            playerLocation = room;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Room room = other.gameObject.GetComponent("Room") as Room;
        if (room != null)
        {
            // Player exits room
            playerLocation = null;
        }
    }
}
