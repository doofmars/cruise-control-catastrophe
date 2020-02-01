using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firestarter : MonoBehaviour
{
    public int fireRate = 20;
    public float waitTime = 5.0f;

    public GameObject firePrefab;

    private float timer = 0.0f;
    private GameObject[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        if (firePrefab == null)
        {
            Debug.LogError("Warning, fire prefab not defined in Firestarter");
        }
        rooms = GameObject.FindGameObjectsWithTag("Room");
        Debug.Log(rooms.Length);

        for(int i = 0; i < rooms.Length; i++)
        {
            rooms[i].AddComponent<Room>();
            Room r = ((Room)rooms[i].GetComponent("Room"));
            r.fireInstance = Instantiate(firePrefab, r.transform.position, Quaternion.identity);
            r.fireInstance.transform.parent = r.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            // Remove the recorded 2 seconds.
            timer -= waitTime;

            if (Random.Range(0, 100) < fireRate)
            {
                //Burn a room
                int roomNumber = Random.Range(0, rooms.Length);
                if (!(rooms[roomNumber].GetComponent("Room") as Room).isOnFire)
                {
                    Debug.Log("fire in room " + roomNumber);
                    (rooms[roomNumber].GetComponent("Room") as Room).isOnFire = true;
                }
            }
        }
    }
}
