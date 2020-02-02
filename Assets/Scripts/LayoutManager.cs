using System.Collections.Generic;
using UnityEngine;

public class LayoutManager : MonoBehaviour
{

    public UiManager uiManager;
    public ShieldGenerator shieldGenerator;
    public Firestarter fireStarter;

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

    public DamagedComponent[] GetMachines()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag("Machine");
        var machines = new List<DamagedComponent>();
        foreach (GameObject gameObject in gameObjects)
        {
            machines.Add(gameObject.GetComponent<DamagedComponent>());
        }
        return machines.ToArray();
    }
}
