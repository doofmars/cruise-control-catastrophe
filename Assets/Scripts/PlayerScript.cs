using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private GameObject playerLocation;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (playerLocation != null && playerLocation.CompareTag("Room") && (playerLocation.GetComponent("Room") as Room).isOnFire)
            {
                Debug.Log("Player has extingushed room");
                (playerLocation.GetComponent("Room") as Room).isOnFire = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        GameObject room = other.gameObject;
        if (room.CompareTag("Room"))
        {
            // Room entered
            string name = (room.GetComponent("RoomMeta") as RoomMeta).roomname;
            playerLocation = room;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Room room = collision.gameObject.GetComponent("Room") as Room;
        if (room.CompareTag("Room"))
        {
            // Player exits room
            string name = (room.GetComponent("RoomMeta") as RoomMeta).roomname;
            Debug.Log("Player exited room" + name);
            playerLocation = null;
        }
    }
}
