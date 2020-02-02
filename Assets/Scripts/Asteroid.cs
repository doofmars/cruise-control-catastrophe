using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float continuousImpactProbabiltiy = 0.005f;
    public bool dead { get; private set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
    }

    public bool CanCollide()
    {
        return !dead && Random.Range(0, 10000) < continuousImpactProbabiltiy * 10000;
    }

    public void Deactivate()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        dead = true;
    }
}
