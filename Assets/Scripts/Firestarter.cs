using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firestarter : MonoBehaviour
{
    public int fireRate = 20;
    public float waitTime = 5.0f;

    private float timer = 0.0f;
    private float visualTime = 0.0f;
    private long timeSinceLastFire = 0;
    private object[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        rooms = FindObjectsOfType(typeof(Room));
        Debug.Log(rooms.Length);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            visualTime = timer;

            // Remove the recorded 2 seconds.
            timer = timer - waitTime;

            if (Random.Range(0, 100) < fireRate)
            {
                //Burn a room
                int roomNumber = Random.Range(0, rooms.Length);
                Debug.Log("fire in room " + roomNumber);

            }

            
        }
    }
}
