using UnityEngine;

public class Room : MonoBehaviour
{
    public bool isOnFire = false;

    public GameObject fireInstance;

    public string roomName;
    public LayoutManager layoutManager;

    public float temperature = 290f;
    private AudioSource _explosion;
    public GameObject explosionprefab;

    void Start()
    {
        _explosion = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        fireInstance.SetActive(isOnFire);
    }

    private void FixedUpdate()
    {
        var time = Time.deltaTime;
        if (isOnFire)
        {
            temperature += time * 15f;
        }
        else
        {
            temperature -= 0.1f * (temperature - 290f) * time;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            var asteroid = collision.gameObject.GetComponent<Asteroid>();
            if (layoutManager.shieldGenerator.energyBar.currentEnergy <= 0f && asteroid.CanCollide())
            {
                isOnFire = true;
                _explosion.Play();
                var asteroidposition = asteroid.gameObject.transform.position;
                var explosion = Instantiate(explosionprefab);
                explosion.transform.position = asteroidposition;
                Destroy(explosion, 0.5f);
                asteroid.Deactivate();
            }
        }
    }
}
