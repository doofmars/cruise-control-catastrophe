using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CameraExtensions;

public class AsteroidShower : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public Camera camera;
    private Bounds screenBounds;
    private List<GameObject> asteroids = new List<GameObject>();

    public int fireRate = 60;
    public float waitTime = 7f;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = CameraExtensions.OrthographicBounds(camera);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            timer -= waitTime;

            if (Random.Range(0, 100) < fireRate)
            {
                SpawnAsteroid();
            }
        }
        foreach (GameObject asteroid in asteroids)
        {
            if (asteroid.transform.position.magnitude > screenBounds.size.magnitude)
            {
                Destroy(asteroid);
            }
        }
    }

    void SpawnAsteroid()
    {
        float angle = Random.Range(0.0f, 2.0f * Mathf.PI);
        float xRnd = Random.Range(0.0f, 1.0f) - 0.5f;
        float yRnd = Random.Range(0.0f, 1.0f) - 0.5f;
        var position = new Vector3(Mathf.Sin(angle) * screenBounds.size.x, Mathf.Cos(angle) * screenBounds.size.y);
        var target = new Vector3(xRnd * screenBounds.size.x, yRnd * screenBounds.size.y);

        var asteroid = Instantiate(asteroidPrefab);
        asteroid.transform.position = position;
        var body = asteroid.GetComponent<Rigidbody2D>();
        body.velocity = (target - position) * 0.2f;
        asteroids.Add(asteroid);
    }
}
