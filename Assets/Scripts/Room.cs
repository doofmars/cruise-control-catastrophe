using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public bool isOnFire = false;

    public GameObject fireInstance;

    private Text currentRoomIndicatorText;
    public string roomName;
    public LayoutManager layoutManager;

    public float temperature = 290f;
    
    void Start()
    {
        currentRoomIndicatorText = layoutManager.uiManager.currentRoomIndicator;
    }

    // Update is called once per frame
    void Update()
    {
        fireInstance.SetActive(isOnFire);
    }

    private void FixedUpdate()
    {
        var time = Time.deltaTime;
        if (isOnFire)
        {
            temperature += time * 15f;
        } else
        {
            temperature -= 0.1f * (temperature - 290f) * time;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentRoomIndicatorText.text = roomName + " (" + temperature + "K)";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        currentRoomIndicatorText.text = roomName + " (" + temperature + "K)";
    }
}
