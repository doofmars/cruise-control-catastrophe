using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool isOnFire = false;
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    public GameObject fireInstance;

    private void Start()
    {
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player is in Room");
        }
    }

    // Update is called once per frame
    void Update()
    {
        fireInstance.SetActive(isOnFire);
    }
}
