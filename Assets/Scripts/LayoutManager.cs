using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutManager : MonoBehaviour
{

    public UiManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Room[] GetRooms()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag("Room");
        var rooms = new List<Room>();
        foreach (GameObject gameObject in gameObjects)
        {
            rooms.Add(gameObject.GetComponent("Room") as Room);
        }
        return rooms.ToArray();
    }
}
