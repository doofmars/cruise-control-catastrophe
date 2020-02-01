using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raum : MonoBehaviour
{

    private Text currentRoomIndicatorText;
    public string roomname;
    public References references;

    // Start is called before the first frame update
    void Start()
    {
        currentRoomIndicatorText = references.currentRoomIndicator;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentRoomIndicatorText.text = roomname;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        currentRoomIndicatorText.text = roomname;
    }
}
