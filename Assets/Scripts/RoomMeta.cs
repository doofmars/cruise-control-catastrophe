using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMeta : MonoBehaviour
{

    public Text currentRoomIndicatorText;
    public string roomname;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentRoomIndicatorText.text = roomname;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        currentRoomIndicatorText.text = roomname;
    }
}
