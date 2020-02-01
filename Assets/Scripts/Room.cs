using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool isOnFire = false;
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    private bool isFireDisplayed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        if (other.tag == "Player")
        {
            Debug.Log("player is in Room");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnFire && !isFireDisplayed)
        {
            isFireDisplayed = true;

            // Instantiate at position (0, 0, 0) and zero rotation.
            Instantiate(myPrefab, GetComponent<Collider2D>().offset, Quaternion.identity);
        }
    }

}
