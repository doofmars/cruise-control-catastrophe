using UnityEngine;

public class Room : MonoBehaviour
{

    public string roomName;
    public LayoutManager layoutManager;

    public float temperature = 290f;
    private AudioSource _explosion;

    void Start()
    {
        _explosion = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        var time = Time.deltaTime;
        if (layoutManager.fireStarter.IsOnFire(this))
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
                layoutManager.fireStarter.StartFireInRoom(this);
                _explosion.Play();
                asteroid.Deactivate();
            }
        }
    }
}
