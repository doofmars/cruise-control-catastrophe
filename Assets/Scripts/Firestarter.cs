using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firestarter : MonoBehaviour
{
    public int fireRate = 20;
    public float waitTime = 5.0f;

    public GameObject firePrefab;

    private float timer = 0.0f;
    private object[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        rooms = FindObjectsOfType(typeof(Room));
        Debug.Log(rooms.Length);

        for(int i = 0; i < rooms.Length; i++)
        {
            Room r = ((Room)rooms[i]);
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
                if (!((Room)rooms[roomNumber]).isOnFire)
                {
                    Debug.Log("fire in room " + roomNumber);
                    ((Room)rooms[roomNumber]).isOnFire = true;
                }
            }
        }
    }
}
