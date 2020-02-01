using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firestarter : MonoBehaviour
{
    public int fireRate = 20;
    public float waitTime = 5.0f;

    public GameObject firePrefab;
    public LayoutManager layoutManager;

    private float timer = 0.0f;
    private Room[] rooms;
    private bool fire;
    private AudioSource _firePlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (firePrefab == null)
        {
            Debug.LogError("Warning, fire prefab not defined in Firestarter");
        }
        rooms = layoutManager.GetRooms();
        Debug.Log(rooms.Length);

        for(int i = 0; i < rooms.Length; i++)
        {
            Room r = rooms[i];

            r.fireInstance = Instantiate(firePrefab);
            r.fireInstance.transform.parent = r.transform;
            
            PolygonCollider2D roomCollider = r.gameObject.GetComponent<PolygonCollider2D>();
            while (true)
            {
                Vector3 extents = r.fireInstance.GetComponent<Collider2D>().bounds.extents;
                Vector2 extents2D = new Vector2(extents.x, extents.y);
                Vector2 minPointForFire = getRandomPointInBounds(roomCollider);
                Vector2 maxPointForFire = minPointForFire + 2*extents2D;
                if (roomCollider.OverlapPoint(maxPointForFire))
                {
                    r.fireInstance.transform.position = minPointForFire + extents2D;
                    break;
                }
            }


        }
        _firePlayer = gameObject.GetComponent<AudioSource>();
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

        fire = false;
        for (int i = 0; i < rooms.Length; i++)
        {
            if ((rooms[i].GetComponent("Room") as Room).isOnFire)
            {
                fire = true;
                break;
            }
        }

        if (fire)
        {
            if (!_firePlayer.isPlaying)
                _firePlayer.Play();
        }
        else
        {
            if (_firePlayer.isPlaying)
                _firePlayer.Stop();
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
        //return new Vector2(0, 0);
    }

}
