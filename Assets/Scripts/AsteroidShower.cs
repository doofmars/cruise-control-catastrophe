using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        timer = waitTime;
    }

    private void FixedUpdate()
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
        var destroyed = new List<GameObject>();
        foreach (GameObject asteroid in asteroids)
        {
            if (asteroid.GetComponent<Asteroid>().dead || asteroid.transform.position.magnitude > screenBounds.size.magnitude)
            {
                destroyed.Add(asteroid);
            }
        }
        foreach (GameObject asteroid in destroyed)
        {
            asteroids.Remove(asteroid);
            Destroy(asteroid);
        }
    }

    void SpawnAsteroid()
    {
        float angle = Random.Range(0.0f, 2.0f * Mathf.PI);
        float xRnd = Random.Range(0.0f, 1.0f) - 0.5f;
        float yRnd = Random.Range(0.0f, 1.0f) - 0.5f;
        var position = new Vector3(Mathf.Sin(angle) * screenBounds.size.x, Mathf.Cos(angle) * screenBounds.size.y, 1f);
        var target = new Vector3(xRnd * screenBounds.size.x, yRnd * screenBounds.size.y);

        float mass = Random.Range(5.0f, 40.0f);

        var asteroid = Instantiate(asteroidPrefab);
        asteroid.transform.position = position;
        asteroid.transform.localScale = new Vector3(mass / 15.0f, mass / 15.0f);
        var body = asteroid.GetComponent<Rigidbody2D>();
        body.velocity = (target - position) * 0.2f;
        body.mass = mass;
        asteroids.Add(asteroid);
    }
}
