using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Room currentRoom;
    public UiManager uiManager;
    private Text currentRoomIndicatorText;
    void Start()
    {
        currentRoomIndicatorText = uiManager.currentRoomIndicator;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (currentRoom != null && currentRoom.CompareTag("Room") && (currentRoom.GetComponent("Room") as Room).isOnFire)
            {
                (currentRoom.GetComponent("Room") as Room).isOnFire = false;
            }
        }
        
        currentRoomIndicatorText.text = string.Format("{0} ({1:0}K)", currentRoom.roomName, currentRoom.temperature);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject room = collision.gameObject;
        if (room.CompareTag("Room"))
        {
            currentRoom = (room.GetComponent("Room") as Room);
        }
    }
}
