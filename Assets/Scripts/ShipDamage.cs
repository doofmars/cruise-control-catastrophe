using System;
using UnityEngine;

public class ShipDamage : MonoBehaviour
{
    public LayoutManager layoutManager;
    // Start is called before the first frame update
    private Room[] rooms;
    private int _roomsOnFire;
    private GameObject _shipHealthBar;
    public float firedamage;
    void Start()
    {
        _shipHealthBar = GameObject.FindGameObjectWithTag("ShipHealth");
        rooms = layoutManager.GetRooms();
    }

    // Update is called once per frame
    void Update()
    {
        _roomsOnFire = 0;
        for (int i = 0; i < rooms.Length; i++)
        {
            if (layoutManager.fireStarter.IsOnFire(rooms[i]))
            {
                _roomsOnFire++;
            }
        }

        (_shipHealthBar.GetComponent("ShipDamageBar") as ShipDamageBar).currentDamage += (int)Math.Pow(2, _roomsOnFire - 1) * firedamage;
    }

}
