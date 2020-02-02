using System.Collections.Generic;
using UnityEngine;

public class Firestarter : MonoBehaviour
{
    public int fireRate = 20;
    public float waitTime = 5.0f;

    public Fire firePrefab;
    public LayoutManager layoutManager;

    private float timer = 0.0f;
    private Room[] rooms;
    private bool burning;
    private AudioSource _firePlayer;

    private List<GameObject> fires = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (firePrefab == null)
        {
            Debug.LogError("Warning, fire prefab not defined in Firestarter");
        }
        rooms = layoutManager.GetRooms();
        Debug.Log(rooms.Length);

        _firePlayer = gameObject.GetComponent<AudioSource>();
    }

    public void StartFireInRoom(Room room)
    {
        var fire = Instantiate(firePrefab.gameObject);

        var fireCollider = fire.GetComponent<Collider2D>();
        var roomCollider = room.gameObject.GetComponent<PolygonCollider2D>();
        var maxAttempts = 10;
        var attempts = 0;
        while (attempts < maxAttempts)
        {
            Vector3 extents = fireCollider.bounds.extents;
            Vector3 minPointForFire = getRandomPointInBounds(roomCollider);
            fire.transform.position = minPointForFire;
            if (roomCollider.bounds.Contains(minPointForFire - extents) &&
                roomCollider.bounds.Contains(minPointForFire + extents))
            {
                break;
            }
            attempts++;
        }
        if (attempts == maxAttempts)
        {
            Debug.Log("Could not start fire in " + room.roomName + " within " + maxAttempts + " attempts.\n"
                + "Bounds: " + fireCollider.bounds.min + fireCollider.bounds.max);
            Destroy(fire);
        }
        else
        {
            fire.GetComponent<Fire>().room = room;
            fires.Add(fire);
        }
    }

    private void FixedUpdate()
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
                StartFireInRoom(rooms[roomNumber]);
            }
        }

        burning = false;
        var extinguished = new List<GameObject>();
        foreach (GameObject fire in fires)
        {
            if (fire.GetComponent<Fire>().extinguished)
            {
                extinguished.Add(fire);
            }
        }
        foreach (GameObject fire in extinguished)
        {
            fires.Remove(fire);
            Destroy(fire);
        }

        if (burning)
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
    private Vector3 getRandomPointInBounds(PolygonCollider2D polygonCollider2D)
    {
        Vector3 min = polygonCollider2D.bounds.min;
        Vector3 max = polygonCollider2D.bounds.max;

        while (true)
        {
            float pointMinX = Random.Range(min.x, max.x);
            float pointMinY = Random.Range(min.y, max.y);
            Vector3 pointMin = new Vector3(pointMinX, pointMinY);

            if (polygonCollider2D.OverlapPoint(pointMin))
            {
                return pointMin;
            }
        }
    }

    public bool IsOnFire(Room room)
    {
        foreach (GameObject fire in fires)
        {
            var fireObject = fire.GetComponent<Fire>();
            if (!fireObject.extinguished && fireObject.room == room)
            {
                return true;
            }
        }
        return false;
    }
}
