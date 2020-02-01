using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Room currentRoom;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (currentRoom != null && currentRoom.CompareTag("Room") && (currentRoom.GetComponent("Room") as Room).isOnFire)
            {
                Debug.Log("Player has extingushed room");
                (currentRoom.GetComponent("Room") as Room).isOnFire = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        GameObject room = other.gameObject;
        if (room.CompareTag("Room"))
        {
            // Room entered
            currentRoom = (room.GetComponent("Room") as Room);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject room = other.gameObject;
        if (room.CompareTag("Room"))
        {
            // Player exits room
            string name = (room.GetComponent("Room") as Room).roomName;
            Debug.Log("Player exited room" + name);
            currentRoom = null;
        }
    }
}
