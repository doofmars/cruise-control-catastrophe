using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool isOnFire = false;

    public GameObject fireInstance;

    private void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        fireInstance.SetActive(isOnFire);
    }
}
