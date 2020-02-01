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
            while (true)
            {
                Bounds bounds = firePrefab.GetComponent<Collider2D>().bounds;
                PolygonCollider2D roomCollider = (PolygonCollider2D)r.GetComponent<Collider2D>();
                Vector2 minPointForFire = getRandomPointInBounds(roomCollider);
                Vector2 maxPointForFire = minPointForFire + new Vector2(bounds.extents.x, bounds.extents.y);
                if (roomCollider.OverlapPoint(maxPointForFire))
                {
                    r.fireInstance = Instantiate(firePrefab, minPointForFire, Quaternion.identity);
                    r.fireInstance.transform.parent = r.transform;
                    break;
                }
            }

            
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
                    //Debug.Log("fire in room " + (rooms[roomNumber].GetComponent("RoomMeta") as RoomMeta).roomname);
                    (rooms[roomNumber].GetComponent("Room") as Room).isOnFire = true;
                }
            }
        }
    }
    private Vector2 getRandomPointInBounds(PolygonCollider2D polygonCollider2D)
    {
        Vector3 min = polygonCollider2D.bounds.min;
        Vector3 max = polygonCollider2D.bounds.max;

        while(true)
        {
            float pointMinX = Random.Range(min.x, max.x);
            float pointMinY = Random.Range(min.y, max.y);
            Vector2 pointMin = new Vector2(pointMinX, pointMinY);

            if (polygonCollider2D.OverlapPoint(pointMin))
            {
                return pointMin;
            }
        }
        return new Vector2(0, 0);
    }

}
