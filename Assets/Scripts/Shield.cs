using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public ShieldGenerator shieldGenerator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Asteroid"))
        {
            var asteroid = collider.gameObject.GetComponent<Asteroid>();
            if (asteroid.CanCollide())
            {
                shieldGenerator.DrainShield(asteroid.GetComponent<Rigidbody2D>().mass);
                asteroid.Deactivate();
            }
        }
    }
}
