using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Room currentRoom;
    public UiManager uiManager;

    // Update is called once per frame
    void Update()
    {
        if (currentRoom != null)
        {
            uiManager.currentRoomIndicator.text = string.Format("{0} ({1:0}K)", currentRoom.roomName, currentRoom.temperature);
        }
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
