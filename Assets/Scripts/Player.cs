using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int health;
    public bool isDead;
    public Color color;
    public GameObject gameObject;

    public Player(int health, Color color)
    {
        this.health = health;
        this.isDead = false;
        this.color = color;
        this.gameObject = null;
    }
}
